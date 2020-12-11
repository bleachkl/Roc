using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Roc.Kernel.Extensions.ForRefelctionExpression;

namespace Roc.Kernel.Reflections
{
    /// <summary>
    /// 反射帮助类
    /// </summary>
    public static partial class ReflectionHelper
    {
        /// <summary>
        /// 获取参数的实际类型列表
        /// </summary>
        /// <param name="parms"></param>
        /// <returns></returns>
        public static Type[] GetTypes(params object[] parms)
        {
            if (parms.Length > 0)
            {
                var argTypes = new Type[parms.Length];
                for (var i = 0; i < parms.Length; i++)
                    argTypes[i] = parms[i]?.GetType() ?? Types.@object;
                return argTypes;
            }
            return EmptyArrays.Type;
        }
        /// <summary>
        /// 将Type数组转换为对应的对象数组object[]
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public static object[] ToArrayobject(params Type[] types)
        {
            if (types.Length > 0)
            {
                var array = new object[types.Length];
                for (var i = 0; i < types.Length; i++)
                    array[i] = CreateInstance(types[i]);
                return array;
            }
            return EmptyArrays.@object;
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="type"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static object CreateInstance(Type type, params object[] args)
        {
            if (type?.IsAbstract == true)
                return default;
            if (type?.IsValueType == true)//首先是值类型
                return Activator.CreateInstance(type);
            else
              if (AddOrGetTypesInfosDictionary(type) is ExtendTypeInfo typeInfo)
                if (typeInfo.ConstructorParameters?.Length == 0
                && typeInfo.Constructor?.IsPublic == true)
                    return Activator.CreateInstance(type);
                else if (typeInfo.ConstructorParameters?.Length >= 1)
                    return Activator.CreateInstance(type,
                        (args?.Length > 0
                        && typeInfo.FindConstructor(GetTypes(args)) 
                        is ConstructorInfo) ?
                        args : typeInfo.ConstructorArgs);
            return default;
        }
        /// <summary>
        /// 创建实例
        /// </summary>
        /// <param name="T">指定类型</param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static T CreateInstance<T>(params object[] args)
        {
            return (T)CreateInstance(typeof(T), args);
        }
    }
}
