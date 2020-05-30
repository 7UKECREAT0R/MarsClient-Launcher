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

namespace MarsClientLauncher
{
    public partial class MainLauncher : UserControl
    {
        public static readonly string titanixLogoURL = "https://i.imgur.com/a2Bc87X.png";

        internal static Process staticMC = null;
        internal static Thread mcThread = null;

        public bool minecraftClosed = false;

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
                IntPtr regionHandle = CreateRoundRectRgn(0, 0, dim.Width, dim.Height, radius, radius);
                Region clone = Region.FromHrgn(regionHandle);
                DeleteObject(regionHandle);
                return clone;
            } catch(Exception)
            {
                return null;
            }
        }

        public MainLauncher()
        {
            InitializeComponent();
            launchButton.Region = RoundedRect(20, launchButton.Size);

            timer1.Start();
            rpcTimer.Start();
        }

        private void MainLauncher_Paint(object sender, PaintEventArgs e)
        {
            //var logo = Properties.Resources.titanix_logo;
            //e.Graphics.DrawImage(logo, new Rectangle(40, 25, divideRound(logo.Width, 3), divideRound(logo.Height, 3)));
        }
        public int divideRound(double a, double b)
        {
            return (int)Math.Round(a / b);
        }
        public static int Lerp(int a, int b, double t)
        {
            return (int)Math.Round((1 - t) * a + t * b);
        }
        private void launchButton_Click(object sender, EventArgs e)
        {
            string sptxt = Data.serverIP;
            if (!string.IsNullOrEmpty(sptxt))
            {
                File.WriteAllText("mars_client\\serverip.ser", sptxt);
            } else
            {
                File.WriteAllText("mars_client\\serverip.ser", "");
            }
            object _version = Data.versionString;
            if(_version == null)
            {
                MessageBox.Show("Please select a version!", "Mars", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string version = (string)_version;
            File.WriteAllText("mars_client\\version.ser", version);
            CMLauncher launcher = Data.launcher;
            bool forge = version.ToLower().Contains("forge");

            OutputManager.ShowConsoleWindow(true);
            Console.WriteLine("[MARS] Setting up launch arguments... Please wait!");

            MSession ssh;
            if (!Data.offline)
            {
                ssh = new MSession();
                Type editor = typeof(MSession);
                editor.GetField("<ClientToken>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(ssh, Data.clientToken);
                editor.GetField("<AccessToken>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(ssh, Data.accessToken);
                editor.GetField("<Username>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(ssh, Data.username);
                editor.GetField("<UUID>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(ssh, Data.mcUUID);
            } else
            {
                string username = Data.username;
                ssh = MSession.GetOfflineSession(username);
            }

            Console.WriteLine("[MARS] Successfully created session.");

            MLaunchOption options = new MLaunchOption()
            {
                JavaPath = "java.exe",
                MaximumRamMb = GetInstalledMemoryMB() / 2,
                Session = ssh,

                VersionType = version,
                GameLauncherName = "MarsClient",
                GameLauncherVersion = "1.5",
            };

            Console.WriteLine("[MARS] Assigned launch options.");

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

            Console.WriteLine("[MARS] Located target profile. Launching...");
            Console.WriteLine("[MARS] Moving to new thread...");

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
                    rpcTimer.Stop();
                    Data.rpccli.Dispose();
                    Invoke((MethodInvoker)delegate
                    {
                        minecraftClosed = true;
                    });
                    mcThread.Abort();
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
            }));
            mcThread.Start(launch);

            int launchWaits = 0;
            while (staticMC == null)
            {
                launchWaits++;
                Console.WriteLine("[MARS] Waiting for process to launch... #{0}", launchWaits);
                Thread.Sleep(250);
            }

            Console.WriteLine("[MARS] Waiting for main window handle...");
            Data.mcProcess = staticMC;
            while (staticMC.MainWindowHandle == IntPtr.Zero)
                Thread.Sleep(100);
            Data.mcWindow = staticMC.MainWindowHandle;

            Console.WriteLine("\n\n[MARS] Got main window handle. Attaching UI framework...");
            Console.WriteLine("[MARS] Building window...\n\n");

            InGameWindow igw = new InGameWindow();
            Data.hud = igw;
            igw.Show();
            SetParent(igw.Handle, Data.mcWindow);
            igw.NowParented();

            Console.WriteLine("[MARS] Begun window message pump.");
            Console.WriteLine("[MARS] Fetching HypixelSelf info...");

            if (File.Exists("mars_client\\hypixelself.ser"))
                Data.player = HypixelSelf.Deserialize(File.ReadAllText
                    ("mars_client\\hypixelself.ser"));

            Console.WriteLine("[MARS] Loaded, if any.\n\n");

            Console.WriteLine("[MARS] Finished initialization.");
        }

        IntPtr minecraftHWND = IntPtr.Zero; // Data.mcProcess is the same.
        private void Hook_OnHookKeyPressed(HookKeyPressArgs args)
        {
            if(minecraftHWND.Equals(IntPtr.Zero))
                minecraftHWND = staticMC.MainWindowHandle;

            IntPtr fore = GetForegroundWindow();

            if(Data.hud != null)
            {
                if (!minecraftHWND.Equals(fore)
                    && !Data.hud.Handle.Equals(fore)) return;
            } else
                if (!minecraftHWND.Equals(fore)) return;

            

            bool ctrlDown = GetKeyDown(Keys.LControlKey)
                || GetKeyDown(Keys.RControlKey);
            if (!ctrlDown) return;

            foreach (Keybind kb in Data.keybinds.keybinds)
            {
                if (kb.key == args.pressed)
                {
                    string text = kb.game.gameInternalName;
                    
                    if(Data.hud != null && text.Equals
                        (KeybindManager.INTERN_GUI))
                    {
                        Data.hud.ToggleVisible();
                        continue;
                    }

                    Thread.Sleep(50);
                    SendKeys.SendWait("/");
                    Thread.Sleep(50);
                    Clipboard.SetText(text);
                    SendKeys.SendWait("v");
                    Thread.Sleep(50);
                    SendKeys.SendWait("{ENTER}");
                    break;
                }
            }
        }

        private void signout_Click(object sender, EventArgs e)
        {
            if(File.Exists("mars_client\\accessToken.tok"))
                File.Delete("mars_client\\accessToken.tok");

            if (File.Exists("mars_client\\uuid.tok"))
                File.Delete("mars_client\\uuid.tok");

            Data.accessToken = ""; Data.mojangUUID = "";
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
                lbr?.Dispose();
                launchButton.Region = RoundedRect(buttonCurrentRoundness, launchButton.Size);
            }
        }

        private void MainLauncher_Load(object sender, EventArgs e)
        {
            string path = Minecraft.GetOSDefaultPath();
            Data.MC_OS_PATH = path;
            CMLauncher launcher = new CMLauncher(path);
            launcher.UpdateProfiles();
            Data.launcher = launcher;
            if(File.Exists("mars_client\\serverip.ser"))
            {
                string ip = File.ReadAllText("mars_client\\serverip.ser");
                Data.serverIP = ip;
            }
            if (File.Exists("mars_client\\version.ser"))
            {
                string ver = File.ReadAllText("mars_client\\version.ser");
                Data.versionString = ver;
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
                if (Data._usingRichPresence)
                {
                    // Do rich presence update.
                    DiscordRPC.DiscordRpcClient rpc = Data.rpccli;
                    string serv = "Details hidden.";
                    if (Data._showServerIP)
                    {
                        serv = currentServer;
                        if (string.IsNullOrEmpty(serv))
                            serv = "Not playing on any servers.";
                    }
                    if (Data._showPartyInfo)
                    {
                        if (Data._showServerIP)
                            serv += "\n" + Data.party.GetPartyString();
                        else
                            serv = Data.party.GetPartyString();
                    }
                    string state = "Playing Minecraft.";
                    if (Data._showUsername)
                    {
                        state = "Playing as " + Data.username;
                    }
                    string smallImageText = "Playing Minecraft";
                    if(Data._showGamePlaying)
                        smallImageText += " - " + Data.game.ToString();
                    rpc.SetPresence(new DiscordRPC.RichPresence()
                    {
                        State = state,
                        Details = serv,
                        Assets = new DiscordRPC.Assets()
                        {
                            LargeImageKey = "logo",
                            LargeImageText = "MarsClient",
                            SmallImageKey = "mc_png",
                            SmallImageText = smallImageText
                        }
                    });
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern short GetKeyState(Keys nVirtKey);

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        static bool GetKeyDown(Keys k)
        {
            return Convert.ToBoolean(GetKeyState(k) & 0x8000);
        }
        private void keybindsButton_Click(object sender, EventArgs e)
        {
            SettingsMenu stm = new SettingsMenu();
            stm.FormClosing += delegate {stm.Dispose();};
            stm.Show();
        }
    }
}