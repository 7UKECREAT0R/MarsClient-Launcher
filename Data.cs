using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TitanixClient___Forms
{
    static class Data
    {
        public static KeyboardHooking hook;
        public static KeybindManager keybinds;

        public static HypixelParty party = new HypixelParty();
        public static HypixelGame game = new HypixelGame();

        public static string accessToken = "";
        public static string clientToken = "";
        public static string uuid = "";
        public static string username = "";

        public static string profileuuid = "";

        public static bool offline = false;

        public static DiscordRPC.DiscordRpcClient rpccli = null;
        //public static string partySecret = "MTI4NzM0OjFpMmhuZToxMjMxMjM=";

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);
        public static Region RoundedRect(int radius, Size dim)
        {
            return Region.FromHrgn(CreateRoundRectRgn(0, 0, dim.Width, dim.Height, radius, radius));
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public static void Capture(IntPtr hwnd)
        {
            ReleaseCapture();
            SendMessage(hwnd, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
    }
}
