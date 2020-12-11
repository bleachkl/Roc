using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel
{
    /// <summary>
    /// 空Array定义
    /// </summary>
    public static class EmptyArrays
    {
        /// <summary>
        /// 空Attribute对象数组
        /// </summary>
        public static Attribute[] Attribute { get; } = new Attribute[0];
        /// <summary>
        /// 空Delegate对象数组
        /// </summary>
        public static Delegate[] Delegate { get; } = new Delegate[0];
        /// <summary>
        /// 空char对象数组
        /// </summary>
        public static char[] @char { get; } = new char[0];

        /// <summary>
        /// 空object对象数组
        /// </summary>
        public static object[] @object { get; } = new object[0];

        /// <summary>
        /// 空类型集合
        /// </summary>
        public static Type[] Type { get; } = new Type[0];

        /// <summary>
        /// 空成构造信息集合
        /// </summary>
        public static ConstructorInfo[] ConstructorInfo { get; internal set; } = new ConstructorInfo[0];

        /// <summary>
        /// 空成员类型集合
        /// </summary>
        public static MemberInfo[] MemberInfo { get; } = new MemberInfo[0];

        /// <summary>
        /// 空属性类型集合
        /// </summary>
        public static PropertyInfo[] PropertyInfo { get; } = new PropertyInfo[0];

        /// <summary>
        /// 空参数类型集合
        /// </summary>
        public static ParameterInfo[] ParameterInfo { get; } = new ParameterInfo[0];

        /// <summary>
        /// 空字段类型集合
        /// </summary>
        public static FieldInfo[] FieldInfo { get; } = new FieldInfo[0];

        /// <summary>
        /// 空方法类型集合
        /// </summary>
        public static MethodInfo[] MethodInfo { get; } = new MethodInfo[0];

        /// <summary>
        /// 空事件类型集合
        /// </summary>
        public static EventInfo[] EventInfo { get; } = new EventInfo[0];
    }
}
