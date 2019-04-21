using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingale.Pecoff
{
    /// <summary>
    /// 
    /// </summary>
    public class PeReader
    {
        public void Read(string path)
        {
            using (BinaryReader reader = new BinaryReader(path))
            {
                // DOS 头
                DosHeader dosHeader = new DosHeader(reader.ReadBytes(64));

                // PE 头
                byte[] pe = reader.ReadBytes(24);
                // PE\0\0 头
                UInt16 machine = BitConverter.ToUInt16(pe, 4); // 运行平台
                UInt16 numberOfSections = BitConverter.ToUInt16(pe, 6); // PE 中节的数量
                UInt32 timeDateStamp = BitConverter.ToUInt32(pe, 8); // 文件创建日期和时间
                UInt32 pointerToSymbols = BitConverter.ToUInt32(pe, 12);// 指向符号表（用于调试）
                UInt32 numberOfSymbols = BitConverter.ToUInt32(pe, 16);//符号表中的符号数量（用于调试）
                UInt16 sizeOfOptionalHeader = BitConverter.ToUInt16(pe, 20);// 扩展头结构的长度
                UInt16 characteristics = BitConverter.ToUInt16(pe, 22);// 文件属性
            }
        }
    }
}
