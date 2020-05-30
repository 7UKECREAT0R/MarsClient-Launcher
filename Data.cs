using CmlLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsClientLauncher
{
    /*
     * QUICK IDEAS
     * ingame GUI via window attaching that has:
     *     friends list support
     *     adding/removing people
     *     quick partying
     *     private messages that integrate with the game like steam overlay
     *     multiple pm windows at once
     *     
     */
    static class Data
    {
        public static string MC_OS_PATH         = null;
        public static CMLauncher launcher       = null;
        public static Process mcProcess         = null;
        public static IntPtr mcWindow    = IntPtr.Zero;
        public static InGameWindow hud          = null;

        public static KeyboardHooking hook      = null;
        public static KeybindManager keybinds   = null;

        public static HypixelParty party    = new HypixelParty();
        public static HypixelGame game      = new HypixelGame();
        public static HypixelSelf player    = new HypixelSelf();

        public static bool _usingRichPresence   = true;
        public static bool _showServerIP        = true;
        public static bool _showGamePlaying     = true;
        public static bool _showPartyInfo       = true;
        public static bool _showUsername        = true;

        public static string accessToken        = "";
        public static string clientToken        = "";
        public static string mojangUUID         = "";
        public static string mcUUID             = "";
        public static string username           = "";

        public static string serverIP           = "";
        public static string versionString      = "";

        public static bool offline              = false;

        public static DiscordRPC
            .DiscordRpcClient rpccli            = null;
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
