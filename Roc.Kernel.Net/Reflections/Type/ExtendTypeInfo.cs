using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel.Reflections
{
    /// <summary>
    /// 类型信息
    /// </summary>
    public class ExtendTypeInfo : ILastVisitTimeStamp, IDisposable
    {
        ~ExtendTypeInfo()
        {
            this?.Dispose();
        }
        public void Dispose()
        {
            Constructors = default;
            Constructor = default;
            ConstructorArgs = default;
            Members = default;
            Properties = default;
            Fields = default;
            Methods = default;
            Events = default;
            TypeAttributes = default;
            MembersAttributes = default;
        }
        static readonly object ms_AsyncLock = new object();
        public ExtendTypeInfo()
        { }
        public ExtendTypeInfo(Type type, BindingFlags bindingFlag)
        {
            //TypeFullName = type.FullName;
            Type = type;
            Constructors = type.GetConstructors(ReflectionHelper.ms_SearchFlagDefault)?.ToArray() ??
                EmptyArrays.ConstructorInfo;
            Constructor = GetConstructor(Constructors);
            var c = string.Empty.ToArray();
            ConstructorParameters = Constructor?.GetParameters() ??
                EmptyArrays.ParameterInfo;
            ConstructorArgs = ConstructorParameters.Length > 0 ?
                new object[ConstructorParameters.Length] : EmptyArrays.@object;
            for (var i = 0; i < ConstructorParameters.Length; i++)
                ConstructorArgs[i] = ReflectionHelper.CreateInstance(ConstructorParameters[i].ParameterType);
            Members = type.GetMembers(bindingFlag)?.ToArray() ??
                EmptyArrays.MemberInfo;
            Properties = Members?.OfType<PropertyInfo>()?.ToArray() ??
                EmptyArrays.PropertyInfo;
            Fields = Members?.OfType<FieldInfo>()?.ToArray() ??
                EmptyArrays.FieldInfo;
            var variableList = new List<MemberInfo>(Properties);
            variableList.AddRange(Fields);
            Variables = variableList?.ToArray() ?? EmptyArrays.MemberInfo;
            Methods = Members?.OfType<MethodInfo>()?.ToArray() ??
                EmptyArrays.MethodInfo;
            Events = Members?.OfType<EventInfo>()?.ToArray() ??
                EmptyArrays.EventInfo;

        }
        #region ConstructorMethods
        /// <summary>
        /// 获取构造参数  默认
        /// </summary>
        /// <param name="argsTypes"></param>
        /// <returns></returns>
        public ConstructorInfo GetConstructor(params Type[] argsTypes)
        {
            return GetConstructor(Constructors, argsTypes);
        }

        /// <summary>
        /// 构造函数中FullName属性信息
        /// </summary>
        public static PropertyInfo ConstructorFullNameProperty { get; } =
            Types.ConstructorInfo.GetProperty("FullName", ReflectionHelper.ms_SearchFlagDefault);

        /// <summary>
        /// 获取构造参数 默认
        /// </summary>
        /// <param name="constructorsInfos"></param>
        /// <param name="argsTypes"></param>
        /// <returns></returns>
        public static ConstructorInfo GetConstructor(ConstructorInfo[] constructorsInfos, params Type[] argsTypes)
        {
            if (FindConstructor(constructorsInfos, argsTypes) is ConstructorInfo constructor)
                return constructor;
            var constructorParametersMinCount =
                 constructorsInfos?.Min(x => x.GetParameters()?.Length) ?? 0;
            constructorsInfos =
                constructorsInfos?.Where(
                    x => x?.GetParameters()?.Length ==
                    constructorParametersMinCount)?.ToArray();
            var constructorInfo =
                constructorsInfos.FirstOrDefault(x =>
                ConstructorFullNameProperty.GetValue(x)?.ToString().Contains("*") == false);
            return constructorInfo =
                 default == constructorInfo ?
                 constructorsInfos.FirstOrDefault() : constructorInfo;
        }

        /// <summary>
        /// 查找指定参数类型的构造函数
        /// </summary>
        /// <param name="constructorsInfos"></param>
        /// <param name="argsTypes"></param>
        /// <returns></returns>
        public ConstructorInfo FindConstructor(params Type[] argsTypes)
        {
            return FindConstructor(Constructors, argsTypes);
        }

        /// <summary>
        /// 查找指定参数类型的构造函数
        /// </summary>
        /// <param name="constructorsInfos"></param>
        /// <param name="argsTypes"></param>
        /// <returns></returns>
        public static ConstructorInfo FindConstructor(ConstructorInfo[] constructorsInfos, params Type[] argsTypes)
        {
            if (argsTypes?.Length > 0
                  && constructorsInfos?.Length > 0)
            {
                //优先获取公开非静态
                Func<ConstructorInfo, bool> predicate = x => x.IsPublic && !x.IsStatic;
                var con = FindConstructorByPredicate(constructorsInfos, argsTypes, predicate);
                if (con != default)
                    return con;
                //然后获取公开静态
                predicate = x => x.IsPublic;
                con = FindConstructorByPredicate(constructorsInfos, argsTypes, predicate);
                if (con != default)
                    return con;
                //最后不做限制
                predicate = default;
                con = FindConstructorByPredicate(constructorsInfos, argsTypes, predicate);
                if (con != default)
                    return con;
            }
            else
            {
                //优先获取公开非静态 参数为0
                return constructorsInfos?.FirstOrDefault(x =>
                x?.GetParameters()?.Length == 0
                && x?.IsPublic == true
                && x?.IsStatic==false) ??
                //然后获取公开静态 参数为0
                constructorsInfos?.FirstOrDefault(x =>
                x?.GetParameters()?.Length == 0
                && x?.IsPublic == true) ??
                //最后获取参数为0
                constructorsInfos?.FirstOrDefault(x =>
                x?.GetParameters()?.Length == 0);
            }
            return default;
        }


        /// <summary>
        /// 通过筛选表达式查找构造函数
        /// </summary>
        /// <param name="constructorsInfos"></param>
        /// <param name="argsTypes"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public ConstructorInfo FindConstructorByPredicate(Type[] argsTypes, Func<ConstructorInfo, bool> predicate)
        {
            return FindConstructorByPredicate(Constructors, argsTypes, predicate);
        }

        /// <summary>
        /// 通过筛选表达式查找构造函数
        /// </summary>
        /// <param name="constructorsInfos"></param>
        /// <param name="argsTypes"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static ConstructorInfo FindConstructorByPredicate(ConstructorInfo[] constructorsInfos, Type[] argsTypes, Func<ConstructorInfo, bool> predicate)
        {
            constructorsInfos = predicate==default?
                constructorsInfos:
                (constructorsInfos.Where(predicate)?.ToArray() ?? 
                EmptyArrays.ConstructorInfo);
            foreach (var con in constructorsInfos)
                if (con.GetParameters() is ParameterInfo[] conParameters
                        && conParameters?.Length == argsTypes?.Length)
                    for (var i = 0; i < argsTypes.Length; i++)
                        if (ReflectionHelper.InheritedSame(argsTypes[i], conParameters[i].ParameterType))
                            if (i == argsTypes.Length - 1)
                                return con;
            return default;
        }
        #endregion
        ///// <summary>
        ///// 类型全名
        ///// </summary>
        //public string TypeFullName { get; set; }
        /// <summary>
        /// 最后次调用时间
        /// </summary>
        public long LastVisitTimeStamp { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public Type Type { get; set; }
        /// <summary>
        /// 默认在ReflectHelper中CreateInstance使用的构造函数
        /// </summary>
        public ConstructorInfo Constructor { get; internal set; }

        /// <summary>
        /// 默认在ReflectHelper中CreateInstance使用的构造函数参数信息
        /// </summary>
        public ParameterInfo[] ConstructorParameters { get; internal set; }

        /// <summary>
        /// 默认在ReflectHelper中CreateInstance使用的构造函数参数
        /// </summary>
        public object[] ConstructorArgs { get; internal set; } = EmptyArrays.@object;
        /// <summary>
        /// 成员信息
        /// </summary>
        public ConstructorInfo[] Constructors { get; internal set; }
        /// <summary>
        /// 成员信息
        /// </summary>
        public MemberInfo[] Members { get; internal set; }

        /// <summary>
        /// 属性信息
        /// </summary>
        public PropertyInfo[] Properties { get; internal set; }

        /// <summary>
        /// 字段信息
        /// </summary>
        public FieldInfo[] Fields { get; internal set; }

        /// <summary>
        /// 方法信息
        /// </summary>
        public MethodInfo[] Methods { get; internal set; }

        /// <summary>
        /// 事件信息
        /// </summary>
        public EventInfo[] Events { get; internal set; }

        /// <summary>
        /// 变量信息
        /// Field & Property
        /// </summary>
        public MemberInfo[] Variables { get; internal set; }
        /// <summary>
        /// 类的特性
        /// private
        /// </summary>
        Attribute[] m_TypeAttributes;
        /// <summary>
        /// 类的特性
        /// </summary>
        public Attribute[] TypeAttributes
        {
            get
            {
                getWholeAttributes();
                return m_TypeAttributes;
            }
            internal set => m_TypeAttributes = value;
        }
        /// <summary>
        /// 所有成员的特性
        /// private
        /// </summary>
        Attribute[] m_MembersAttributes;
        /// <summary>
        /// 所有成员的特性
        /// </summary>
        public Attribute[] MembersAttributes
        {
            get
            {
                getWholeAttributes();
                return m_MembersAttributes;
            }
            internal set => m_MembersAttributes = value;
        }

        #region AttributeMethods
        /// <summary>
        /// 是否获取过特性
        /// </summary>
        bool m_GettedAttributes = false;
        /// <summary>
        /// 获取全部特性
        /// </summary>
        internal void getWholeAttributes()
        {
            lock (ms_AsyncLock)
            {
                if (!m_GettedAttributes)
                {
                    m_TypeAttributes = Type.DeclaringType
                    .GetCustomAttributes(true)?.OfType<Attribute>()?.ToArray() ??
                    EmptyArrays.Attribute;
                    if (Members?.Length > 0)
                    {
                        var attributesList = new List<Attribute>();
                        foreach (var member in Members)
                            attributesList.AddRange(
                                member.GetCustomAttributes(true)?.OfType<Attribute>()?.Where(x => 
                                !attributeExclude(x.GetType().FullName))?.ToArray() ??
                                EmptyArrays.Attribute);
                        m_MembersAttributes = attributesList.ToArray();
                    }
                    m_GettedAttributes = true;
                }
            }
        }
        /// <summary>
        /// 特性名称是否包含排除标记
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        internal bool attributeExclude(string fullName)
        {
            return AttributesExcludeFlag.Count(x => fullName.IndexOf(x) >= 0) > 0;
        }
        /// <summary>
        /// 特性名称排除的标记数组
        /// </summary>
        public static string[] AttributesExcludeFlag { get; set; } = new string[]            
        {
            "__",
            "System.Runtime",
            "System.Security",
        };
        #endregion

    }
}
