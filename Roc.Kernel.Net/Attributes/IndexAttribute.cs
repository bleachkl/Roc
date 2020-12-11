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
    /// 索引特性
    /// 在Json文件存储时
    /// Txt文件操作
    /// Sql操作
    /// </summary>
    public class IndexAttribute : Attribute
    {
        /// <summary>
        /// 索引特性
        /// 参数 1 成员所属类型
        /// 参数 2 默认索引
        /// 参数 3 被标记Property或Field
        /// </summary>
        /// <param name="callerType">成员所属类型</param>
        /// <param name="index">默认索引</param>
        /// <param name="variableName">被标记Property或Field名称</param>
        public IndexAttribute(Type callerType,
            int index = -1,
            [CallerMemberName] string variableName = "")
        {
            m_Index =
                AssemblyHelper.GetExtendValue<IndexAttribute>(callerType, variableName).Toint(index);
            m_VariableName = variableName;
        }
        /// <summary>
        /// 索引特性
        /// 参数 1 指定的索引
        /// 参数 2 被标记Property或Field
        /// </summary>
        /// <param name="index">指定的索引</param>
        /// <param name="variableName">被标记Property或Field</param>
        public IndexAttribute(int index = -1, 
            [CallerMemberName] string variableName = "")
        {
            m_Index = index;
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
        protected internal int m_Index = int.MinValue;
        /// <summary>
        /// 索引
        /// </summary>
        public int Index => m_Index;
    }
}
