using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel
{
   
    /// <summary>
    /// 实现Guid属性的接口
    /// </summary>
    public interface IGuid
    {
        /// <summary>
        /// Guid
        /// </summary>
        string Guid { get; set; }
    }
}
