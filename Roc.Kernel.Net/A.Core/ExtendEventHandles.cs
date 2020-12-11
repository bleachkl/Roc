using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel
{
    /// <summary>
    /// 增强的属性变化事件
    /// </summary>
    /// <param name="sender">属性所属对象</param>
    /// <param name="newValue">新值</param>
    /// <param name="oldValue">原值</param>
    /// <param name="propertyName">出发变化的属性名称或方法名</param>
    public delegate void ExtendPropertyChangedEventHandle(object sender, object newValue, object oldValue, [CallerMemberName] string propertyName = "");

}
