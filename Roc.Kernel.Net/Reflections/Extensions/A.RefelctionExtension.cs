using Roc.Kernel.Reflections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
/// <summary>
///反射拓展
/// </summary>
namespace Roc.Kernel.Extensions.ForRefelction
{
    /// <summary>
    /// 反射拓展
    /// </summary>
    public static partial class RefelctionExtension
    {

        /// <summary>
        /// 设置查找级别标记
        /// 设置为Default时资源字典将以系统默认级别
        /// </summary>
        /// <param name="searchFlag"></param>
        public static void SetSearchFlag(this BindingFlags searchFlag)
        {
            ReflectionHelper.SetSearchFlag(searchFlag);
        }

        /// <summary>
        /// 强制转换值
        /// </summary>
        /// <param name="val"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static object Cast(this object val,
            Type targetType)
        {
            return ReflectionHelper.Cast(val, targetType);
        }

        /// <summary>
        /// 强制转换值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="val"></param>
        /// <returns></returns>
        public static object Cast<T>(object val)
        {
            return ReflectionHelper.Cast<T>(val);
        }

        /// <summary>
        /// 获取成员的公开方式属性
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static BindingFlags GetBindingFlags(this MemberInfo memberInfo)
        {
            return ReflectionHelper.GetBindingFlags(memberInfo);
        }
        #region 成员信息 MembersInfos
        /// <summary>
        /// 获取对应类型的成员集合
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="bindingFlag">查找标记</param>
        /// <param name="memberCategory">要获取的成员类型类别</param>
        /// <returns></returns>
        public static MemberInfo[] GainMembers(this Type type,
            BindingFlags bindingFlag,
            MemberCategories memberCategory)
        {
            return ReflectionHelper.GainMembers(type, bindingFlag, memberCategory);
        }

