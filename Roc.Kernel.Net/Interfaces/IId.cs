using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel
{
    /// <summary>
    /// 实现Id属性的接口
    /// </summary>
    public interface IId
    {
        /// <summary>
        /// Id
        /// </summary>
        string Id { get; set; }
    }
}
