using Roc.Kernel.Extensions.ForString;
using Roc.Kernel.Reflections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Roc.Kernel.Attributes
{
    /// <summary>
    /// 数据字段标注特性
    /// 在Json文件存储时
    /// Txt文件操作
    /// Sql操作
    /// </summary>
    public class DataFieldAttribute : Attribute
    {
        /// <summary>
        /// 数据字段标注特性
        /// 参数 1 成员所属类型
        /// 参数 2 默认指定的数据字段名称
        /// 参数 3 被标记Property或Field
        /// </summary>
        /// <param name="callerType">成员所属类型</param>
        /// <param name="dataFieldName">默认指定的数据字段名称</param>
        /// <param name="variableName">被标记Property或Field名称</param>
        public DataFieldAttribute(Type callerType,
            string dataField = "",
            [CallerMemberName] string variableName = "")
        {
            m_DataField = AssemblyHelper.GetExtendValue<DataFieldAttribute>(callerType, variableName);
            m_DataField = m_DataField.IsNullOrEmpty() ?
                dataField : m_DataField; 
            m_DataField = m_DataField.IsNullOrEmpty() ?
                variableName : m_DataField;
            m_VariableName = variableName;
        }
        /// <summary>
        /// 数据字段标注特性
        /// 参数 1 指定的数据字段名称
        /// 参数 2 被标记Property或Field
        /// </summary>
        /// <param name="dataFieldName">指定的数据字段名称</param>
        /// <param name="variableName">被标记Property或Field</param>
        public DataFieldAttribute(string dataField = "", 
            [CallerMemberName] string variableName = "")
        {
            m_DataField = dataField.IsNullOrEmpty() ?
                variableName : dataField;
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
        /// 被标记Property或Field所指定数据库字段或文本名称
        /// protected internal
        /// </summary>
        protected internal string m_DataField;
        /// <summary>
        /// 被标记Property或Field所指定数据库字段或文本名称
        /// </summary>
        public string DataField => m_DataField;
    }
    
}