        /// <summary>
        /// 获取对应类型的成员集合
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static MemberInfo[] GainMembers(this Type type,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GainMembers(type, bindingFlag);
        }
        /// <summary>
        /// 获取对应类型的成员集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="carrier">调用的载体</param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static MemberInfo[] GainMembers<T>(this object carrier,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GainMembers(typeof(T), bindingFlag);
        }
        /// <summary>
        /// 获取对应类型的成员集合
        /// </summary>
        /// <param name="instance">要获取成员信息的对象</param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static MemberInfo[] GainMembers(this object instance,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GainMembers(instance?.GetType(), bindingFlag);
        }
        #endregion

        #region 属性信息 PropertyInfo
        /// <summary>
        /// 获取对应类型的属性集合
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static PropertyInfo[] GainProperties(this Type type,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GainProperties(type, bindingFlag);
        }
        /// <summary>
        /// 获取对应类型的属性名称信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="propertyName"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static PropertyInfo GainProperty(this Type type,
            string propertyName,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GainProperty(type, propertyName, bindingFlag);
        }
        /// <summary>
        /// 获取对应类型的属性名称信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">调用的实例</param>
        /// <param name="expression">T对应的表达式</param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static PropertyInfo GainProperty<T>(this T instance,
            Expression<Func<T, object>> expression,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GainProperty(expression, bindingFlag);
        }
        /// <summary>
        /// 获取对应类型的属性名称信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="carrier">调用的载体</param>
        /// <param name="expression">T对应的表达式</param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static PropertyInfo GainProperty<T>(this object carrier,
            Expression<Func<T, object>> expression,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GainProperty(expression, bindingFlag);
        }
        /// <summary>
        /// 获取对应实例的属性值
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="propertyName"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static object GetProperty(this object instance,
            string propertyName,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GetProperty(instance, propertyName, bindingFlag);
        }

        /// <summary>
        /// 设置对应实例的属性值
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="propertyName"></param>
        /// <param name="val"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static Exception SetProperty(this object instance,
            string propertyName,
            object val,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.SetProperty(instance, propertyName, val, bindingFlag);
        }
        #endregion

        #region 字段信息 FieldInfo
        /// <summary>
        /// 获取对应类型的字段集合
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static FieldInfo[] GainFields(this Type type,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GainFields(type, bindingFlag);
        }

        /// <summary>
        /// 获取对应类型的字段名称信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="fieldName"></param>
        public static FieldInfo GetFieldInfo(this Type type,
            string fieldName,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GetFieldInfo(type, fieldName, bindingFlag);
        }
        /// <summary>
        /// 获取对应类型的字段名称信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">调用的实例</param>
        /// <param name="expression">T对应的表达式</param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static FieldInfo GetFieldInfo<T>(this T instance,
          Expression<Func<T, object>> expression,
          BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GetFieldInfo(expression, bindingFlag);
        }
        /// <summary>
        /// 获取对应类型的字段名称信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="carrier">调用的载体</param>
        /// <param name="expression">T对应的表达式</param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static FieldInfo GetFieldInfo<T>(this object carrier,
            Expression<Func<T, object>> expression,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GetFieldInfo(expression, bindingFlag);
        }

        /// <summary>
        /// 获取对应实例的字段值
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static object GetField(this object instance,
            string fieldName,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GetField(instance, fieldName, bindingFlag);
        }
        /// <summary>
        /// 设置对应实例的属性值
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="fieldName"></param>
        /// <param name="val"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static Exception SetField(this object instance,
            string fieldName,
            object val,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.SetField(instance, fieldName, val, bindingFlag);
        }
        #endregion

        #region 变量信息 VariableInfo
        /// <summary>
        /// 获取对应类型的变量集合
        /// 包含Properties Fields
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static MemberInfo[] GainVairables(this Type type,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GainVairables(type, bindingFlag);
        }

        /// <summary>
        /// 获取对应实例的变量信息
        /// Field | Property
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="fieldName"></param>
        public static MemberInfo GainVairable(this Type type,
            string fieldName,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GainVairable(type, fieldName, bindingFlag);
        }
        /// <summary>
        /// 获取对应实例的变量信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">调用的实例</param>
        /// <param name="expression">T对应的表达式</param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static MemberInfo GainVairable<T>(this T instance,
           Expression<Func<T, object>> expression,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GainVairable(expression, bindingFlag);
        }
        /// <summary>
        /// 获取对应实例的变量信息
        /// Field | Property
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="carrier">调用的载体</param>
        /// <param name="expression">T对应的表达式</param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static MemberInfo GainVairable<T>(this object carrier,
            Expression<Func<T, object>> expression,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GainVairable(expression, bindingFlag);
        }

        /// <summary>
        /// 获取对应实例的变量值
        /// Field | Property
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static object GetVariable(this object instance,
            string fieldName,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GetVariable(instance, fieldName, bindingFlag);
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
        public static Exception SetVariable(this object instance,
            string fieldName,
            object val,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.SetVariable(instance, fieldName, bindingFlag);
        }
        #endregion

        #region 方法信息 MethodInfo
        /// <summary>
        /// 获取对应类型的方法集合
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static MethodInfo[] GainMethods(this Type type,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GainMethods(type, bindingFlag);
        }

        /// <summary>
        /// 获取对应类型的方法名称信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="methodName"></param>
        public static MethodInfo GetMethodInfo(this Type type,
            string methodName,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GetMethodInfo(type, methodName, bindingFlag);
        }
        /// <summary>
        /// 获取对应类型的方法名称信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">调用的实例</param>
        /// <param name="expression">T对应的表达式</param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static MethodInfo GetMethodInfo<T>(this T instance,
            Expression<Action<T>> expression,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GetMethodInfo(expression, bindingFlag);
        }
        /// <summary>
        /// 获取对应类型的方法名称信息
        /// </summary>
        /// <typeparam name="T">指定类型</typeparam>
        /// <param name="carrier">调用的载体</param>
        /// <param name="expression">T表达式</param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static MethodInfo GetMethodInfo<T>(this object carrier,
            Expression<Action<T>> expression,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.GetMethodInfo(expression, bindingFlag);
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
        public static Exception InvokeMethod(this object instance,
            string methodName,
            object[] parms = null,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return ReflectionHelper.InvokeMethod(instance, methodName, parms, bindingFlag);
        }
        #endregion        
    }
}
