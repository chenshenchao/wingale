using System;
using System.Runtime.InteropServices;

namespace Wingale.Winnt
{
    public static class Kernel32
    {
        public const int CREATE_BREAKAWAY_FROM_JOB = 0x01000000;
        public const int CREATE_DEFAULT_ERROR_MODE = 0x04000000;
        public const int CREATE_NEW_CONSOLE = 0x00000010;
        public const int CREATE_NEW_PROCESS_GROUP = 0x00000200;
        public const int CREATE_NO_WINDOW = 0x08000000;
        public const int CREATE_PROTECTED_PROCESS = 0x00040000;
        public const int CREATE_PRESERVE_CODE_AUTHZ_LEVEL = 0x02000000;
        public const int CREATE_SECURE_PROCESS = 0x00400000;
        public const int CREATE_SEPARATE_WOW_VDM = 0x00000800;
        public const int CREATE_SHARED_WOW_VDM = 0x00001000;
        public const int CREATE_SUSPENDED = 0x00000004;
        public const int CREATE_UNICODE_ENVIRONMENT = 0x00000400;
        public const int DEBUG_ONLY_THIS_PROCESS = 0x00000002;
        public const int DEBUG_PROCESS = 0x00000001;
        public const int DETACHED_PROCESS = 0x00000008;
        public const int EXTENDED_STARTUPINFO_PRESENT = 0x00080000;
        public const int INHERIT_PARENT_AFFINITY = 0x00010000;

        public const int PROCESS_CREATE_PROCESS = 0x0080;
        public const int PROCESS_CREATE_THREAD = 0x0002;
        public const int PROCESS_DUP_HANDLE = 0x0040;
        public const int PROCESS_QUERY_INFORMATION = 0x0400;
        public const int PROCESS_QUERY_LIMITED_INFORMATION = 0x1000;
        public const int PROCESS_SET_INFORMATION = 0x0200;
        public const int PROCESS_SET_QUOTA = 0x0100;
        public const int PROCESS_SUSPEND_RESUME = 0x0800;
        public const int PROCESS_TERMINATE = 0x0001;
        public const int PROCESS_VM_OPERATION = 0x0008;
        public const int PROCESS_VM_READ = 0x0010;
        public const int PROCESS_VM_WRITE = 0x0020;
        public const int SYNCHRONIZE = 0x00100000;
        public const int PROCESS_ALL_ACCESS =
            PROCESS_CREATE_PROCESS |
            PROCESS_CREATE_THREAD |
            PROCESS_DUP_HANDLE |
            PROCESS_QUERY_INFORMATION |
            PROCESS_QUERY_LIMITED_INFORMATION |
            PROCESS_SET_INFORMATION |
            PROCESS_SET_QUOTA |
            PROCESS_TERMINATE |
            PROCESS_VM_OPERATION |
            PROCESS_VM_READ |
            PROCESS_VM_WRITE;

        public const int MEM_COMMIT = 0x00001000;
        public const int MEM_RESERVE = 0x00002000;
        public const int MEM_RESET = 0x00080000;
        public const int MEM_RESET_UNDO = 0x1000000;

        public const int PAGE_EXECUTE = 0x10;
        public const int PAGE_EXECUTE_READ = 0x20;
        public const int PAGE_EXECUTE_READWRITE = 0x40;
        public const int PAGE_EXECUTE_WRITECOPY = 0x80;
        public const int PAGE_NOACCESS = 0x01;
        public const int PAGE_READONLY = 0x02;
        public const int PAGE_READWRITE = 0x04;
        public const int PAGE_WRITECOPY = 0x08;
        public const int PAGE_TARGETS_INVALID = 0x40000000;
        public const int PAGE_TARGETS_NO_UPDATE = 0x40000000;

        public const int INFINITE = -1;

        [DllImport("kernel32.dll")]
        public extern static IntPtr OpenProcess(Int32 access, bool inherit, Int32 id);

        [DllImport("kernel32.dll")]
        public extern static IntPtr CreateRemoteThread(IntPtr process, IntPtr attributes, Int32 stackSize, IntPtr address, IntPtr parameter, Int32 flags, out Int32 id);

        [DllImport("kernel32.dll")]
        public extern static Int32 WaitForSingleObject(IntPtr handle, Int32 milliseconds);

        [DllImport("kernel32.dll")]
        public extern static bool ReadProcessMemory(IntPtr process, IntPtr address, byte[] buffer, Int32 size, out Int32 number);

        [DllImport("kernel32.dll")]
        public extern static bool WriteProcessMemory(IntPtr process, IntPtr address, byte[] buffer, Int32 size, out Int32 number);

        [DllImport("kernel32.dll")]
        public extern static IntPtr GetProcAddress(IntPtr module, string name);

        [DllImport("kernel32.dll")]
        public extern static IntPtr GetModuleHandle(string name);

        [DllImport("kernel32.dll")]
        public extern static bool CloseHandle(IntPtr handle);

        [DllImport("kernel32.dll")]
        public extern static IntPtr VirtualAllocEx(IntPtr process, IntPtr address, Int32 size, Int32 allcation, Int32 protect);

        [DllImport("kernel32.dll")]
        public extern static bool VirtualFreeEx(IntPtr process, IntPtr address, Int32 size, Int32 type);
    }
}