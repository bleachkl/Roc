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
        /// 类型信息字典
        /// </summary>
        internal static Dictionary<Type, ExtendTypeInfo> ms_TypesInfosDictionary { get; } = new Dictionary<Type, ExtendTypeInfo>();

        /// <summary>
        /// 获取类型信息字典
        /// 如果存在直接返回
        /// 不存在获取信息后添加返回
        /// </summary>
        /// <param name="type"></param>
        /// <returns>返回类型信息</returns>
        public static ExtendTypeInfo AddOrGetTypesInfosDictionary(Type type)
        {
            lock (ms_AsyncLock)
            {
                if (!ms_TypesInfosDictionary.ContainsKey(type))
                {
                    ms_TypesInfosDictionary.Add(type, new ExtendTypeInfo(type,
                      SearchFlag != BindingFlags.Default ?
                      SearchFlag : ms_SearchFlagDefault));
                }
                ms_TypesInfosDictionary[type].LastVisitTimeStamp = DateTime.Now.Ticks;
                return ms_TypesInfosDictionary[type];
            }
        }
        /// <summary>
        /// 成员公开方式属性的属性信息字典
        /// Type PropertyInfo 
        /// </summary>
        public static Dictionary<string, PropertyInfo> BindingFlagsPropertiesInfos { get; } = new Dictionary<string, PropertyInfo>();
        /// <summary>
        /// 添加或获取成员公开方式属性的属性信息字典
        /// </summary>
        /// <param name="memberInfo"></param>
        /// <returns></returns>
        public static PropertyInfo AddOrGetBindingFlagsPropertiesInfos(MemberInfo memberInfo)
        {
            lock (ms_AsyncLock)
            {
                if (memberInfo?.GetType() is Type memberInfoType)
                {
                    if (!BindingFlagsPropertiesInfos.ContainsKey(memberInfoType.FullName))
                        if (memberInfo.GetType().GetMembers(ms_SearchFlagDefault).FirstOrDefault(x => x.Name == "BindingFlags")
                            is PropertyInfo bindingFlagProperty)
                            BindingFlagsPropertiesInfos.Add(memberInfoType.FullName, bindingFlagProperty);
                    if (BindingFlagsPropertiesInfos.ContainsKey(memberInfoType.FullName))
                        return BindingFlagsPropertiesInfos[memberInfoType.FullName];
                }
                return default;
            }
        }
        /// <summary>
        /// 事件event的默认委托集合
        /// </summary>
        public static Dictionary<FieldInfo, Delegate> EventsDefaultDelegate { get; internal set; } = new Dictionary<FieldInfo, Delegate>();
        /// <summary>
        /// 获取或添加事件event的默认委托集合
        /// 有返回
        /// 没有则进行添加
        /// </summary>
        /// <param name="eventFieldInfo"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static Delegate AddOrGetEventsDefaultDelegate(FieldInfo eventFieldInfo, object instance)
        {
            lock (ms_AsyncLock)
            {
                if (!EventsDefaultDelegate.ContainsKey(eventFieldInfo))
                    EventsDefaultDelegate.Add(eventFieldInfo, default);
                if (EventsDefaultDelegate[eventFieldInfo] == default)
                    EventsDefaultDelegate[eventFieldInfo] = eventFieldInfo.GetValue(eventFieldInfo.IsStatic ? null : instance) as Delegate;
                return EventsDefaultDelegate[eventFieldInfo];
            }
        }
        /// <summary>
        /// 更新或添加事件event的默认委托集合
        /// 有更新对应的Value
        /// 没有则进行添加并赋值
        /// </summary>
        /// <param name="eventFieldInfo"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static Delegate AddOrUpdateEventsDefaultDelegate(FieldInfo eventFieldInfo, Delegate del)
        {
            lock (ms_AsyncLock)
            {
                if (!EventsDefaultDelegate.ContainsKey(eventFieldInfo))
                    EventsDefaultDelegate.Add(eventFieldInfo, default);
                EventsDefaultDelegate[eventFieldInfo] = del;
                return EventsDefaultDelegate[eventFieldInfo];
            }
        }
        /// <summary>
        /// 事件event的默认参数集合
        /// </summary>
        public static Dictionary<Type, ParameterInfo[]> EventsParameters { get; internal set; } = new Dictionary<Type, ParameterInfo[]>();
        /// <summary>
        /// 获取或添加事件event的默认参数集合
        /// </summary>
        /// <param name="eventInfo"></param>
        /// <returns></returns>
        public static ParameterInfo[] AddOrGetEventParameters(EventInfo eventInfo)
        {
            lock (ms_AsyncLock)
            {
                if (eventInfo != default)
                    if (!EventsParameters.ContainsKey(eventInfo.EventHandlerType))
                        if (GetMethodInfo(eventInfo.EventHandlerType, "Invoke") is MethodInfo eventMethod)
                            EventsParameters.Add(eventInfo.EventHandlerType,
                                eventMethod.GetParameters() ?? EmptyArrays.ParameterInfo);
                return EventsParameters[eventInfo.EventHandlerType];
            }
        }
    }
}
