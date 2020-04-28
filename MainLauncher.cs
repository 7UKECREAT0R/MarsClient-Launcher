using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using System.Diagnostics;
using CmlLib.Core;
using CmlLib;
using System.Reflection;

namespace TitanixClient___Forms
{
    public partial class MainLauncher : UserControl
    {
        public static readonly string titanixLogoURL = "https://i.imgur.com/a2Bc87X.png";

        internal static Process staticMC = null;
        internal static Thread mcThread = null;

        static string currentServer = "";
        bool launched = false;
        int buttonGoalRoundness = 20;
        int buttonCurrentRoundness = 20;
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
            private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);
        public Region RoundedRect(int radius, Size dim)
        {
            try
            {
                return Region.FromHrgn(CreateRoundRectRgn(0, 0, dim.Width, dim.Height, radius, radius));
            } catch(Exception)
            {

                return null;
            }
        }

        public MainLauncher()
        {
            InitializeComponent();
            launchButton.Region = RoundedRect(20, launchButton.Size);
            splash.Region = RoundedRect(buttonCurrentRoundness, splash.Size);
            keybindsButton.Region = RoundedRect(15, keybindsButton.Size);

            toolTip1.SetToolTip(signout, "Sign Out");
            toolTip1.SetToolTip(launchButton, "Starts minecraft.");
            toolTip1.SetToolTip(serverPicker, "The server to automatically join when the game starts.");
            toolTip1.SetToolTip(versionSelector, "The version that will be launched and/or downloaded.");

            timer1.Start();
            rpcTimer.Start();
        }

