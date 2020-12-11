using System;
using System.Linq;

namespace Roc.Kernel
{
    /// <summary>
    /// 是否是一个类
    /// </summary>
    public static class chars
    {
        /// <summary>
        /// 单引号 '
        /// </summary>
        public static char ENSingleQuotation { get; } = Char.Parse("'");
        /// <summary>
        /// 新行 \n
        /// </summary>
        public static char NewRow { get; } = Char.Parse("\n");
        /// <summary>
        /// 换行 \r
        /// </summary>
        public static char RowEnd { get; } = Char.Parse("\r");
        /// <summary>
        /// 英文正斜杠 /
        /// </summary>
        public static char ENForwardSlash { get; } = Char.Parse("/");

        //backslash
        /// <summary>
        /// 英文反斜杠 \
        /// </summary>
        public static char ENBackSlash { get; } = Char.Parse("\\");
        /// <summary>
        /// 英文双引号 "
        /// </summary>
        public static char ENDoubleQuotationMarks { get; } = Char.Parse("\"");
        /// <summary>
        /// 方括号左 [
        /// </summary>
        public static char ENSquareBracketLeft { get; } = Char.Parse("[");
        /// <summary>
        /// 方括号右 ]
        /// </summary>
        public static char ENSquareBracketRight { get; } = Char.Parse("]");
        /// <summary>
        /// 大括号左 {
        /// </summary>
        public static char BraceLeft { get; } = Char.Parse("{");
        /// <summary>
        /// 大括号右 }
        /// </summary>
        public static char BraceRight { get; } = Char.Parse("}");
        /// <summary>
        /// 英文逗号 ,
        /// </summary>
        public static char ENComma { get; } = Char.Parse(",");
        /// <summary>
        /// 英文冒号 :
        /// </summary>
        public static char ENColon { get; } = Char.Parse(":");
        /// <summary>
        /// 英文空格 space
        /// </summary>
        public static char ENSpace { get; } = Char.Parse(" ");
        /// <summary>
        /// 英文句号 .
        /// </summary>
        public static char ENPeriod { get; } = Char.Parse(".");
        /// <summary>
        /// 与号 &
        /// </summary>
        public static char And { get; } = Char.Parse("&");
        /// <summary>
        /// 或号 |
        /// </summary>
        public static char Or { get; } = Char.Parse("|");
    }
}
