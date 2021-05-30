using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingale.Winnt
{
    public class Injection
    {
        /// <summary>
        /// 注入代码。
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="param"></param>
        /// <param name="program"></param>
        public void InjectCode(Int32 pid, byte[] param, byte[] program)
        {
            int number;
            IntPtr process = Kernel32.OpenProcess(Kernel32.PROCESS_ALL_ACCESS, false, pid);
            IntPtr data = Kernel32.VirtualAllocEx(process, IntPtr.Zero, param.Length, Kernel32.MEM_COMMIT, Kernel32.PAGE_READWRITE);
            Kernel32.WriteProcessMemory(process, data, param, param.Length, out number);
            IntPtr code = Kernel32.VirtualAllocEx(process, IntPtr.Zero, program.Length, Kernel32.MEM_COMMIT, Kernel32.PAGE_EXECUTE_READWRITE);
            Kernel32.WriteProcessMemory(process, data, program, program.Length, out number);
            IntPtr thread = Kernel32.CreateRemoteThread(process, IntPtr.Zero, 0, code, data, 0, out number);
            Kernel32.WaitForSingleObject(thread, Kernel32.INFINITE);
            Kernel32.CloseHandle(thread);
            Kernel32.CloseHandle(process);
        }
    }
}
