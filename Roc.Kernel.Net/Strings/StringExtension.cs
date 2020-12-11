using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel.Extensions.ForString
{
    /// <summary>
    /// 字符拓展
    /// </summary>
    public static partial class StringExtension
    {
        /// <summary>
        /// 格式化对象
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string Tostring(this object instance, bool empty = true, bool bigNull = true)
        {
            if (instance == null)
                return empty ? string.Empty :
                    (bigNull ? strings.Null : strings.@null);
            return instance.ToString();
        }
        /// <summary>
        /// 判断一个字符串是否为空
        /// 空返回true
        /// </summary>
        /// <param name="verifyStr"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string verifyStr)
        {
            return string.IsNullOrEmpty(verifyStr);
        }
        /// <summary>
        /// 判断一个StringBuilder是否为空
        /// 空返回true
        /// </summary>
        /// <param name="verifyStr"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this StringBuilder stringBuilder)
        {
            return string.IsNullOrEmpty(stringBuilder?.ToString());
        }
        /// <summary>
        /// 严格trim时的去除字符
        /// </summary>
        public static char[] TrimStrictlyChars { get; set; } = new char[]
        {
            '\r','\n','\t',' '
        };
        /// <summary>
        /// 严格trim
        /// </summary>
        /// <param name="trimStrBuilder"></param>
        /// <returns></returns>
        public static StringBuilder TrimStrictly(this StringBuilder trimStrBuilder)
        {
            return new StringBuilder(trimStrBuilder?.ToString()?.TrimStrictly());
        }
        /// <summary>
        /// 严格的trim
        /// </summary>
        /// <param name="trimStr"></param>
        /// <returns></returns>
        public static string TrimStrictly(this string trimStr)
        {
            return new string(trimStr?.ToCharArray()?.Where(x =>
            TrimStrictlyChars?.Contains(x) == false)?.ToArray() ??
            EmptyArrays.@char);
        }
        /// <summary>
        /// 将一个字符串转换为占位符形式
        /// {string}
        /// </summary>
        /// <param name="@string">要生成占位字符</param>
        /// <param name="leftPlaceholder">左侧占位符字符串</param>
        /// <param name="rightPlaceholder">右侧占位符字符串</param>
        /// <returns></returns>
        public static string ToPlaceholder(this string @string,
            string leftPlaceholder = "{",
            string rightPlaceholder = "}")
        {
            return $"{leftPlaceholder}{@string}{rightPlaceholder}";
        }
        /// <summary>
        /// 将一个StringBuilder转换为占位符形式StringBuilder
        /// {string}
        /// </summary>
        /// <param name="stringBuilder">要生成占位字符</param>
        /// <param name="leftPlaceholder">左侧占位符字符串</param>
        /// <param name="rightPlaceholder">右侧占位符字符串</param>
        /// <returns></returns>
        public static StringBuilder ToPlaceholder(this StringBuilder stringBuilder,
            string leftPlaceholder = "{",
            string rightPlaceholder = "}")
        {
            if (leftPlaceholder?.ToCharArray() is char[] leftArray)
                foreach (char @char in leftArray.Reverse())
                    stringBuilder.Insert(0, @char);
            stringBuilder.Append(rightPlaceholder);
            return stringBuilder;
        }
        /// <summary>
        /// 将一个占位符字符串转换为占位符形式
        /// 默认使用 { }
        /// {string}=>string
        /// </summary>
        /// <param name="@string">要生成占位字符</param>
        /// <param name="leftPlaceholder">左侧占位符字符串</param>
        /// <param name="rightPlaceholder">右侧占位符字符串</param>
        /// <returns></returns>
        public static string RestorePlaceholder(this string @string,
            string leftPlaceholder = "{",
            string rightPlaceholder = "}")
        {
            if (@string.Length > (leftPlaceholder?.Length + rightPlaceholder?.Length))
                if (@string.Substring(0,
                    leftPlaceholder.Length) ==
                    leftPlaceholder
                    && @string.Substring(@string.Length - rightPlaceholder.Length,
                    rightPlaceholder.Length) ==
                    rightPlaceholder)
                    return @string.Substring(leftPlaceholder.Length,
                        @string.Length - (leftPlaceholder.Length + rightPlaceholder.Length));
            return @string;
        }
        /// <summary>
        /// 将一个StringBuilder转换为占位符形式StringBuilder
        /// {stringBuilder}=>stringBuilder
        /// </summary>
        /// <param name="stringBuilder">要生成占位字符</param>
        /// <param name="leftPlaceholder">左侧占位符字符串</param>
        /// <param name="rightPlaceholder">右侧占位符字符串</param>
        /// <returns></returns>
        public static StringBuilder RestorePlaceholder(this StringBuilder stringBuilder,
            string leftPlaceholder = "{",
            string rightPlaceholder = "}")
        {
            return new StringBuilder((stringBuilder?.ToString()).RestorePlaceholder(leftPlaceholder, rightPlaceholder));
        }
    }
}
