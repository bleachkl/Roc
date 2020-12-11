using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel
{
    /// <summary>
    /// 属性赋值前接口
    /// </summary>
    public partial interface IBeforePropertySet
    {
        /// <summary>
        /// 是否允许执行属性变化前事件
        /// </summary>
        bool EnabledEventBeforePropertySet { get; set; }

        /// <summary>
        /// 属性变化前事件
        /// </summary>
        event ExtendPropertyChangedEventHandle BeforePropertySet;

        /// <summary>
        /// 属性变化前动作
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <param name="propertyName"></param>
        void OnBeforePropertySet(object oldValue, object newValue, [CallerMemberName] string propertyName = "");
    }
}
