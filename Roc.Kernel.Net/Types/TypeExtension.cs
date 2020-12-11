using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel.Extensions.ForType
{
    /// <summary>
    /// Type帮助类
    /// </summary>
    public static class TypeExtension
    {
        /// <summary>
        /// 判断2个类型数组集合是否相同
        /// </summary>
        /// <param name="types"></param>
        /// <param name="compareTypes"></param>
        /// <returns></returns>
        public static bool Equal(this IEnumerable<Type> types, IEnumerable<Type> compareTypes)
        {
            return TypeHelper.Equal(types, compareTypes);
        }
        /// <summary>
        /// 获取parameterinfo的类型数组
        /// </summary>
        /// <param name="carrier">调用的载体</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Type[] ToArrayType(this object carrier, params ParameterInfo[] parameters)
        {
            return TypeHelper.ToArrayType(parameters);
        }
    }
}
