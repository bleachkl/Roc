using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel.Reflections
{
    /// <summary>
    /// 成员类型分类枚举
    /// </summary>
    public enum MemberCategories
    {
        /// <summary>
        /// 未知
        /// </summary>
        None,
        /// <summary>
        /// 成员类型
        /// </summary>
        Member,
        /// <summary>
        /// 属性类型
        /// </summary>
        Property,
        /// <summary>
        /// 字段类型
        /// </summary>
        Field,
        /// <summary>
        /// 方法类型
        /// </summary>
        Method,
        /// <summary>
        /// 事件类型
        /// </summary>
        EventInfo,
        /// <summary>
        /// 变量类型
        /// 字段和属性
        /// Members | Properties
        /// </summary>
        Variable = 100,
    }
}
