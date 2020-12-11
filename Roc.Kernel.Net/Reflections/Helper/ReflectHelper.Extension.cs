using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel.Reflections
{
    /// <summary>
    /// 反射帮助类
    /// </summary>
    public static partial class ReflectionHelper 
    {
        /// <summary>
        /// BindingFlags转为系统默认
        /// 默认为ReflectHelper的默认公开成员搜索方式
        /// </summary>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static BindingFlags ToBindingFlags(this BindingFlags bindingFlag)
        {
            if (bindingFlag == BindingFlags.Default)
                return ms_SearchFlagDefault;
            return bindingFlag;
        }
    }
}
