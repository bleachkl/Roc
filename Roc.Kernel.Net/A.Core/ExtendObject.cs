using Roc.Kernel.Reflections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel
{
    //apex; zenith; acme; vertex
    /// <summary>
    /// 增强的Object
    /// 默认初始化时自动生成Guid
    /// 开启只有在属性变化时执行 OnlyExecuteOnPropertyChanged = true
    /// 不开启属性变化抓取 GrabChangedProperties = false
    /// 不开启属性变化值抓取 GrabChangedPropertiesValues = false
    /// 不开启属性变化前值抓取 GrabChangedPropertiesPreviewValues = false
    /// 开启属性变化前事件触发 EnabledEventBeforePropertySet = true
    /// 开启属性变化后事件触发 EnabledEventExtPropertyChanged = true
    /// 不开启自动通知界面 EnabledNotify = false
    /// 不开启
    /// </summary>
    public partial class ExtendObject : IExtendProperty
    {
        /// <summary>
        /// 异步锁
        /// </summary>
        internal static readonly object ms_AnsycLock = new object();
        /// <summary>
        /// 析构对象
        /// </summary>
        ~ExtendObject()
        {
            Dispose();
        }
        /// <summary>
        /// 释放对象占用资源
        /// </summary>
        public virtual void Dispose()
        {
            m_Guid = default;
            m_Directive = default; 
            m_HasChangedProperties = default;
            m_OnlyExecuteOnPropertyChanged = default;
            m_GrabChangedProperties = default;
            m_GrabChangedPropertiesValues = default;
            m_GrabChangedPropertiesPreviewValues = default;
            m_EnabledEventBeforePropertySet = default;
            m_EnabledEventExtPropertyChanged = default;
            m_EnabledNotify = default;
            m_ChangedProperties?.Clear();
            m_ChangedProperties = default;
        }
        /// <summary>
        /// 增强的Object
        /// 默认初始化时自动生成Guid
        /// 开启只有在属性变化时执行 OnlyExecuteOnPropertyChanged = true
        /// 开启属性变化抓取 GrabChangedProperties = true
        /// 不开启属性变化值抓取 GrabChangedPropertiesValues = false
        /// 不开启属性变化前值抓取 GrabChangedPropertiesPreviewValues = false
        /// 开启属性变化前事件触发 EnabledEventBeforePropertySet = true
        /// 开启属性变化后事件触发 EnabledEventExtPropertyChanged = true
        /// 不开启自动通知界面 EnabledNotify = false
        /// </summary>
        public ExtendObject()
        {
            ReflectionHelper.AddOrGetTypesInfosDictionary(this.GetType());
        }
        /// <summary>
        /// 增强的Object
        /// </summary>
        /// <param name="generateGuid">是否生成Guid</param>
        public ExtendObject(bool generateGuid)
        {
            m_Guid = generateGuid ? 
                GuidHelper.GenerateGuid() : string.Empty;
        }
        /// <summary>
        /// 增强的Object
        /// </summary>
        /// <param name="generateGuid">是否生成Guid</param>
        /// <param name="enabledNotify">是否开启自动通知界面</param>
        public ExtendObject(bool generateGuid,bool enabledNotify)
        {
            m_Guid = generateGuid ?
                GuidHelper.GenerateGuid() : string.Empty;
            m_EnabledNotify = enabledNotify;
        }
        /// <summary>
        /// 增强的Object
        /// </summary>
        /// <param name="generateGuid">是否生成Guid</param>
        /// <param name="onlyExecuteOnPropertyChanged">是否只有在属性变化时执行</param>
        /// <param name="grabChangedProperties">是否开启属性变化抓取</param>
        /// <param name="grabChangedPropertiesValues">是否开启属性变化值抓取</param>
        /// <param name="grabChangedPropertiesPreviewValues">是否开启属性变化前值抓取</param>
        /// <param name="enabledEventBeforePropertySet">是否开启属性变化前事件触发</param>
        /// <param name="enabledEventExtPropertyChanged">是否开启属性变化后事件触发</param>
        /// <param name="enabledNotify">是否开启自动通知界面</param>
        public ExtendObject(bool generateGuid,
            bool onlyExecuteOnPropertyChanged,
            bool grabChangedProperties,
            bool grabChangedPropertiesValues,
            bool grabChangedPropertiesPreviewValues,
            bool enabledEventBeforePropertySet,
            bool enabledEventExtPropertyChanged,
            bool enabledNotify)
        {
            m_Guid = generateGuid ?
             GuidHelper.GenerateGuid() : string.Empty;
            m_OnlyExecuteOnPropertyChanged = onlyExecuteOnPropertyChanged;
            m_GrabChangedProperties = grabChangedProperties;
            m_GrabChangedPropertiesValues = grabChangedPropertiesValues;
            m_GrabChangedPropertiesPreviewValues = grabChangedPropertiesPreviewValues;
            m_EnabledEventBeforePropertySet = enabledEventBeforePropertySet;
            m_EnabledEventExtPropertyChanged = enabledEventExtPropertyChanged;
            m_EnabledNotify = enabledNotify;
        }
        /// <summary>    
        ///  Guid
        ///  protected internal 
        /// </summary>
        protected internal string m_Guid = GuidHelper.GenerateGuid();
        /// <summary>
        /// Guid
        /// </summary>
        public virtual string Guid
        {
            get => m_Guid;
            set => Set(ref m_Guid, value);
        }
        /// <summary>    
        ///  操作指令
        ///  protected internal 
        /// </summary>
        protected internal Directives m_Directive;
        /// <summary>
        /// 操作指令
        /// </summary>
        public virtual Directives Directive
        {
            get => m_Directive;
            set => Set(ref m_Directive, value);
        }
        /// <summary>    
        ///  变化的属性集合
        ///  protected internal 
        /// </summary>
        protected internal Dictionary<string, KeyValuePair<object, object>> m_ChangedProperties = 
            new Dictionary<string, KeyValuePair<object, object>>();
        /// <summary>
        /// 变化的属性集合
        /// </summary>
        public virtual Dictionary<string, KeyValuePair<object, object>> ChangedProperties
        {
            get => m_ChangedProperties;
            set => Set(ref m_ChangedProperties, value);
        }
        /// <summary>    
        ///  是否抓取变化属性
        ///  protected internal 
        /// </summary>
        protected internal bool m_GrabChangedProperties = false;
        /// <summary>
        /// 是否抓取变化属性
        /// </summary>
        public virtual bool GrabChangedProperties
        {
            get => m_GrabChangedProperties;
            set => Set(ref m_GrabChangedProperties, value);
        }
        /// <summary>    
        ///  是否抓取变化属性值
        ///  protected internal 
        /// </summary>
        protected internal bool m_GrabChangedPropertiesValues = false;
        /// <summary>
        /// 是否抓取变化属性值
        /// </summary>
        public virtual bool GrabChangedPropertiesValues
        {
            get => m_GrabChangedPropertiesValues;
            set => Set(ref m_GrabChangedPropertiesValues, value);
        }
        /// <summary>    
        ///  是否抓取变化属性值
        ///  protected internal 
        /// </summary>
        protected internal bool m_GrabChangedPropertiesPreviewValues = false;
        /// <summary>
        /// 是否抓取变化属性变化前的值
        /// </summary>
        public virtual bool GrabChangedPropertiesPreviewValues
        {
            get => m_GrabChangedPropertiesPreviewValues;
            set => Set(ref m_GrabChangedPropertiesPreviewValues, value);
        }
        /// <summary>    
        ///  是否有变化的属性
        ///  protected internal 
        /// </summary>
        protected internal bool m_HasChangedProperties;
        /// <summary>
        /// 是否有变化的属性
        /// </summary>
        public virtual bool HasChangedProperties
        {
            get => m_HasChangedProperties =
                GrabChangedProperties ? 
                ChangedProperties?.Count > 0 : m_HasChangedProperties;
            protected internal set => Set(ref m_HasChangedProperties, value);
        }
        /// <summary>    
        ///  是否只有在属性变化时执行
        ///  protected internal 
        /// </summary>
        protected internal bool m_OnlyExecuteOnPropertyChanged = true;
        /// <summary>
        /// 是否只有在属性变化时执行
        /// </summary>
        public virtual bool OnlyExecuteOnPropertyChanged
        {
            get => m_OnlyExecuteOnPropertyChanged;
            set => Set(ref m_OnlyExecuteOnPropertyChanged, value);
        }

        #region BeforePropertySet
        /// <summary>    
        ///  是否允许执行属性变化前事件
        ///  protected internal 
        /// </summary>
        protected internal bool m_EnabledEventBeforePropertySet = true;
        /// <summary>
        /// 是否允许执行属性变化前事件
        /// </summary>
        public virtual bool EnabledEventBeforePropertySet
        {
            get => m_EnabledEventBeforePropertySet;
            set => Set(ref m_EnabledEventBeforePropertySet, value);
        }
        /// <summary>
        /// 属性变化前事件
        /// </summary>
        public event ExtendPropertyChangedEventHandle BeforePropertySet;
        #endregion
        #region PropertyChanged
        /// <summary>    
        ///  是否允许执行属性变化增强事件
        ///  protected internal 
        /// </summary>
        protected internal bool m_EnabledEventExtPropertyChanged = false;
        /// <summary>
        /// 是否允许执行属性变化增强事件
        /// </summary>
        public virtual bool EnabledEventExtPropertyChanged
        {
            get => m_EnabledEventExtPropertyChanged;
            set => Set(ref m_EnabledEventExtPropertyChanged, value);
        }
        /// <summary>
        /// 属性变化增强事件
        /// </summary>
        public event ExtendPropertyChangedEventHandle ExtPropertyChanged;
        #endregion
        #region Notify
        /// <summary>    
        ///  允许实现界面通知属性变化事件
        ///  protected internal 
        /// </summary>
        protected internal bool m_EnabledNotify = false;
        /// <summary>
        /// 允许实现界面通知属性变化事件
        /// </summary>
        public virtual bool EnabledNotify
        {
            get => m_EnabledNotify;
            set => Set(ref m_EnabledNotify, value);
        }

        /// <summary>
        /// 通知界面UI属性变化事件
        /// 在EnableNotify为true时触发
        /// </summary>
        public virtual event PropertyChangedEventHandler PropertyChanged;

        #endregion


        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="fieldValue">属性对应的值字段</param>
        /// <param name="newValue">新的值</param>
        /// <param name="action">设定时关联的动作 参数1传递新的值 参数2传递原始值 参数3返回属性所属对象</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>有变化返回true,无变化返回false</returns>
        public virtual bool Set<T>(ref T fieldValue, T newValue, Action<T, T, object> action = default, [CallerMemberName] string propertyName = "")
        {
            var preValue = fieldValue;
            OnBeforePropertySet(fieldValue, newValue, propertyName);           
            var changed = !object.Equals(fieldValue, newValue);
            if (changed
                && m_GrabChangedProperties)
            {
                var noValuesPair = default(KeyValuePair<object, object>);
                if (GrabChangedPropertiesValues
                    && GrabChangedPropertiesPreviewValues)
                    noValuesPair = new KeyValuePair<object, object>(newValue, preValue);
                else if (GrabChangedPropertiesValues
                  && !GrabChangedPropertiesPreviewValues)
                    noValuesPair = new KeyValuePair<object, object>(newValue, default);
                else if (!GrabChangedPropertiesValues
                  && GrabChangedPropertiesPreviewValues)
                    noValuesPair = new KeyValuePair<object, object>(default, preValue);
                if (!ChangedProperties.ContainsKey(propertyName))
                    ChangedProperties.Add(propertyName, noValuesPair);
                ChangedProperties[propertyName] = noValuesPair;
            }
            if (changed)
            {
                m_HasChangedProperties = true;
                OnNotified(nameof(HasChangedProperties));
            }
            if ((changed
                && OnlyExecuteOnPropertyChanged)
                || !OnlyExecuteOnPropertyChanged)
            {
                fieldValue = newValue;
                OnExtPropertyChanged(newValue, preValue, propertyName);
                OnNotified(propertyName);
            }
            action?.Invoke(newValue, preValue, this);
            return changed;
        }

        /// <summary>
        /// 属性变化前动作
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <param name="propertyName"></param>
        public virtual void OnBeforePropertySet(object oldValue, object newValue, [CallerMemberName] string propertyName = "")
        {
            if (EnabledEventBeforePropertySet)
                BeforePropertySet?.Invoke(this, oldValue, newValue, propertyName);
        }

        /// <summary>
        /// 属性变化事件增强动作
        /// </summary>
        /// <param name="newValue"></param>
        /// <param name="oldValue"></param>
        /// <param name="propertyName"></param>
        public virtual void OnExtPropertyChanged(object newValue, object oldValue, [CallerMemberName] string propertyName = "")
        {
            if (EnabledEventExtPropertyChanged)
                ExtPropertyChanged?.Invoke(this, newValue, oldValue, propertyName);
        }

        /// <summary>
        /// 通知界面属性变化动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="propertyName"></param>
        public virtual void OnNotified([CallerMemberName] string propertyName = "")
        {
            if (EnabledNotify)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
