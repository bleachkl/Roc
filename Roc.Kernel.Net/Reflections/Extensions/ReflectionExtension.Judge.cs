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
        /// 判断某类型是否可被当目标类型
        /// </summary>
        /// <param name="type">某类型</param>
        /// <param name="targetType">目标类型</param>
        /// <returns></returns>
        public static bool RegardAs(this Type type, Type targetType)
        {
            return ReflectionHelper.RegardAs(type,targetType);
        }
        /// <summary>
        /// 判断某类型是否可被当目标类型
        /// </summary>
        /// <typeparam name="T">某类型</typeparam>
        /// <typeparam name="TT">目标类型</typeparam>
        /// <typeparam name="carrier">调用的载体</typeparam>
        /// <returns></returns>
        public static bool RegardAs<T, TT>(this object carrier)
        {
            return ReflectionHelper.RegardAs(typeof(T), typeof(TT));
        }
        /// <summary>
        /// 判断两个类型是否继承自同一类型
        /// </summary>
        /// <param name="type1"></param>
        /// <param name="type2"></param>
        /// <returns></returns>
        public static bool InheritedSame(this Type type1, Type type2)
        {
            return ReflectionHelper.InheritedSame(type1, type2);
        }
        /// <summary>
        /// 判断多个类型是否继承自同一类型
        /// </summary>
        /// <typeparam name="carrier">调用的载体</typeparam>
        /// <param name="types">要判断的类型集合</param>
        /// <returns></returns>
        public static bool InheritedSame(this object carrier,params Type[] types)
        {
            return ReflectionHelper.InheritedSame(types);
        }
        /// <summary>
        /// 判断多个类型是否继承自同一类型
        /// </summary>
        /// <typeparam name="type">某类型</typeparam>
        /// <param name="types">要判断的类型集合</param>
        /// <returns></returns>
        public static bool InheritedSame(this Type type, params Type[] types)
        {
            var typesList = new List<Type>();
            if (type != default)
                typesList.Add(type);
            if (types.Length > 1)
                typesList.AddRange(types?.Where(x => x != default) ?? EmptyArrays.Type);
            return typesList.Count > 0 ? ReflectionHelper.InheritedSame(typesList.ToArray()) : false;
        }
        /// <summary>
        /// 判断两个类型是否继承自同一类型
        /// </summary>
        /// <typeparam name="T1">类型1</typeparam>
        /// <typeparam name="T2">类型2</typeparam>
        /// <typeparam name="carrier">调用的载体</typeparam>
        /// <returns></returns>
        public static bool InheritedSame<T1, T2>(this object carrier)
        {
            return InheritedSame(typeof(T1), typeof(T2));
        }
        #region IsStatic 判断成员是否是静态
        /// <summary>
        /// 判断成员是否是静态
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static bool IsStatic(this MemberInfo memberInfo)
        {
            return ReflectionHelper.IsStatic(memberInfo);
        }
        #endregion
        /// <summary>
        /// 判断是否为对象类型 object
        /// </summary>
        /// <param name="inType"></param>
        /// <returns></returns>
        public static bool Isobject(this Type inType)
        {
            return ReflectionHelper.Isobject(inType);
        }
        /// <summary>
        /// 判断是否为对象类型 object
        /// </summary>
        /// <param name="instance">要判断的实体</param>
        /// <returns></returns>
        public static bool Isobject(this object instance)
        {
            return ReflectionHelper.Isobject(instance?.GetType());
        }

        /// <summary>
        /// 获取一个值，通过该值指示该值是否在编译时写入并且不能更改。
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static bool IsLiteral(this MemberInfo memberInfo)
        {

            return ReflectionHelper.IsLiteral(memberInfo);
        }

        /// <summary>
        /// 获取一个值，通过该值指示此字段是否只能在构造函数的主体中设置。
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static bool IsInitOnly(this MemberInfo memberInfo)
        {
            return ReflectionHelper.IsInitOnly(memberInfo);
        }

        /// <summary>
        /// Member是否可写
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static bool CanWrite(this MemberInfo memberInfo)
        {
            return ReflectionHelper.CanWrite(memberInfo);
        }

        /// <summary>
        /// Member是否public
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static bool IsPublic(this MemberInfo memberInfo)
        {
            return ReflectionHelper.IsPublic(memberInfo);
        }

        /// <summary>
        /// 判断是否是方法Member
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static bool IsMethod(this MemberInfo memberInfo)
        {
            return ReflectionHelper.IsMethod(memberInfo);
        }

    }
}
