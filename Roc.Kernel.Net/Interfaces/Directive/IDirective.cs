using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel
{
    /// <summary>
    /// 操作类别
    /// </summary>
    public enum Directives
    {
        /// <summary>
        /// 未定义
        /// </summary>
        None,
        /// <summary>
        /// 创建
        /// </summary>
        Create = 10,
        /// <summary>
        /// 更新
        /// </summary>
        Update = 20,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 30,
    }
    /// <summary>
    /// 实现对象操作类别属性
    /// </summary>
    public interface IDirective
    {
        /// <summary>
        /// 操作类别
        /// </summary>
        Directives Directive { get; set; }
    }
}
