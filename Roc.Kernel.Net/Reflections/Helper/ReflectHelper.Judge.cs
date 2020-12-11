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
        /// 判断某类型是否可被当目标类型
        /// </summary>
        /// <param name="type">某类型</param>
        /// <param name="targetType">目标类型</param>
        /// <returns></returns>
        public static bool RegardAs(Type type, Type targetType)
        {
            return default != type
                    && (type == targetType
                    || true == targetType?.IsSubclassOf(type)
                    || true == targetType?.IsAssignableFrom(type));
        }
        /// <summary>
        /// 判断某类型是否可被当目标类型
        /// </summary>
        /// <typeparam name="T">某类型</typeparam>
        /// <typeparam name="TT">目标类型</typeparam>
        /// <returns></returns>
        public static bool RegardAs<T, TT>()
        {
            return RegardAs(typeof(T), typeof(TT));
        }
        /// <summary>
        /// 判断两个类型是否继承自同一类型
        /// </summary>
        /// <param name="type1"></param>
        /// <param name="type2"></param>
        /// <returns></returns>
        public static bool InheritedSame(Type type1, Type type2)
        {
            return default != type1
                    && (type1 == type2
                    || true == type2?.IsSubclassOf(type1)
                    || true == type2?.IsAssignableFrom(type1)
                    || true == type1?.IsSubclassOf(type2)
                    || true == type1?.IsAssignableFrom(type2));
        }
        /// <summary>
        /// 判断多个类型是否继承自同一类型
        /// </summary>
        /// <param name="types">要判断的类型集合</param>
        /// <returns></returns>
        public static bool InheritedSame(params Type[] types)
        {
            if (types?.Length >= 2)
            {
                var inherited = true;
                for (var i = 1; i < types.Length; i++)
                    inherited &= InheritedSame(types[i - 1], types[i]);
                return inherited;
            }
            return false;
        }
        /// <summary>
        /// 判断两个类型是否继承自同一类型
        /// </summary>
        /// <typeparam name="T1">类型1</typeparam>
        /// <typeparam name="T2">类型2</typeparam>
        /// <returns></returns>
        public static bool InheritedSame<T1, T2>()
        {
            return InheritedSame(typeof(T1), typeof(T2));
        }
        #region IsStatic 判断成员是否是静态
        /// <summary>
        /// 判断成员是否是静态
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static bool IsStatic(MemberInfo memberInfo)
        {
            return BindingFlags.Static ==
                (BindingFlags.Static & GetBindingFlags(memberInfo));
        }
        #endregion
        /// <summary>
        /// 判断是否为对象类型 object
        /// </summary>
        /// <param name="inType"></param>
        /// <returns></returns>
        public static bool Isobject(Type inType)
        {
            return true == inType?.IsValueType ?
                false :
                (!inType.IsValueType && !Types.Strings.Contains(inType));
        }


        /// <summary>
        /// 获取一个值，通过该值指示该值是否在编译时写入并且不能更改。
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static bool IsLiteral(MemberInfo memberInfo)
        {
            if (memberInfo is FieldInfo fieldInfo)
                return fieldInfo.IsLiteral;
            else if (memberInfo is EventInfo eventInfo)
                return false;
            return true;
        }

        /// <summary>
        /// 获取一个值，通过该值指示此字段是否只能在构造函数的主体中设置。
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static bool IsInitOnly(MemberInfo memberInfo)
        {
            if (memberInfo is FieldInfo fieldInfo)
                return fieldInfo.IsInitOnly;
            else if (memberInfo is EventInfo eventInfo)
                return false;
            return true;
        }

        /// <summary>
        /// Member是否可写
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static bool CanWrite(MemberInfo memberInfo)
        {
            if (memberInfo is PropertyInfo propertyInfo)
                return propertyInfo.CanWrite;
            else if (memberInfo is FieldInfo fieldInfo)
                return !(fieldInfo.IsLiteral
                    | fieldInfo.IsInitOnly);
            else if (memberInfo is MethodInfo methodInfo)
                return false;
            else if (memberInfo is EventInfo eventInfo)
                return true;
            return false;
        }

        /// <summary>
        /// Member是否public
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static bool IsPublic(MemberInfo memberInfo)
        {
            return BindingFlags.Public ==
                (BindingFlags.Public
                & GetBindingFlags(memberInfo));
        }

        /// <summary>
        /// 判断是否是方法Member
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static bool IsMethod(MemberInfo memberInfo)
        {
            return MemberTypes.Method == memberInfo?.MemberType;
        }
    }
}
