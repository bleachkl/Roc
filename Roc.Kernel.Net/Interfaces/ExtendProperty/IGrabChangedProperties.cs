using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel
{
    //thick; thick and big; bulky; loudhuge
    /// <summary>
    /// 实现属性变化抓取的接口
    /// </summary>
    public interface IGrabChangedProperties
    {
        /// <summary>
        /// 是否抓取变化属性
        /// </summary>
        bool GrabChangedProperties { get; set; }

        /// <summary>
        /// 是否抓取变化属性值
        /// </summary>
        bool GrabChangedPropertiesValues { get; set; }

        /// <summary>
        /// 是否抓取变化属性变化前的值
        /// </summary>
        bool GrabChangedPropertiesPreviewValues { get; set; }

        /// <summary>
        /// 是否有变化的属性
        /// </summary>
        bool HasChangedProperties { get; }

        /// <summary>
        /// 变化的属性和值集合
        /// </summary>
        Dictionary<string, KeyValuePair<object, object>> ChangedProperties { get; set; }
    }
}
