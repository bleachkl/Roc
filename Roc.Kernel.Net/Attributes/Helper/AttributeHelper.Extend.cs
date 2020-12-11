using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Roc.Kernel.Reflections;

namespace Roc.Kernel.Attributes
{
    /// <summary>
    /// 特性帮助类
    /// 高级
    /// </summary>
    public static partial class AttributeHelper
    {
        /// <summary>
        /// 获取指定类型中所有成员特性信息
        /// </summary>
        /// <param name="type">指定的类型</param>
        /// <returns></returns>
        public static Attribute[] GainMembersAttributes(Type type)
        {
            return ReflectionHelper.AddOrGetTypesInfosDictionary(type)?.MembersAttributes ??
                EmptyArrays.Attribute;
        }

        /// <summary>
        /// 查找指定类型中成员特性信息中指定类型的特性
        /// </summary>
        /// <param name="type">指定的类型</param>
        /// <param name="attributeType">指定的特性类型</param>
        /// <returns></returns>
        public static Attribute[] SearchMembersAttributes(Type type, Type attributeType)
        {
            return GainMembersAttributes(type)?.Where(x => 
            x.GetType() == attributeType)?.ToArray() ??                
            EmptyArrays.Attribute;
        }

        /// <summary>
        /// 查找指定类型中成员特性信息中指定类型的特性
        /// </summary>
        /// <typeparam name="T">指定的特性类型</typeparam>
        /// <param name="type">指定的类型</param>
        /// <returns></returns>
        public static Attribute[] SearchMembersAttributes<T>(Type type) where T : Attribute
        {
            return GainMembersAttributes(type)?.Where(x =>            
            x.GetType() == typeof(T))?.ToArray() ??
            EmptyArrays.Attribute;
        }
    }
}
