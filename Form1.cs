using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using DiscordRPC;
using DiscordRPC.Logging;
using DiscordRPC.Events;

namespace MarsClientLauncher
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn (
                int nLeftRect, int nTopRect,
                int nRightRect, int nBottomRect,
                int nWidthEllipse, int nHeightEllipse);

        public static string username;
        public static string password;

        private void Form1_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            SetBorderCurve(10);
            DoubleBuffered = true;

            mainLauncher1.SendToBack();

            if (!Directory.Exists("mars_client"))
            {
                DirectoryInfo di = Directory.CreateDirectory("mars_client");
                di.Attributes = FileAttributes.Hidden;
            }

            DiscordRpcClient cli;
            cli = new DiscordRpcClient("620414963902709760");
            //cli.RegisterUriScheme(null, null);
            //cli.OnJoinRequested += Cli_OnJoinRequested;
            cli.Initialize();
            Data.rpccli = cli;

            Data.hook = new KeyboardHooking();

            if (!File.Exists("mars_client\\bindings.ser"))
                Data.keybinds = new KeybindManager();
            else
            {
                Data.keybinds = KeybindManager.Deserialize(
                    File.ReadAllText("mars_client\\bindings.ser"));
            }
        }

        public Form1()
        {
            InitializeComponent();
            OutputManager.ShowConsoleWindow(false);
            Opacity = 0;
        }
        public static int Lerp(int a, int b, double t)
        {
            return (int)Math.Round((a * (1.0f - t)) + (b * t));
        }
        public void SetBorderCurve(int radius)
        {
            Region r = Region;
            if(r != null) { r.Dispose(); }
            IntPtr toBeDestroyed = CreateRoundRectRgn(0, 0, Width, Height, radius, radius);
            Region = Region.FromHrgn(toBeDestroyed);
            MainLauncher.DeleteObject(toBeDestroyed);
        }
        public static void SetBorderCurve(int radius, Control ctrl)
        {
            Region r = ctrl.Region;
            if (r != null) { r.Dispose(); }
            IntPtr toBeDestroyed = CreateRoundRectRgn(0, 0, ctrl.Width, ctrl.Height, radius, radius);
            r = Region.FromHrgn(toBeDestroyed);
            ctrl.Region = r;
            MainLauncher.DeleteObject(toBeDestroyed);
            return;
        }
        public int Round(float f)
        {
            return (int)Math.Round(f);
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void minimizebutton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;


        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void MainLauncher1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText("mars_client\\bindings.ser", Data.keybinds.Serialize());
            if (Data.player != null)
                File.WriteAllText("mars_client\\hypixelself.ser", Data.player.Serialize());
            Data.rpccli.Dispose();
            Data.hook.Dispose();
            if(MainLauncher.mcThread != null)
                MainLauncher.mcThread.Abort();
            Data.mcProcess?.Dispose();
            Data.hud?.Close();
            Data.hud?.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Point orig = Location;
            Point n = orig;

            Opacity = 0.05;
            n.Y = orig.Y + 30;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.2;
            n.Y = orig.Y + 25;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.4;
            n.Y = orig.Y + 20;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.5;
            n.Y = orig.Y + 17;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.55;
            n.Y = orig.Y + 15;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.60;
            n.Y = orig.Y + 13;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.65;
            n.Y = orig.Y + 11;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.68;
            n.Y = orig.Y + 9;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.72;
            n.Y = orig.Y + 8;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.75;
            n.Y = orig.Y + 7;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.75;
            n.Y = orig.Y + 6;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.75;
            n.Y = orig.Y + 5;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.79;
            n.Y = orig.Y + 4;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.82;
            n.Y = orig.Y + 3;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.85;
            n.Y = orig.Y + 3;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.87;
            n.Y = orig.Y + 2;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.9;
            n.Y = orig.Y + 2;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.92;
            n.Y = orig.Y + 1;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.94;
            n.Y = orig.Y + 1;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.95;
            n.Y = orig.Y + 1;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.96;
            n.Y = orig.Y + 0;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.97;
            n.Y = orig.Y + 0;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.98;
            n.Y = orig.Y + 0;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 0.99;
            n.Y = orig.Y + 0;
            Location = n;
            Task.Delay(16).Wait();

            Opacity = 1.0;
            n.Y = orig.Y + 0;
            Location = n;

            animator.Stop();
        }
        private void closingTimer_Tick(object sender, EventArgs e)
        {
            if (mainLauncher1.minecraftClosed)
            {
                closingTimer.Stop();
                Close();
            }
        }
    }
}
