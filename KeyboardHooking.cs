using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TitanixClient___Forms
{
    class KeyboardHooking : IDisposable
    {
        public void Dispose()
        {
            UnhookWindowsHookEx(_keyboardHookID);
        }
        public KeyboardHooking()
        {
            _Kproc = KeyboardHookCallback;
            _keyboardHookID = SetKeyboardHook(_Kproc);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private const int WH_KEYBOARD_LL = 13;
        private LowLevelKeyboardProc _Kproc;
        private static IntPtr _keyboardHookID = IntPtr.Zero;
        private static IntPtr SetKeyboardHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        private delegate IntPtr LowLevelKeyboardProc
            (int nCode, IntPtr wParam, IntPtr lParam);
        private IntPtr KeyboardHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)0x100) // WM_KEYDOWN
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Keys key = (Keys)vkCode;
                HookKeyPressArgs args = new HookKeyPressArgs(key);
                OnHookKeyPressed?.Invoke(args);
            }
            return CallNextHookEx(_keyboardHookID, nCode, wParam, lParam);
        }

        // ----------------------------------------------------------------------------
        
        public delegate void HookKeyPressEventHandler(HookKeyPressArgs args);
        public event HookKeyPressEventHandler OnHookKeyPressed;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

        public static void SendCTRLUp(IntPtr hwnd)
        {
            int WM_KEYUP = 0x0101;
            SendMessage(hwnd, WM_KEYUP, (int)Keys.LControlKey, IntPtr.Zero);
            SendMessage(hwnd, WM_KEYUP, (int)Keys.RControlKey, IntPtr.Zero);
        }
    }
    class HookKeyPressArgs : EventArgs
    {
        public Keys pressed;
        public HookKeyPressArgs(Keys k)
        {
            pressed = k;
        }
    }
}
