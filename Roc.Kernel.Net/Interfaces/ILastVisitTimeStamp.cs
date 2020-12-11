using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel
{
    /// <summary>
    /// 最后次调用时间戳属性接口
    /// </summary>
    public interface ILastVisitTimeStamp
    {
        /// <summary>
        /// 最后次调用时间戳
        /// </summary>
        long LastVisitTimeStamp { get; set; }
    }
}
