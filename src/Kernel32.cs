using System;
using System.Runtime.InteropServices;

namespace Wingale
{

    public static class Kernel32
    {
        [DllImport("kernel32.dll")]
        public extern static IntPtr OpenProcess(Int32 access, bool inherit, Int32 id);

        [DllImport("kernel32.dll")]
        public extern static bool ReadProcessMemory(IntPtr process, IntPtr address, byte[] buffer, Int32 size, out Int32 number);

        [DllImport("kernel32.dll")]
        public extern static bool WriteProcessMemory(IntPtr process, IntPtr address, byte[] buffer, Int32 size, out Int32 number);

        [DllImport("kernel32.dll")]
        public extern static bool CloseHandle(IntPtr handle);

        [DllImport("kernel32.dll")]
        public extern static bool VirtualAllocEx(IntPtr process, IntPtr address, Int32 size, Int16 allcation, Int16 protect);

        [DllImport("kernel32.dll")]
        public extern static bool VirtualFreeEx(IntPtr process, IntPtr address, Int32 size, Int32 type);
    }
}