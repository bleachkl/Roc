using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel
{
    public static partial class strings
    {
        /// <summary>
        /// GB2312编码名称
        /// </summary>
        public static string EncodingGB2312 { get; } = "gb2312";
        /// <summary>
        /// UTF8编码名称
        /// </summary>
        public static string EncodingUTF8 { get; } = Encoding.UTF8.BodyName;
    }
}