        private void MainLauncher_Paint(object sender, PaintEventArgs e)
        {
            var logo = Properties.Resources.titanix_logo;
            e.Graphics.DrawImage(logo, new Rectangle(40, 25, divideRound(logo.Width, 3), divideRound(logo.Height, 3)));
        }
        public int divideRound(double a, double b)
        {
            return (int)Math.Round(a / b);
        }
        public static int Lerp(int a, int b, double t)
        {
            return (int)Math.Round((1 - t) * a + t * b);
        }
        private void McLaunchThread_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker self = (BackgroundWorker)sender;
            string[] args = (string[])e.Argument;
            string version = args[0];
            string sptxt = args[1];

        }
        private void launchButton_Click(object sender, EventArgs e)
        {
            string sptxt = serverPicker.Text;
            if (!string.IsNullOrEmpty(sptxt))
            {
                File.WriteAllText("titanix_client\\serverip.ser", sptxt);
            } else
            {
                File.WriteAllText("titanix_client\\serverip.ser", "");
            }
            object _version = versionSelector.SelectedItem;
            if(_version == null)
            {
                MessageBox.Show("Please select a version!", "Titanix", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string version = (string)_version;
            File.WriteAllText("titanix_client\\version.ser", version);
            string path = Minecraft.GetOSDefaultPath();
            CMLauncher launcher = new CMLauncher(path);
            bool forge = version.ToLower().Contains("forge");

            MSession ssh;
            if (!Data.offline)
            {
                ssh = new MSession();
                Type editor = typeof(MSession);
                editor.GetField("<ClientToken>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(ssh, Data.clientToken);
                editor.GetField("<AccessToken>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(ssh, Data.accessToken);
                editor.GetField("<Username>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(ssh, Data.username);
                editor.GetField("<UUID>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(ssh, Data.profileuuid);
            } else
            {
                string username = Data.username;
                ssh = MSession.GetOfflineSession(username);
            }
            MLaunchOption options = new MLaunchOption()
            {
                JavaPath = "java.exe",
                MaximumRamMb = GetInstalledMemoryMB() / 2,
                Session = ssh,

                VersionType = version,
                GameLauncherName = "TitanixClient",
                GameLauncherVersion = "1.3",
            };
            if (forge)
            {
                string[] parts = version.Split('-');
                string mcVer = parts[0];
                string forgeVer = parts[2]+"-"+parts[3];
                MProfile forgeProfile = launcher.GetProfile(mcVer, forgeVer);
                options.StartProfile = forgeProfile;
            }
            else
                options.StartProfile = launcher.GetProfile(version);
            if (!string.IsNullOrEmpty(sptxt))
            {
                options.ServerIp = sptxt;
            }
            Data.hook.OnHookKeyPressed += Hook_OnHookKeyPressed;
            MLaunch launch = new MLaunch(options);
            mcThread = new Thread(new ParameterizedThreadStart(delegate(object obj) {
                MLaunch threadLaunch = (MLaunch)obj;
                Process pr = threadLaunch.GetProcess();
                ProcessStartInfo psi = pr.StartInfo;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardInput = true;
                psi.UseShellExecute = false;
                staticMC = Process.Start(psi);
                staticMC.EnableRaisingEvents = true;
                launched = true;
                staticMC.Exited += delegate
                {
                    //OutputManager.RemoveConsole();
                    Data.rpccli.Dispose();
                    Environment.Exit(0);
                };
                staticMC.OutputDataReceived += (object _, DataReceivedEventArgs _a) =>
                {
                    string txt = _a.Data;
                    OutputManager.ProcessText(txt);
                    if (txt == null) return;
                    if (txt.Contains("[Client thread/INFO]: Connecting to"))
                    {
                        int timeind = txt.IndexOf(']');
                        string a = txt.Substring(timeind + 38);
                        string b = a.Split(',')[0];
                        string newserver = "Server: " + b;
                        if (!currentServer.Equals(newserver))
                        {
                            Debug.WriteLine("Connected to: \"" + b + "\"");
                            Console.WriteLine("Connected to: \"" + b + "\"");
                        }
                        currentServer = "Server: " + b;
                    }
                };
                staticMC.BeginOutputReadLine();
                /*if (!mcLaunchThread.IsBusy)
                {
                    launched = true;
                    mcLaunchThread.RunWorkerAsync(new string[] { version, sptxt });
                } else
                {
                    MessageBox.Show("The game is currently running, please close the game to launch again.");
                    return;
                }*/
            }));
            //OutputManager.CreateConsole();
            mcThread.Start(launch);
        }

        IntPtr minecraftHWND = IntPtr.Zero;
        private void Hook_OnHookKeyPressed(HookKeyPressArgs args)
        {
            if(minecraftHWND.Equals(IntPtr.Zero))
                minecraftHWND = staticMC.MainWindowHandle;

            IntPtr fore = GetForegroundWindow();
            if (!minecraftHWND.Equals(fore)) return;

            bool ctrlDown = GetKeyDown(Keys.LControlKey)
                || GetKeyDown(Keys.RControlKey);
            if (!ctrlDown) return;

            foreach (Keybind kb in Data.keybinds.keybinds)
            {
                if (kb.key == args.pressed)
                {
                    string text = kb.game.gameInternalName;
                    KeyboardHooking.SendCTRLUp(minecraftHWND);
                    Thread.Sleep(1000);
                    SendKeys.Send("/");
                    Thread.Sleep(1000);
                    SendKeys.Send("play " + text);
                    Thread.Sleep(1000);
                    SendKeys.Send("{ENTER}");
                    break;
                }
            }
        }

        private void signout_Click(object sender, EventArgs e)
        {
            if(File.Exists("titanix_client\\accessToken.tok"))
                File.Delete("titanix_client\\accessToken.tok");

            if (File.Exists("titanix_client\\uuid.tok"))
                File.Delete("titanix_client\\uuid.tok");

            Data.accessToken = ""; Data.uuid = "";
            SendToBack();
        }

        private void launchButton_MouseEnter(object sender, EventArgs e)
        {
            if(!launched)
                buttonGoalRoundness = 60;
        }
        private void launchButton_MouseLeave(object sender, EventArgs e)
        {
            if(!launched)
                buttonGoalRoundness = 20;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!launched)
            {
                buttonCurrentRoundness = Lerp(buttonCurrentRoundness, buttonGoalRoundness, 0.07);
                Region lbr = launchButton.Region;
                if(lbr != null) { lbr.Dispose(); }
                launchButton.Region = RoundedRect(buttonCurrentRoundness, launchButton.Size);
            }
        }

        private void MainLauncher_Load(object sender, EventArgs e)
        {
            string path = Minecraft.GetOSDefaultPath();
            CMLauncher launcher = new CMLauncher(path);
            launcher.UpdateProfiles();
            versionSelector.Items.Clear();
            foreach(MProfileMetadata md in launcher.Profiles)
            {
                string name = md.Name;
                if (!name.ToLower().Contains('w') &&
                !name.ToLower().Contains("pre"))
                {
                    versionSelector.Items.Add(md.Name);
                }
            }
            if(File.Exists("titanix_client\\serverip.ser"))
            {
                string ip = File.ReadAllText("titanix_client\\serverip.ser");
                serverPicker.Text = ip;
            }
            if (File.Exists("titanix_client\\version.ser"))
            {
                string ver = File.ReadAllText("titanix_client\\version.ser");
                versionSelector.SelectedItem = ver;
            }
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetPhysicallyInstalledSystemMemory(out ulong TotalMemoryInKilobytes);
        internal int GetInstalledMemoryMB()
        {
            ulong memkb;
            GetPhysicallyInstalledSystemMemory(out memkb);
            int memmb = Convert.ToInt32(memkb)/1000;
            return memmb;
        }

        private void RpcTimer_Tick(object sender, EventArgs e)
        {
            if (staticMC != null)
            {
                /*if(mcOut == null) { mcOut = staticMC.StandardOutput; }
                do
                {
                    string str = mcOut.ReadLine();
                    Console.WriteLine(str);
                    if (str != null)
                    {
                        if (str.Contains("[Client thread/INFO]: Connecting to"))
                        {
                            int timeind = str.IndexOf(']');
                            string a = str.Substring(timeind + 38);
                            string b = a.Split(',')[0];
                            string newserver = "Server: " + b;
                            if (!currentServer.Equals(newserver))
                            {
                                Console.WriteLine("Connected to: \"" + b + "\"");
                            }
                            currentServer = "Server: " + b;
                        }
                    }
                } while (mcOut.Peek() > 0);*/

                // Do rich presence update
                DiscordRPC.DiscordRpcClient rpc = Data.rpccli;
                string serv = currentServer;
                if(string.IsNullOrEmpty(serv))
                {
                    serv = "Not playing on any servers.";
                }
                serv += "\n" + Data.party.GetPartyString();
                string state = "Playing as " + Data.username;
                rpc.SetPresence(new DiscordRPC.RichPresence()
                {
                    State = state,
                    Details = serv,
                    Assets = new DiscordRPC.Assets()
                    {
                        LargeImageKey = "logo",
                        LargeImageText = "TitanixClient",
                        SmallImageKey = "mc_png",
                        SmallImageText = "Playing Minecraft - " + Data.game.ToString()
                    }
                });
                //rpc.Invoke();
                //Console.WriteLine("RPC Update fired");
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern short GetKeyState(Keys nVirtKey);
        static bool GetKeyDown(Keys k)
        {
            return Convert.ToBoolean(GetKeyState(k) & 0x8000);
        }

        private void keybindsButton_Click(object sender, EventArgs e)
        {
            KeybindsForm kbf = new KeybindsForm();
            kbf.FormClosing += delegate {kbf.Dispose();};
            kbf.Show();
        }
    }
}