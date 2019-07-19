using System;
using System.Runtime.InteropServices;

namespace Wingale
{
    public static class User32
    {
        [DllImport("User32.dll")]
        public extern static IntPtr FindWindow(string className, string windowName);

        [DllImport("User32.dll")]
        public extern static IntPtr FindWindowEx(IntPtr parent, IntPtr childAfter, string className, string windowName);

        [DllImport("User32.dll")]
        public extern static IntPtr PostMessage(IntPtr window, Int32 message, Int32 wParam, Int32 lParam);
    }
}
