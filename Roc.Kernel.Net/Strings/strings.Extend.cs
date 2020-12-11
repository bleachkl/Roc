using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roc.Kernel.Attributes;

namespace Roc.Kernel
{
    /// <summary>
    /// 常用字符定义
    /// </summary>
    public static partial class strings
    {
        /// <summary>
        /// Tab /t
        /// </summary>
        public static string Tab { get; } = "\t";
        /// <summary>
        /// Null
        /// </summary>
        public static string Null { get; } = "Null";

        /// <summary>
        /// null
        /// </summary>
        public static string @null { get; } = "null";
        /// <summary>
        /// 换行并回车
        /// </summary>
        public static string EndNewRow { get; } = "\r\n";

        /// <summary>
        /// 
        /// </summary>
        public static string DateTimeFormat { get; } = "yyyy-MM-dd HH:mm:ss";
    }
}
