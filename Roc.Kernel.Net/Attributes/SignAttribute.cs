using Roc.Kernel.Extensions.ForString;
using Roc.Kernel.Reflections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel.Attributes
{
    /// <summary>
    /// 签名名称特性
    /// </summary>
    public class SignAttribute : Attribute
    {
        /// <summary>
        /// 签名名称特性
        /// 参数 1 成员所属类型
        /// 参数 2 默认签名名称
        /// 参数 3 被标记Property或Field
        /// </summary>
        /// <param name="callerType">成员所属类型</param>
        /// <param name="signName">默认签名名称</param>
        /// <param name="variableName">被标记Property或Field名称</param>
        public SignAttribute(Type callerType,
            string signName = "",
            [CallerMemberName] string variableName = "")
        {
            m_SignName = AssemblyHelper.GetExtendValue<SignAttribute>(callerType, variableName);
            m_SignName = m_SignName.IsNullOrEmpty() ?
              signName : m_SignName;
            m_SignName = m_SignName.IsNullOrEmpty() ?
                variableName : m_SignName;
            m_VariableName = variableName;
        }
        /// <summary>
        /// 签名名称特性
        /// 参数 1 指定的签名名称
        /// 参数 2 被标记Property或Field
        /// </summary>
        /// <param name="signName">签名名称</param>
        /// <param name="variableName">被标记Property或Field</param>
        public SignAttribute(string signName = "", 
            [CallerMemberName] string variableName = "")
        {
            signName =
                signName.IsNullOrEmpty() ?
                variableName : signName;
            m_VariableName = variableName;
            m_SignName = signName;
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
        /// 被标记Property或Field所指定签名名称
        /// protected internal
        /// </summary>
        protected internal string m_SignName;
        /// <summary>
        /// 被标记Property或Field所指定签名名称
        /// </summary>
        public string SignName => m_SignName;
    }
}
