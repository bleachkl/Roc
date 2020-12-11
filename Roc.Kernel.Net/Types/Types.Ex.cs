
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Reflection;

namespace Roc.Kernel
{
    /// <summary>
    /// 常用类型
    /// </summary>
    public static partial class Types
    {
        public static Type ConstructorInfo { get; } = typeof(ConstructorInfo);
        //public static Type ConstructorInfoFullNamePropertyInfo { get; } = typeof(DescriptionAttribute);
        //Types.IConvertible.GetProperty("FullName", ReflectHelper.ms_SearchFlagDefault).
        public static Type DescriptionAttribute { get; } = typeof(DescriptionAttribute);
        public static Type DisplayNameAttribute { get; } = typeof(DisplayNameAttribute);
        public static Type CustomAttributeData { get; } = typeof(CustomAttributeData);
        public static Type MemberDescriptor { get; } = typeof(MemberDescriptor);
        //public static Type  { get; } = typeof(IHuge);
        /// <summary>
        /// 所有动态对象类型 private
        /// </summary>
        static List<Type> ms_DynamicObjects;
        /// <summary>
        /// 所有动态对象类型
        /// </summary>
        public static List<Type> DynamicObjects
        {
            get
            {
                lock (ms_AnsycLock)
                {
                    if (ms_DynamicObjects == null)
                    {
                        ms_DynamicObjects = new List<Type>()
                        {
                            ExpandoObject,
                        };
                    }
                    return ms_DynamicObjects;
                }
            }
        }
        /// <summary>
        /// .net动态类可动态增删属性
        /// </summary>
        public static Type ExpandoObject { get; } = typeof(ExpandoObject);
    }
}
