using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsClientLauncher
{
    public partial class InGameWindow : Form
    {
        bool loaded = false;
        private const string HPTK = "PWMpQGgoRZPwPmgm]l33RWEmOWn{]WXwQpX7P}Mk\\pMp]m]l";
        private const string HEAD_PATH = "mars_client\\heads\\";
        private const string FRIENDAPI = "https://api.hypixel.net/friends?key={SETHPTK}&uuid={SETUUID}";
        private const string PROFILEAPI = "https://sessionserver.mojang.com/session/minecraft/profile/{PASSPARAM}";
        private string HPTK_A()
        {
            char[] TSH = HPTK.ToCharArray();
            StringBuilder BUFFER = new StringBuilder();

            for (int i = 0; i < TSH.Length; i++)
            {
                byte DAT = (byte)TSH[i];
                DAT -= 3;
                TSH[i] = (char)DAT;
            }
            string UNENC = string.Join("", TSH);
            byte[] KB = Convert.FromBase64String(UNENC);
            return Encoding.Default.GetString(KB);
        }

        public int darken = 30;
        public bool open = false;
        public InGameWindow()
        {
            InitializeComponent();

            string trimmed = HEAD_PATH.TrimEnd('\\');
            if (!Directory.Exists(trimmed))
                Directory.CreateDirectory(trimmed);
        }
        public void ToggleVisible()
        {
            open = !open;

            sizeUpdater_Tick(null, null);

            if (open)
            {
                if (BackgroundImage != null)
                {
                    BackgroundImage.Dispose();
                    BackgroundImage = null;
                }
                BackgroundImage = GetMCWindowImage();
                if (!loaded)
                {
                    JObject structure = Post(FRIENDAPI, null);
                    JArray entries = structure["records"] as JArray;

                    foreach(var friend in entries)
                    {
                        string fUUID = friend["uuidReceiver"].ToString();
                        HypixelFriend newFriend = new HypixelFriend(fUUID);
                        Data.player.AddFriend(newFriend);
                    }

                    loaded = true;
                }
            }
            if(!open)
            {
                if (BackgroundImage != null)
                {
                    BackgroundImage.Dispose();
                    BackgroundImage = null;
                }
            }
        }
        public void NowParented()
        {
            sizeUpdater.Start();
        }
        public void sizeUpdater_Tick(object sender, EventArgs e)
        {
            Location = new Point(-8, -31);
            if (open)
            {
                RECT size = new RECT();
                GetWindowRect(Data.mcWindow, out size);
                Size = new Size(
                    (size.Right - size.Left),
                    (size.Bottom - size.Top));
            } else
            {
                Size = new Size(0, 0);
            }
        }
        private void InGameWindow_Resize(object sender, EventArgs e)
        {
            friendsList.Width = Width / 2;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
        
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        Bitmap GetMCWindowImage()
        {
            IntPtr processId = Data.mcWindow;
            IntPtr src = InGameUser32.GetWindowDC(processId);

            RECT rct = new RECT();
            InGameUser32.GetWindowRect(processId, ref rct);

            int w, h;
            w = rct.Right - rct.Left;
            h = rct.Bottom - rct.Top;

            IntPtr destPtr = InGameGdi32.CreateCompatibleDC(src);
            IntPtr bmPtr = InGameGdi32.CreateCompatibleBitmap(src, w, h);
            IntPtr oldW = InGameGdi32.SelectObject(destPtr, bmPtr);

            InGameGdi32.BitBlt(destPtr, 0, 0, w, h, src, 0, 0, 13369376 /*SRCCOPY*/);
            InGameGdi32.SelectObject(destPtr, oldW);
            InGameGdi32.DeleteDC(destPtr);
            InGameUser32.ReleaseDC(processId, src);

            Bitmap temp = Image.FromHbitmap(bmPtr);
            InGameGdi32.DeleteObject(bmPtr);

            var gb = new GaussianBlur(temp);
            var res = gb.Process(5, darken);

            /* If you're an internet user looking through the src for MarsClient, I guess I should explain why I'm
             * calling GC.Collect(). You should never call this function unless you think you know better than the
             * Auto-GC, which in most cases you don't, but here the GaussianBlur object takes up about 4x-5x the
             * memory of a typical Bitmap object which, if not IMMEDIATELY collected will cause a crash on worse
             * systems. Therefore in this specific case it IS valid to call GC.Collect() on the GaussianBlur object. */
            gb = null;
            GC.Collect();

            return res;
        }
        JObject Post(string API, string param)
        {
            string HPTK_L = HPTK_A();
            using (WebClient wc = new WebClient())
            {
                string processed = API.Replace("{SETHPTK}", HPTK_L)
                    .Replace("{SETUUID}", Data.mcUUID)
                    .Replace("{PASSPARAM}", param);
                string dl = wc.DownloadString(processed);
                return JObject.Parse(dl);
            }
        }
        JArray PostArray(string API, string param)
        {
            string HPTK_L = HPTK_A();
            using (WebClient wc = new WebClient())
            {
                string processed = API.Replace("{SETHPTK}", HPTK_L)
                    .Replace("{SETUUID}", Data.mcUUID)
                    .Replace("{PASSPARAM}", param);
                string dl = wc.DownloadString(processed);
                return JArray.Parse(dl);
            }
        }

        // Update next friend.
        private void friendUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (Data.player == null)
                return;

            HypixelSelf self = Data.player;
            HypixelFriend? _f = self.GetNextNeededUsername();
            if(_f.HasValue)
            {
                // Fetch username from UUID.
                HypixelFriend f = _f.Value;
                string UUID = f.UUID;
                JObject items = Post(PROFILEAPI, UUID);
                string username = items["name"].ToString();

                string saved = HEAD_PATH + UUID + ".png";
                string savedFull = HEAD_PATH + UUID + "_FULL.png";

                if (!File.Exists(saved))
                {
                    // Contains skin information encoded in Base64.
                    string infoB64 = items["properties"][0]["value"].ToString();
                    byte[] infoBytes = Convert.FromBase64String(infoB64);
                    string info = Encoding.Default.GetString(infoBytes);
                    JToken textures = JObject.Parse(info)["textures"];
                    Bitmap loadedSkin = null; bool hasSkin = true;
                    // SKIN field is missing if no skin.
                    try { string _ = textures["SKIN"].ToString(); } catch (Exception) { hasSkin = false; }
                    if (hasSkin)
                    {
                        using (WebClient wc = new WebClient())
                        {
                            wc.DownloadFile(textures["SKIN"]["url"].ToString(), savedFull);
                            using (Image img = Image.FromFile(savedFull))
                            {
                                loadedSkin = new Bitmap(8, 8);
                                using (Graphics gr = Graphics.FromImage(loadedSkin))
                                {
                                    gr.DrawImage(img, 0, 0, new Rectangle
                                        (8, 8, 8, 8), GraphicsUnit.Pixel);
                                }
                            }
                        }
                    }
                    else
                    {
                        // Just make it a black head.
                        loadedSkin = new Bitmap(8, 8);
                        using (var g = Graphics.FromImage(loadedSkin))
                            g.FillRectangle(Brushes.Black, 0, 0, 8, 8);
                    }

                    using (loadedSkin)
                    using (Bitmap temp = new Bitmap(loadedSkin))
                        temp.Save(saved);
                }

                f.SetName(username);
                self.SetNextNeededUsername(f);
            }
        }
    }
    public static class InGameUser32
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref InGameWindow.RECT rect);
        [DllImport("user32.dll")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetCursorPos(int x, int y);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetCursorPos(out InGameGdi32.POINT lpPoint);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
    }
    public class InGameGdi32
    {
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjectSource, int nXSrc, int nYSrc, int dwRop);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);
        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hDC);
        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }
    }
    public class GaussianBlur
    {
        private int[] _alpha;
        private int[] _red;
        private int[] _green;
        private int[] _blue;

        private int _width;
        private int _height;

        private ParallelOptions _pOptions = new ParallelOptions { MaxDegreeOfParallelism = 16 };

        public GaussianBlur(Bitmap image)
        {
            var rct = new Rectangle(0, 0, image.Width, image.Height);
            var source = new int[rct.Width * rct.Height];
            var bits = image.LockBits(rct, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(bits.Scan0, source, 0, source.Length);
            image.UnlockBits(bits);

            _width = image.Width;
            _height = image.Height;

            image.Dispose();

            _alpha = new int[_width * _height];
            _red = new int[_width * _height];
            _green = new int[_width * _height];
            _blue = new int[_width * _height];

            Parallel.For(0, source.Length, _pOptions, i =>
            {
                _alpha[i] = (int)((source[i] & 0xff000000) >> 24);
                _red[i] = (source[i] & 0xff0000) >> 16;
                _green[i] = (source[i] & 0x00ff00) >> 8;
                _blue[i] = (source[i] & 0x0000ff);
            });
        }

        public Bitmap Process(int radial, int darken)
        {
            var newAlpha = new int[_width * _height];
            var newRed = new int[_width * _height];
            var newGreen = new int[_width * _height];
            var newBlue = new int[_width * _height];
            var dest = new int[_width * _height];

            Parallel.Invoke(
                () => gaussBlur_4(_alpha, newAlpha, radial),
                () => gaussBlur_4(_red, newRed, radial),
                () => gaussBlur_4(_green, newGreen, radial),
                () => gaussBlur_4(_blue, newBlue, radial));

            _alpha = null;
            _red = null;
            _green = null;
            _blue = null;

            Parallel.For(0, dest.Length, _pOptions, i =>
            {
                if (newAlpha[i] > 255) newAlpha[i] = 255;
                if (newRed[i] > 255) newRed[i] = 255;
                if (newGreen[i] > 255) newGreen[i] = 255;
                if (newBlue[i] > 255) newBlue[i] = 255;

                newRed[i] -= darken;
                newGreen[i] -= darken;
                newBlue[i] -= darken;

                if (newAlpha[i] < 0) newAlpha[i] = 0;
                if (newRed[i] < 0) newRed[i] = 0;
                if (newGreen[i] < 0) newGreen[i] = 0;
                if (newBlue[i] < 0) newBlue[i] = 0;

                dest[i] = (int)((uint)(newAlpha[i] << 24) | (uint)(newRed[i] << 16) | (uint)(newGreen[i] << 8) | (uint)newBlue[i]);
            });

            var image = new Bitmap(_width, _height);
            var rct = new Rectangle(0, 0, image.Width, image.Height);
            var bits2 = image.LockBits(rct, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            Marshal.Copy(dest, 0, bits2.Scan0, dest.Length);
            image.UnlockBits(bits2);

            return image;
        }

        private void gaussBlur_4(int[] source, int[] dest, int r)
        {
            var bxs = boxesForGauss(r, 3);
            boxBlur_4(source, dest, _width, _height, (bxs[0] - 1) / 2);
            boxBlur_4(dest, source, _width, _height, (bxs[1] - 1) / 2);
            boxBlur_4(source, dest, _width, _height, (bxs[2] - 1) / 2);
        }

        private int[] boxesForGauss(int sigma, int n)
        {
            var wIdeal = Math.Sqrt((12 * sigma * sigma / n) + 1);
            var wl = (int)Math.Floor(wIdeal);
            if (wl % 2 == 0) wl--;
            var wu = wl + 2;

            var mIdeal = (double)(12 * sigma * sigma - n * wl * wl - 4 * n * wl - 3 * n) / (-4 * wl - 4);
            var m = Math.Round(mIdeal);

            var sizes = new List<int>();
            for (var i = 0; i < n; i++) sizes.Add(i < m ? wl : wu);
            return sizes.ToArray();
        }

        private void boxBlur_4(int[] source, int[] dest, int w, int h, int r)
        {
            for (var i = 0; i < source.Length; i++) dest[i] = source[i];
            boxBlurH_4(dest, source, w, h, r);
            boxBlurT_4(source, dest, w, h, r);
        }

        private void boxBlurH_4(int[] source, int[] dest, int w, int h, int r)
        {
            var iar = (double)1 / (r + r + 1);
            Parallel.For(0, h, _pOptions, i =>
            {
                var ti = i * w;
                var li = ti;
                var ri = ti + r;
                var fv = source[ti];
                var lv = source[ti + w - 1];
                var val = (r + 1) * fv;
                for (var j = 0; j < r; j++) val += source[ti + j];
                for (var j = 0; j <= r; j++)
                {
                    val += source[ri++] - fv;
                    dest[ti++] = (int)Math.Round(val * iar);
                }
                for (var j = r + 1; j < w - r; j++)
                {
                    val += source[ri++] - dest[li++];
                    dest[ti++] = (int)Math.Round(val * iar);
                }
                for (var j = w - r; j < w; j++)
                {
                    val += lv - source[li++];
                    dest[ti++] = (int)Math.Round(val * iar);
                }
            });
        }

        private void boxBlurT_4(int[] source, int[] dest, int w, int h, int r)
        {
            var iar = (double)1 / (r + r + 1);
            Parallel.For(0, w, _pOptions, i =>
            {
                var ti = i;
                var li = ti;
                var ri = ti + r * w;
                var fv = source[ti];
                var lv = source[ti + w * (h - 1)];
                var val = (r + 1) * fv;
                for (var j = 0; j < r; j++) val += source[ti + j * w];
                for (var j = 0; j <= r; j++)
                {
                    val += source[ri] - fv;
                    dest[ti] = (int)Math.Round(val * iar);
                    ri += w;
                    ti += w;
                }
                for (var j = r + 1; j < h - r; j++)
                {
                    val += source[ri] - source[li];
                    dest[ti] = (int)Math.Round(val * iar);
                    li += w;
                    ri += w;
                    ti += w;
                }
                for (var j = h - r; j < h; j++)
                {
                    val += lv - source[li];
                    dest[ti] = (int)Math.Round(val * iar);
                    li += w;
                    ti += w;
                }
            });
        }
    }
}
