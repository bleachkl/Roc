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
        /// 竞争操作时的一部锁对象
        /// async
        /// </summary>
        internal static readonly object ms_AsyncLock = new object();

        /// <summary>
        /// 默认查找级别标记
        /// </summary>
        internal const BindingFlags ms_SearchFlagDefault =
            BindingFlags.Public | BindingFlags.NonPublic
            | BindingFlags.Instance | BindingFlags.Static
            | BindingFlags.FlattenHierarchy;
        /// <summary>
        /// 查找级别标记
        /// </summary>
        public static BindingFlags SearchFlag { get; internal set; } = BindingFlags.Default;
        /// <summary>
        /// 设置查找级别标记
        /// 设置为Default时资源字典将以系统默认级别
        /// </summary>
        /// <param name="searchFlag"></param>
        public static void SetSearchFlag(BindingFlags searchFlag)
        {
            SearchFlag = searchFlag;
        }
       

        /// <summary>
        /// 强制转换值
        /// </summary>
        /// <param name="val"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static object Cast(object val, 
            Type targetType)
        {
            if (val?.GetType() == targetType)
                return val;
            var tVal = (val is IConvertible
                       && targetType.IsAssignableFrom(Types.IConvertible))
                       || Types.ValuesTypes.Contains(targetType) ?
                       Convert.ChangeType(val, targetType) : val;
            if (InheritedSame(val?.GetType(), targetType) == true)
                return tVal;
            if (targetType.IsEnum)
                tVal = Enum.Parse(targetType, tVal?.ToString());
            else if (Types.Strings.Contains(tVal?.GetType()) == true)
            {
                var members = targetType.GetMember("Parse", ms_SearchFlagDefault);
                foreach (var member in members)
                    if (member is MethodInfo methodInfo
                             && default !=
                             methodInfo.GetParameters()?.FirstOrDefault(
                                 x => Types.Strings.Contains(x.ParameterType))
                             && methodInfo?.IsStatic == true)
                        tVal = methodInfo.Invoke(null, new object[] { tVal });
            }
            return tVal;
        }

        /// <summary>
        /// 强制转换值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <returns></returns>
        public static object Cast<T>(object val)
        {
            return Cast(val, typeof(T));
        }

        /// <summary>
        /// 获取成员的公开方式属性
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static BindingFlags GetBindingFlags(MemberInfo memberInfo)
        {
            if (AddOrGetBindingFlagsPropertiesInfos(memberInfo) is PropertyInfo propertyInfo
              && propertyInfo?.GetValue(memberInfo)
                        is BindingFlags bindingFlag)
                return bindingFlag;
            return BindingFlags.Default;
        }

        #region 成员信息 MembersInfos
        /// <summary>
        /// 获取对应类型的成员集合
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="bindingFlag">查找标记</param>
        /// <param name="memberCategory">要获取的成员类型类别</param>
        /// <returns></returns>
        public static MemberInfo[] GainMembers(Type type, 
            BindingFlags bindingFlag, 
            MemberCategories memberCategory)
        {
            if (type == default)
                return EmptyArrays.MemberInfo;
            AddOrGetTypesInfosDictionary(type);
            switch (memberCategory)
            {
                case MemberCategories.Member:
                    return ms_TypesInfosDictionary[type].Members?.Where(x =>
                    (GetBindingFlags(x) & bindingFlag) > 0)?.ToArray() ??
                    EmptyArrays.MemberInfo;
                case MemberCategories.Property:
                    return ms_TypesInfosDictionary[type].Properties?.Where(x =>
                    (GetBindingFlags(x) & bindingFlag) > 0)?.ToArray() ??
                    EmptyArrays.PropertyInfo;
                case MemberCategories.Field:
                    return ms_TypesInfosDictionary[type].Fields?.Where(x =>
                    (GetBindingFlags(x) & bindingFlag) > 0)?.ToArray() ??
                    EmptyArrays.FieldInfo;
                case MemberCategories.Method:
                    return ms_TypesInfosDictionary[type].Methods?.Where(x =>
                    (GetBindingFlags(x) & bindingFlag) > 0)?.ToArray() ??
                    EmptyArrays.MethodInfo;
                case MemberCategories.EventInfo:
                    return ms_TypesInfosDictionary[type].Events?.Where(x =>
                    (GetBindingFlags(x) & bindingFlag) > 0)?.ToArray() ??
                    EmptyArrays.EventInfo;
                case MemberCategories.Variable:
                    return ms_TypesInfosDictionary[type].Variables?.Where(x =>
                    (GetBindingFlags(x) & bindingFlag) > 0)?.ToArray() ??
                    EmptyArrays.MemberInfo;
                default:
                    return EmptyArrays.MemberInfo;
            }
        }

        /// <summary>
        /// 获取对应类型的成员集合
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static MemberInfo[] GainMembers(Type type, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return GainMembers(type, bindingFlag.ToBindingFlags(), MemberCategories.Member);
        }
        #endregion

        #region 属性信息 PropertyInfo
        /// <summary>
        /// 获取对应类型的属性信息集合
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static PropertyInfo[] GainProperties(Type type, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return GainMembers(type, bindingFlag.ToBindingFlags(),
                     MemberCategories.Property)?.Cast<PropertyInfo>()?.ToArray() ??
                     EmptyArrays.PropertyInfo;
        }
        /// <summary>
        /// 获取对应类型的属性名称信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="propertyName"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static PropertyInfo GainProperty(Type type, 
            string propertyName, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return (GainProperties(type, bindingFlag.ToBindingFlags())?.ToArray() ??
                      EmptyArrays.PropertyInfo)?.FirstOrDefault(x =>
                      x?.Name == propertyName) ?? default;
        }

        /// <summary>
        /// 获取对应类型的属性名称信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static PropertyInfo GainProperty<T>(Expression<Func<T, object>> expression, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return GainProperty(typeof(T), expression.ToMemberName(), bindingFlag.ToBindingFlags());
        }

        /// <summary>
        /// 获取对应实例的属性值
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="propertyName"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static object GetProperty(object instance, 
            string propertyName, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            if (GainProperty(instance?.GetType(), propertyName, bindingFlag.ToBindingFlags()) 
                is PropertyInfo propertyInfo)
                return propertyInfo.GetValue(IsStatic(propertyInfo) ? null : instance);
            return default;
        }

        /// <summary>
        /// 设置对应实例的属性值
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="propertyName"></param>
        /// <param name="val"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static Exception SetProperty(object instance, 
            string propertyName, 
            object val, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            if (GainProperty(instance?.GetType(), propertyName, bindingFlag.ToBindingFlags())
             is PropertyInfo propertyInfo)
                propertyInfo.SetValue(IsStatic(propertyInfo) ? null : instance,
                    Cast(val, propertyInfo.PropertyType));
            return default;
        }
        #endregion

        #region 字段信息 FieldInfo
        /// <summary>
        /// 获取对应类型的字段信息集合
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static FieldInfo[] GainFields(Type type, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return GainMembers(type, bindingFlag.ToBindingFlags(),
                   MemberCategories.Field)?.Cast<FieldInfo>()?.ToArray() ??
                   EmptyArrays.FieldInfo;
        }

        /// <summary>
        /// 获取对应类型的字段名称信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="fieldName"></param>
        public static FieldInfo GetFieldInfo(Type type, 
            string fieldName, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return (GainFields(type, bindingFlag.ToBindingFlags())?.ToArray() ??
                      EmptyArrays.FieldInfo)?.FirstOrDefault(x =>
                      x?.Name == fieldName) ?? default;
        }

        /// <summary>
        /// 获取对应类型的字段名称信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="propertyName"></param>
        public static FieldInfo GetFieldInfo<T>(Expression<Func<T, object>> expression, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return GetFieldInfo(typeof(T), expression.ToMemberName(), bindingFlag.ToBindingFlags());
        }

        /// <summary>
        /// 获取对应实例的字段值
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static object GetField(object instance, 
            string fieldName, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            if(GetFieldInfo(instance?.GetType(), fieldName, bindingFlag.ToBindingFlags()) 
                is FieldInfo fieldInfo)
                return fieldInfo.GetValue(IsStatic(fieldInfo) ? null : instance);
            return default;
        }
        /// <summary>
        /// 设置对应实例的属性值
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="fieldName"></param>
        /// <param name="val"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static Exception SetField(object instance, 
            string fieldName, 
            object val, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            if (GetFieldInfo(instance?.GetType(), fieldName, bindingFlag.ToBindingFlags()) 
                is FieldInfo fieldInfo)
                fieldInfo.SetValue(IsStatic(fieldInfo) ? null : instance, Cast(val,fieldInfo.FieldType));
            return default;
        }
        #endregion

        #region 变量信息 VariableInfo
        /// <summary>
        /// 获取对应类型的变量信息集合
        /// 包含Properties Fields
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static MemberInfo[] GainVairables(Type type, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return GainMembers(type, bindingFlag.ToBindingFlags(),
                  MemberCategories.Variable)?.Cast<MemberInfo>()?.ToArray() ??
                  EmptyArrays.MemberInfo;
        }

        /// <summary>
        /// 获取对应实例的变量信息
        /// Field | Property
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="fieldName"></param>
        public static MemberInfo GainVairable(Type type, 
            string fieldName, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return (GainVairables(type, bindingFlag.ToBindingFlags())?.ToArray() ??
                       EmptyArrays.MemberInfo)?.FirstOrDefault(x =>
                     x?.Name == fieldName) ?? default;
        }

        /// <summary>
        /// 获取对应实例的变量信息
        /// Field | Property
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="propertyName"></param>
        public static MemberInfo GainVairable<T>(Expression<Func<T, object>> expression, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return GainVairable(typeof(T), expression.ToMemberName(), bindingFlag.ToBindingFlags());
        }

        /// <summary>
        /// 获取对应实例的变量值
        /// Field | Property
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static object GetVariable(object instance, 
            string fieldName, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            bindingFlag = bindingFlag.ToBindingFlags();
            if (GainVairable(instance?.GetType(), fieldName, bindingFlag.ToBindingFlags()) is MemberInfo variableInfo)
                if (variableInfo is FieldInfo fieldInfo)
                    return GetField(instance, fieldInfo.Name, bindingFlag);
                else if (variableInfo is PropertyInfo propertyInfo)
                    return GetProperty(instance, propertyInfo.Name, bindingFlag);
            return default;
        }
        /// <summary>
        /// 对对应实例的变量进行赋值
        /// Field | Property
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="fieldName"></param>
        /// <param name="val"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static Exception SetVariable(object instance, 
            string fieldName, 
            object val, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            bindingFlag = bindingFlag.ToBindingFlags();
            if (GainVairable(instance?.GetType(), fieldName, bindingFlag.ToBindingFlags()) is MemberInfo variableInfo)
                if (variableInfo is FieldInfo fieldInfo)
                    return SetField(instance, fieldInfo.Name, val, bindingFlag);
                else if (variableInfo is PropertyInfo propertyInfo)
                    return SetProperty(instance, propertyInfo.Name, val, bindingFlag);
            return default;
        }
        #endregion

        #region 方法信息 MethodInfo
        /// <summary>
        /// 获取对应类型的方法信息集合
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static MethodInfo[] GainMethods(Type type,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return GainMembers(type, bindingFlag.ToBindingFlags(),
                     MemberCategories.Method)?.Cast<MethodInfo>()?.ToArray() ??
                     EmptyArrays.MethodInfo;
        }

        /// <summary>
        /// 获取对应类型的方法名称信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="methodName"></param>
        public static MethodInfo GetMethodInfo(Type type, 
            string methodName, 
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return (GainMethods(type, bindingFlag.ToBindingFlags())?.ToArray() ??
                      EmptyArrays.MethodInfo)?.FirstOrDefault(x =>
                      x?.Name == methodName) ?? default;
        }

        /// <summary>
        /// 获取对应类型的方法名称信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="propertyName"></param>
        public static MethodInfo GetMethodInfo<T>(Expression<Action<T>> expression,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return GetMethodInfo(typeof(T), expression.ToMemberName(), bindingFlag.ToBindingFlags());
        }
        /// <summary>
        /// 调用对象中的方法
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="methodName"></param>
        /// <param name="action"></param>
        /// <param name="parms"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static Exception InvokeMethod(object instance, 
            string methodName, 
            object[] parms=null,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            parms = parms ?? EmptyArrays.@object;
            if (GetMethodInfo(instance?.GetType(), methodName, bindingFlag.ToBindingFlags()) 
                is MethodInfo methodInfo)
                methodInfo.Invoke(IsStatic(methodInfo) ? null : instance, parms);
            return default;
        }
        #endregion        
    }
}
