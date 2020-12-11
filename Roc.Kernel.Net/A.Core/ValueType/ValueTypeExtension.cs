using Roc.Kernel.Extensions.ForString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel.Reflections.ForValueType
{
    public static partial class ValueTypeExtension
    {
        /// <summary>
        /// 将一个对象转为int
        /// 默认返回int.MinValue
        /// </summary>
        /// <param name="valInstance"></param>
        /// <param name="@default"></param>
        /// <returns></returns>
        public static int Toint(this object valInstance, int @default = int.MinValue)
        {
            int real;
            if (int.TryParse(valInstance?.Tostring(), out real))
                return real;
            return @default;
        }
    }
}
