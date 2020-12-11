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
    public partial interface IPropertyChanged : INotifyPropertyChanged
    {        

        /// <summary>
        /// 是否允许执行属性变化事件
        /// </summary>
        bool EnabledEventExtPropertyChanged { get; set; }

        /// <summary>
        /// 在属性赋值之后前触发增强事件
        /// </summary>
        event ExtendPropertyChangedEventHandle ExtPropertyChanged;

        /// <summary>
        /// 在属性赋值之后增强触发动作
        /// </summary>
        /// <param name="newValue">新值</param>
        /// <param name="oldValue">旧值</param>
        /// <param name="propertyName">属性名称</param>
        void OnExtendPropertyChanged(object newValue, object oldValue, [CallerMemberName] string propertyName = "");

        /// <summary>
        /// 允许实现界面
        /// </summary>
        bool EnabledNotify { get; set; }

        /// <summary>
        /// 通知界面动作
        /// </summary>
        /// <returns></returns>
        void OnNotified([CallerMemberName] string propertyName = "");
    }
}
