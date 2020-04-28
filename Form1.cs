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

namespace TitanixClient___Forms
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
            SetBorderCurve(60);
            DoubleBuffered = true;

            mainLauncher1.SendToBack();

            if (!Directory.Exists("titanix_client"))
            {
                DirectoryInfo di = Directory.CreateDirectory("titanix_client");
                di.Attributes = FileAttributes.Hidden;
            }

            DiscordRpcClient cli;
            cli = new DiscordRpcClient("620414963902709760");
            //cli.RegisterUriScheme(null, null);
            //cli.OnJoinRequested += Cli_OnJoinRequested;
            cli.Initialize();
            Data.rpccli = cli;

            Data.hook = new KeyboardHooking();

            if (!File.Exists("titanix_client\\bindings.ser"))
                Data.keybinds = new KeybindManager();
            else
                Data.keybinds = KeybindManager.Deserialize(
                    File.ReadAllText("titanix_client\\bindings.ser"));
        }

        public Form1()
        {
            InitializeComponent();
        }
        public static int Lerp(int a, int b, double t)
        {
            return (int)Math.Round((a * (1.0f - t)) + (b * t));
        }
        public void SetBorderCurve(int radius)
        {
            Region r = this.Region;
            if(r != null) { r.Dispose(); }
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, radius, radius));
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
            File.WriteAllText("titanix_client\\bindings.ser", Data.keybinds.Serialize());
            Data.rpccli.Dispose();
            Data.hook.Dispose();
            if(MainLauncher.mcThread != null)
                MainLauncher.mcThread.Abort();
        }
    }
}
