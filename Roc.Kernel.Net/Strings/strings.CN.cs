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
        //© № ℡ ⚯ ™ ® ※ 
        //意大利 ₤  卢布日常使用₨
        #region 货币符号 CurrencySymbol Ұ CS_
        ///// <summary>
        ///// 芬尼 100芬尼=1马克 DEM ₰
        ///// </summary>
        //[Sign("Currency_Symbol_DEM")]
        //public static string CS_DEM { get; } = "₰";
        ///// <summary>
        ///// 芬尼 100芬尼=1马克 DEM ₰
        ///// </summary>
        //[Sign("Currency_Symbol_DEM")]
        //public static string CS_DEM { get; } = "₰";
        /// <summary>
        /// 人名币符号CNY RMB Ұ
        /// </summary>
        [Sign("Currency_Symbol_CNY")]
        public static string CS_CNY { get; } = "Ұ";

        /// <summary>
        /// 欧元 EUR €
        /// </summary>
        [Sign("Currency_Symbol_EUR")]
        public static string CS_EUR { get; } = "€";       

        /// <summary>
        /// 美元符号 $ Dollars
        /// </summary>
        [Sign("Currency_Symbol_USD")]
        public static string CS_USD { get; } = "$";

        /// <summary>
        /// 英镑符号 ￡
        /// </summary>
        [Sign("Currency_Symbol_BGN")]
        public static string CS_BGN { get; } = "£";
        /// <summary>
        /// 日元 ¥
        /// </summary>
        [Sign("Currency_Symbol_JPY")]
        public static string CS_JPY { get; } = "¥";
        /// <summary>
        /// 韩元 ₩
        /// </summary>
        [Sign("Currency_Symbol_USD")]
        public static string CS_KRW { get; } = "₩";
        /// <summary>
        /// 卢布 ₽
        /// </summary>
        [Sign("Currency_Symbol_RUB")]
        public static string CS_RUB { get; } = "₽";
        /// <summary>
        /// 越南盾符号 ₫
        /// </summary>
        [Sign("Currency_Symbol_VND")]
        public static string CS_VND { get; } = "₫";
        #endregion

        #region 货币符号 CurrencyCode Ұ CC_
        ///// <summary>
        ///// 芬尼 100芬尼=1马克 DEM ₰
        ///// </summary>
        //[Sign("Currency_Code_DEM")]
        //public static string CC_DEM { get; } = "₰";
        ///// <summary>
        ///// 芬尼 100芬尼=1马克 DEM ₰
        ///// </summary>
        //[Sign("Currency_Code_DEM")]
        //public static string CC_DEM { get; } = "₰";
        /// <summary>
        /// 人名币符号CNY RMB Ұ
        /// </summary>
        [Sign("Currency_Code_CNY")]
        public static string CC_CNY { get; } = "CNY";

        /// <summary>
        /// 欧元 EUR €
        /// </summary>
        [Sign("Currency_Code_EUR")]
        public static string CC_EUR { get; } = "EUR";

        /// <summary>
        /// 美元符号 $ Dollars
        /// </summary>
        [Sign("Currency_Code_USD")]
        public static string CC_USD { get; } = "USD";

        /// <summary>
        /// 英镑符号 ￡
        /// </summary>
        [Sign("Currency_Code_BGN")]
        public static string CC_BGN { get; } = "BGN";
        /// <summary>
        /// 日元 ¥
        /// </summary>
        [Sign("Currency_Code_JPY")]
        public static string CC_JPY { get; } = "JPY";
        /// <summary>
        /// 韩元 ₩
        /// </summary>
        [Sign("Currency_Code_USD")]
        public static string CC_KRW { get; } = "KRW";
        /// <summary>
        /// 卢布 ₽
        /// </summary>
        [Sign("Currency_Code_RUB")]
        public static string CC_RUB { get; } = "RUB";
        /// <summary>
        /// 越南盾符号 ₫
        /// </summary>
        [Sign("Currency_Code_VND")]
        public static string CC_VND { get; } = "VND";
        #endregion
    }
}
