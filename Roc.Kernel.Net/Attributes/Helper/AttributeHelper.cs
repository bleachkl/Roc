using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Roc.Kernel.Attributes
{
    /// <summary>
    /// 特性帮助类
    /// </summary>
    public static partial class AttributeHelper
    {

        /// <summary>
        /// 竞争操作时的一部锁对象
        /// async
        /// </summary>
        internal static readonly object ms_AsyncLock = new object();

        /// <summary>
        /// 获取类型的特性标记
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Attribute[] GainAttributes(Type type)
        {
            return type == default ?
                EmptyArrays.Attribute :
                (type.GetCustomAttributes(true)?.Cast<Attribute>()?.ToArray() ??
                EmptyArrays.Attribute);
        }

        /// <summary>
        /// 获取类型的特性标记
        /// </summary>
        /// <param name="T">指定的类型</param>
        /// <returns></returns>
        public static Attribute[] GainAttributes<T>()
        {
            return AttributeHelper.GainAttributes(typeof(T));
        }

        /// <summary>
        /// 获取成员的特性标记
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static Attribute[] GainAttributes(MemberInfo memberInfo)
        {
            return memberInfo == default ?
               EmptyArrays.Attribute :
               (memberInfo.GetCustomAttributes(true)?.Cast<Attribute>()?.ToArray() ??
               EmptyArrays.Attribute);
        }

        /// <summary>
        /// 获取类型的指定特性标记
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static Attribute GainAttribute(Type type,Type attributeType)
        {
            return type != default
                 && attributeType != default ?
                 type.GetCustomAttributes(attributeType, true)?.FirstOrDefault() as Attribute :
                 default;
        }

        /// <summary>
        /// 获取成员的指定特性标记
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static Attribute GainAttribute(MemberInfo memberInfo, Type attributeType)
        {
            return memberInfo != default
                  && attributeType != default ?
                  memberInfo.GetCustomAttributes(attributeType, true)?.FirstOrDefault() as Attribute :
                 default;
        }

        /// <summary>
        /// 获取类型的指定特性标记
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static T GainAttribute<T>(Type type) where T : Attribute
        {
            return GainAttribute(type, typeof(T)) as T;
        }
        /// <summary>
        /// 获取成员的指定特性标记
        /// </summary>
        /// <typeparam name="T">标记类型</typeparam>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static T GainAttribute<T>(MemberInfo memberInfo) where T : Attribute
        {
            return GainAttribute(memberInfo, typeof(T)) as T;
        }
    }

}
