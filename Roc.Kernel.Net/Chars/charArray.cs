using System;
using System.Linq;

namespace Roc.Kernel
{
    /// <summary>
    /// 常用字符数组定义
    /// </summary>
    public static class charArray
    {
        /// <summary>
        /// Tab /t
        /// </summary>
        public static char[] Tab { get; } = strings.Tab.ToCharArray();
        /// <summary>
        /// 换行 \r\n
        /// </summary>
        public static char[] RowEndNew { get; } = strings.EndNewRow.ToCharArray();

        /// <summary>
        /// 英文正斜杠 /
        /// </summary>
        public static char[] ENForwardSlash { get; } = strings.ENForwardSlash.ToCharArray();

        //backslash
        /// <summary>
        /// 英文反斜杠 \
        /// </summary>
        public static char[] ENBackSlash { get; } = strings.ENBackSlash.ToCharArray();
        /// <summary>
        /// 逗号 ,
        /// </summary>
        public static char[] ENComma { get; } = strings.ENComma.ToCharArray();
        /// <summary>
        /// 分号 :
        /// </summary>
        public static char[] ENColon { get; } = strings.ENColon.ToCharArray();
        /// <summary>
        /// 句号 .
        /// </summary>
        public static char[] ENPeriod { get; } = strings.ENPeriod.ToCharArray();
        /// <summary>
        /// 与号 &
        /// </summary>
        public static char[] VSAND { get; } = strings.VSAND.ToCharArray();
        /// <summary>
        /// 或号 |
        /// </summary>
        public static char[] VSOR { get; } = strings.VSOR.ToCharArray();
    }
}
