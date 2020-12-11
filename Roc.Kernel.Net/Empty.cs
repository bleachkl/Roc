using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel
{
    /// <summary>
    /// 存储相关空类型的声明
    /// </summary>
    public static class Empty
    {
        /// <summary>
        /// 空object
        /// </summary>
        public static object @object { get; } = new object();
        //public static KeyValuePair<object, object> KeyValuePair_object_object = default;
    }
}
