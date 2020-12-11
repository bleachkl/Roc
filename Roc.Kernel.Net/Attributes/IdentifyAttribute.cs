using Roc.Kernel.Extensions.ForString;
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
    /// 自增特性
    /// 在Json文件存储时
    /// Txt文件操作
    /// Sql操作
    /// </summary>
    public class IdentifyAttribute : Attribute
    {
        /// <summary>
        /// 索引特性
        /// 使用 , 做参数间隔
        /// 参数 1 成员所属类型
        /// 参数 2 默认种子
        /// 参数 3 默认自增量
        /// 参数 4 被标记Property或Field
        /// </summary>
        /// <param name="callerType">成员所属类型</param>
        /// <param name="seed">默认种子</param>
        /// <param name="increment">默认自增量</param>
        /// <param name="variableName">被标记Property或Field名称</param>
        public IdentifyAttribute(Type callerType,
            int seed = 1,
            int increment = 1,
            [CallerMemberName] string variableName = "")
        {
            if (AssemblyHelper.GetExtendValue<IdentifyAttribute>(callerType, variableName)
                ?.Split(charArray.ENComma, StringSplitOptions.RemoveEmptyEntries)
                is string[] parms)
            {
                if (parms?.Length > 0)
                    m_Seed = parms[0].Toint(seed);
                if (parms?.Length > 1)
                    m_Increment = parms[1].Toint(increment);
            }
            m_VariableName = variableName;
        }
        /// <summary>
        /// 自增特性
        /// 参数 1 种子
        /// 参数 2 自增量
        /// 参数 3 被标记Property或Field
        /// </summary>
        /// <param name="seed">种子</param>
        /// <param name="increment">自增量</param>
        /// <param name="variableName">被标记Property或Field</param>
        public IdentifyAttribute(int seed = 1,
            int increment = 1, 
            [CallerMemberName] string variableName = "")
        {
            m_Seed = seed;
            m_Increment = increment;
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
        /// 自增的起始 私有字段 Field
        /// </summary>
        protected int m_Seed = 1;
        /// <summary>
        /// 自增的起始
        /// </summary>
        public int Seed => m_Seed;
        /// <summary>
        /// 自增增长大小 私有字段 Field
        /// </summary>
        protected int m_Increment = 1;
        /// <summary>
        /// 自增增长大小
        /// </summary>
        public int Increment => m_Increment;        
    }
}
