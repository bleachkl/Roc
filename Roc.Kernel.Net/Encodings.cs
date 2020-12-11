using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel
{
    public static class Encodings
    {
        /// <summary>
        /// GB2312文件编码
        /// </summary>
        public static Encoding GB2312 { get; } = Encoding.GetEncoding(strings.EncodingGB2312);
        /// <summary>
        /// UTF8文件编码
        /// </summary>
        public static Encoding UTF8 { get; } = Encoding.GetEncoding(strings.EncodingUTF8);
    }
}
