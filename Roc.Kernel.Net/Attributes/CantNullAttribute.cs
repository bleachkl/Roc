using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Roc.Kernel.Attributes
{
    
    // <summary>
    /// 不为空特性
    /// 在Json文件存储时
    /// Txt文件操作
    /// Sql操作
    /// </summary>
    public class CantNullAttribute : Attribute
    {
        
        /// <summary>
        /// 不为空特性
        /// 参数 1 被标记Property或Field
        /// </summary>
        /// <param name="variableName">被标记Property或Field</param>
        public CantNullAttribute([CallerMemberName] string variableName = "")
        {
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
    }
}
