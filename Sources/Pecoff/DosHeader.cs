using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wingale.Pecoff
{
    /// <summary>
    /// 
    /// </summary>
    public class DosHeader
    {
        public string Magic { get; private set; }// MZ
        public UInt16 NumberOfLastPages { get; set; }// 最后（部分）页中字节数
        public UInt16 NumberOfPages { get; set; }// 文件中的全部和部分页数
        public UInt16 NumberOfRedirectPointers { get; set; }// 重定位表中的指针数
        public UInt16 NumberOfParagraphs { get; set; }// 头部尺寸，以段落为单位
        public UInt16 MinAlloc { get; set; } // 所需的最小附加段
        public UInt16 MaxAlloc { get; set; } // 所需的最大附加段
        public UInt16 Ss { get; set; } // 初始的 SS 值（相对偏移量）
        public UInt16 Sp { get; set; } // 初始的 SP 值
        public UInt16 Csum { get; set; }// 补码校验值
        public UInt16 Ip { get; set; } // 初始的 IP 值
        public UInt16 Cs { get; set; } // 初始的 CS 值
        public UInt16 OffsetOfRedirectTable { get; set; }// 重定位表的字节偏移量
        public UInt16 OverNumber { get; set; }// 覆盖号
        public byte[] ReserveOne { get; set; }// 2 * 4 字节保留字
        public UInt16 OemId { get; set; }// OEM 标识符
        public UInt16 OemInfo { get; set; }// OEM 信息
        public byte[] ReserveTwo { get; set; }// 2 * 10 保留字
        public UInt32 OffsetOfNew { get; set; }// PE 头相对与文件的偏移量

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public DosHeader(byte[] data)
        {
            Magic = Encoding.ASCII.GetString(data, 0, 2);
            NumberOfLastPages = BitConverter.ToUInt16(data, 2);// 最后（部分）页中字节数
            NumberOfPages = BitConverter.ToUInt16(data, 4);// 文件中的全部和部分页数
            NumberOfRedirectPointers = BitConverter.ToUInt16(data, 6);// 重定位表中的指针数
            NumberOfParagraphs = BitConverter.ToUInt16(data, 8);// 头部尺寸，以段落为单位
            MinAlloc = BitConverter.ToUInt16(data, 10); // 所需的最小附加段
            MaxAlloc = BitConverter.ToUInt16(data, 12); // 所需的最大附加段
            Ss = BitConverter.ToUInt16(data, 14); // 初始的 SS 值（相对偏移量）
            Sp = BitConverter.ToUInt16(data, 16); // 初始的 SP 值
            Csum = BitConverter.ToUInt16(data, 18);// 补码校验值
            Ip = BitConverter.ToUInt16(data, 20); // 初始的 IP 值
            Cs = BitConverter.ToUInt16(data, 22); // 初始的 CS 值
            OffsetOfRedirectTable = BitConverter.ToUInt16(data, 24);// 重定位表的字节偏移量
            OverNumber = BitConverter.ToUInt16(data, 26);// 覆盖号
            ReserveOne = new byte[2 * 4]; // 2 * 4 字节保留字
            Array.Copy(data, 28, ReserveOne, 0, ReserveOne.Length);
            OemId = BitConverter.ToUInt16(data, 36);// OEM 标识符
            OemInfo = BitConverter.ToUInt16(data, 38);// OEM 信息
            ReserveTwo = new byte[2 * 10];// 2 * 10 保留字
            Array.Copy(data, 40, ReserveTwo, 0, ReserveTwo.Length);
            OffsetOfNew = BitConverter.ToUInt32(data, 60);// PE 头相对与文件的偏移量
        }
    }
}
