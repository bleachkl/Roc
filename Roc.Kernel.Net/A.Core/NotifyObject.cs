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
    /// 实现属性通知的增强的Object
    /// 默认初始化时自动生成Guid
    /// 开启只有在属性变化时执行 OnlyExecuteOnPropertyChanged = true
    /// 开启属性变化抓取 GrabChangedProperties = true
    /// 不开启开启属性变化值抓取 GrabChangedPropertiesValues = false
    /// 不开启开启属性变化前值抓取 GrabChangedPropertiesPreviewValues = false
    /// 开启属性变化前事件触发 EnabledEventBeforePropertySet = true
    /// 开启属性变化后事件触发 EnabledEventExtPropertyChanged = true
    /// 不开启自动通知界面 EnabledNotify = true
    /// </summary>
    public partial class NotifyObject : ExtendObject
    {
        /// <summary>
        /// 实现属性通知的增强的Object
        /// 默认初始化时自动生成Guid
        /// 开启只有在属性变化时执行 OnlyExecuteOnPropertyChanged = true
        /// 开启属性变化抓取 GrabChangedProperties = true
        /// 不开启开启属性变化值抓取 GrabChangedPropertiesValues = false
        /// 不开启开启属性变化前值抓取 GrabChangedPropertiesPreviewValues = false
        /// 开启属性变化前事件触发 EnabledEventBeforePropertySet = true
        /// 开启属性变化后事件触发 EnabledEventExtPropertyChanged = true
        /// 不开启自动通知界面 EnabledNotify = true
        /// </summary>
        public NotifyObject() : base(true, true)
        {

        }
        /// <summary>
        /// 实现属性通知的增强的Object
        /// </summary>
        /// <param name="generateGuid">是否生成Guid</param>
        public NotifyObject(bool generateGuid) : base(generateGuid, true)
        {
            m_Guid = generateGuid ?
                GuidHelper.GenerateGuid() : string.Empty;
        }
        /// <summary>
        /// 实现属性通知的增强的Object
        /// </summary>
        /// <param name="generateGuid">是否生成Guid</param>
        /// <param name="onlyExecuteOnPropertyChanged">是否只有在属性变化时执行</param>
        /// <param name="grabChangedProperties">是否开启属性变化抓取</param>
        /// <param name="grabChangedPropertiesValues">是否开启属性变化值抓取</param>
        /// <param name="grabChangedPropertiesPreviewValues">是否开启属性变化前值抓取</param>
        /// <param name="enabledEventBeforePropertySet">是否开启属性变化前事件触发</param>
        /// <param name="enabledEventExtPropertyChanged">是否开启属性变化后事件触发</param>
        public NotifyObject(bool generateGuid,
            bool onlyExecuteOnPropertyChanged,
            bool grabChangedProperties,
            bool grabChangedPropertiesValues,
            bool grabChangedPropertiesPreviewValues,
            bool enabledEventBeforePropertySet,
            bool enabledEventExtPropertyChanged)
        {
            m_Guid = generateGuid ?
             GuidHelper.GenerateGuid() : string.Empty;
            m_OnlyExecuteOnPropertyChanged = onlyExecuteOnPropertyChanged;
            m_GrabChangedProperties = grabChangedProperties;
            m_GrabChangedPropertiesValues = grabChangedPropertiesValues;
            m_GrabChangedPropertiesPreviewValues = grabChangedPropertiesPreviewValues;
            m_EnabledEventBeforePropertySet = enabledEventBeforePropertySet;
            m_EnabledEventExtPropertyChanged = enabledEventExtPropertyChanged;
        }
    }
}
