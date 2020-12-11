using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel
{
    /// <summary>
    /// 是否只有在属性变化时执行接口
    /// </summary>
    public interface IOnlyExecuteOnPropertyChanged
    {
        /// <summary>
        /// 是否只有在属性变化时执行
        /// </summary>
        bool OnlyExecuteOnPropertyChanged { get; set; }
    }
}
