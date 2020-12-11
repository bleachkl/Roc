using Roc.Kernel.Extensions.ForString;
using Roc.Kernel.Reflections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Roc.Kernel.Attributes
{
    
    // <summary>
    /// 显示名称特性
    /// 在Json文件存储时
    /// Txt文件操作
    /// Sql操作
    /// </summary>
    public class ViewNameAttribute : Attribute
    {
        /// <summary>
        /// 显示名称特性
        /// 参数 1 成员所属类型
        /// 参数 2 默认显示名称特性
        /// 参数 3 被标记Property或Field
        /// </summary>
        /// <param name="callerType">成员所属类型</param>
        /// <param name="viewName">默认显示名称特性</param>
        /// <param name="variableName">被标记Property或Field名称</param>
        public ViewNameAttribute(Type callerType, 
            string viewName = null,
            [CallerMemberName] string variableName = "")
        {
            m_ViewName = AssemblyHelper.GetExtendValue<ViewNameAttribute>(callerType, variableName);
            m_ViewName = m_ViewName.IsNullOrEmpty() ?
                viewName : m_ViewName;
            m_ViewName = m_ViewName.IsNullOrEmpty() ?
                variableName : m_ViewName;
            m_VariableName = variableName;
        }
        /// <summary>
        /// 显示名称特性
        /// 参数 1 指定的显示名称
        /// 参数 2 被标记Property或Field
        /// </summary>
        /// <param name="callerType">指定的显示名称</param>
        /// <param name="variableName">被标记Property或Field名称</param>
        public ViewNameAttribute(string viewName = "",
            [CallerMemberName] string variableName = "")
        {
            m_ViewName = viewName.IsNullOrEmpty() ? 
                variableName : viewName;
            m_VariableName = variableName;
        }
        /// <summary>
        /// 被标记Property或Field名称
        /// protected internal
        /// </summary>
        protected internal string m_VariableName;
        /// <summary>
        /// 被标记Property或Field名称
        /// </summary>
        public string VariableName => m_VariableName;
        /// <summary>
        /// 显示名称
        /// protected internal
        /// </summary>
        protected internal string m_ViewName;
        /// <summary>
        /// 显示名称
        /// </summary>
        public string ViewName => m_ViewName;
    }
}
