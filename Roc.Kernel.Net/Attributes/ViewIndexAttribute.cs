using Roc.Kernel.IOs;
using Roc.Kernel.Reflections;
using Roc.Kernel.Reflections.ForValueType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Roc.Kernel.Attributes
{
    
    // <summary>
    /// 显示索引特性
    /// 在Json文件存储时
    /// Txt文件操作
    /// Sql操作
    /// </summary>
    public class ViewIndexAttribute : Attribute
    {
        /// <summary>
        /// 显示索引特性
        /// 参数 1 成员所属类型
        /// 参数 2 默认的显示索引
        /// 参数 3 被标记Property或Field
        /// </summary>
        /// <param name="callerType">成员所属类型</param>
        /// <param name="viewIndex">默认的显示索引</param>
        /// <param name="variableName">被标记Property或Field名称</param>
        public ViewIndexAttribute(Type callerType,
            int viewIndex = -1,
            [CallerMemberName] string variableName = "")
        {
            m_ViewIndex = 
                AssemblyHelper.GetExtendValue<ViewIndexAttribute>(callerType, variableName).Toint(viewIndex);
            m_VariableName = variableName;
        }
        /// <summary>
        /// 显示索引特性
        /// 参数 1 指定的显示索引 
        /// 参数 2 被标记Property或Field 
        /// </summary>
        public ViewIndexAttribute(int viewIndex = -1,
            [CallerMemberName] string variableName = "")
        {
            m_ViewIndex = viewIndex;
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
        /// 索引
        /// protected internal
        /// </summary>
        protected internal int m_ViewIndex;
        /// <summary>
        /// 索引
        /// </summary>
        public int ViewIndex => m_ViewIndex;
    }
}
