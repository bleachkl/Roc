using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Roc.Kernel.Reflections;
using Roc.Kernel.Extensions.ForRefelctionExpression;

namespace Roc.Kernel.Extensions.ForRefelction
{
    /// <summary>
    /// 反射帮助类
    /// </summary>
    public static partial class ReflectionExtension
    {
        /// <summary>
        /// 获取参数的实际类型列表
        /// </summary>
        /// <param name="carrier"></param>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static Type[] GetTypes(this object carrier, params object[] parms)
        {
            return ReflectionHelper.GetTypes(parms);
        }
        /// <summary>
        /// 类型转换为
        /// </summary>
        /// <param name="carrier">调用载体</param>
        /// <param name="types"></param>
        /// <returns></returns>
        public static object[] ToArrayobject(this object carrier, params Type[] types)
        {
            return ReflectionHelper.ToArrayobject(types);
        }
        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="type"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static object CreateInstance(this Type type, params object[] args)
        {
            return ReflectionHelper.CreateInstance(type, args);
        }
        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="T">指定类型</param>
        /// <param name="carrier">调用载体</param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static T CreateInstance<T>(this object carrier, params object[] args)
        {
            return ReflectionHelper.CreateInstance<T>(args);
        }
    }
}
