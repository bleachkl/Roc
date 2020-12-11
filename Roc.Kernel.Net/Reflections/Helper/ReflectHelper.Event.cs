using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Roc.Kernel.Extensions.ForRefelctionExpression;
using Roc.Kernel.Extensions.ForType;

namespace Roc.Kernel.Reflections
{
    /// <summary>
    /// 反射帮助类
    /// </summary>
    public static partial class ReflectionHelper
    {
        #region 事件信息 EventInfo
        /// <summary>
        /// 获取对应类型的事件信息集合
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        public static EventInfo[] GainEvents(Type type,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return GainMembers(type, bindingFlag.ToBindingFlags(),
                    MemberCategories.EventInfo)?.Cast<EventInfo>()?.ToArray() ??
                   EmptyArrays.EventInfo;
        }

        /// <summary>
        /// 获取对应类型的事件信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="eventName"></param>
        public static EventInfo GainEvent(Type type,
            string eventName,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return (GainEvents(type, bindingFlag.ToBindingFlags())?.ToArray() ??
                      EmptyArrays.EventInfo)?.FirstOrDefault(x =>
                      x?.Name == eventName) ?? default;
        }

        /// <summary>
        /// 获取对应类型的事件信息
        /// </summary>
        /// <param name="type"></param>
        /// <param name="bindingFlag"></param>
        /// <param name="propertyName"></param>
        public static EventInfo GainEvent<T>(Expression<Func<T, object>> expression,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            return GainEvent(typeof(T), expression.ToMemberName(), bindingFlag.ToBindingFlags());
        }

        /// <summary>
        /// 尝试添加对象委托事件
        /// 目标方法名称目标方法参数需符合事件参数否则会创建失败
        /// 参数 1 创建对象委托事件的对象或静态事件所属对象类型
        /// 参数 2 创建对象委托事件名称
        /// 参数 3 目标方法名称目标方法参数需符合事件参数
        /// 参数 4 委托事件所在载体或静态委托事件所在对象类型  为null时默认会将instance作为method载体
        /// 参数 5 创建对象委托事件的要插入的索引 如果为-1表示默认在最后插入 如果index超出list范围也会在最后插入
        /// 参数 6 创建对象委托事件的公开程度
        /// </summary>
        /// <param name="instance">创建对象委托事件的对象或静态事件所属对象类型</param>
        /// <param name="eventName">创建对象委托事件名称</param>
        /// <param name="methodName">目标方法名称目标方法参数需符合事件参数</param>
        /// <param name="methodCarrier">委托事件所在载体或静态委托事件所在对象类型  为null时默认会将instance作为method载体</param>
        /// <param name="index"> 创建对象委托事件的要插入的索引 如果为-1表示默认在最后插入 如果index超出list范围也会在最后插入</param>
        /// <param name="bindingFlag">创建对象委托事件的公开程度</param>
        /// <returns>创建的委托</returns>
        public static Delegate AttachEvent(object instance, 
            string eventName, 
            string methodName, 
            object methodCarrier = null,
            int index = -1,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            try
            {
                methodCarrier = methodCarrier == default ? instance : methodCarrier;
                if ((instance is Type ? instance : instance?.GetType()) is Type instanceType
                    && GainEvent(instanceType, eventName, bindingFlag.ToBindingFlags())
                    is EventInfo eventInfo)
                    if (GetFieldInfo(instanceType, eventInfo.Name) is FieldInfo eventFieldInfo)
                        if (GetMethodInfo(methodCarrier is Type ?
                            methodCarrier as Type : methodCarrier?.GetType(), methodName)
                            is MethodInfo methodInfo
                            && AddOrGetEventParameters(eventInfo).ToArrayType() is Type[] eventParametersTypes
                            && methodInfo.GetParameters().ToArrayType() is Type[] methodParametersTypes
                            && eventParametersTypes.Equal(methodParametersTypes))
                            if ((methodInfo.IsStatic ?
                                Delegate.CreateDelegate(eventInfo.EventHandlerType,
                                methodCarrier as Type ?? methodCarrier?.GetType() ?? Types.@object,
                                methodName) :
                                Delegate.CreateDelegate(eventInfo.EventHandlerType,
                                methodCarrier,
                                methodName)) is Delegate del)
                            {
                                var eventdel = AddOrGetEventsDefaultDelegate(eventFieldInfo, instance);
                                var delArray = eventdel?.GetInvocationList() ?? EmptyArrays.Delegate;
                                if (index < 0 || index >= delArray.Length)
                                    eventdel = eventdel != default ? Delegate.Combine(eventdel, del) : del;
                                else
                                {
                                    var delList = delArray.ToList();
                                    delList.Insert(index, del);
                                    delArray = delList.ToArray();
                                    eventdel = Delegate.Combine(delArray);
                                }
                                eventFieldInfo.SetValue(eventFieldInfo.IsStatic ? null : instance, 
                                    AddOrUpdateEventsDefaultDelegate(eventFieldInfo, eventdel));
                                return eventdel;
                            }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return default;
        }

        /// <summary>
        /// 尝试添加对象委托事件
        /// 目标方法名称目标方法参数需符合事件参数否则会创建失败
        /// 参数 1 创建对象委托事件的对象或静态事件所属对象类型
        /// 参数 2 创建对象委托事件名称
        /// 参数 3 目标方法名称目标方法参数需符合事件参数
        /// 参数 4 委托事件所在载体或静态委托事件所在对象类型 为null时默认会将instance作为method载体
        /// 参数 5 创建对象委托事件的要插入的索引 如果为-1表示默认在最后插入 如果index超出list范围也会在最后插入
        /// 参数 6 创建对象委托事件的公开程度
        /// </summary>
        /// <param name="instance">创建对象委托事件的对象或静态事件所属对象类型</param>
        /// <param name="eventName">创建对象委托事件名称</param>
        /// <param name="methodName">目标方法名称目标方法参数需符合事件参数</param>
        /// <param name="methodCarrier">委托事件所在载体或静态委托事件所在对象类型 为null时默认会将instance作为method载体</param>
        /// <param name="index"> 创建对象委托事件的要插入的索引 如果为-1表示默认在最后插入 如果index超出list范围也会在最后插入</param>
        /// <param name="bindingFlag">创建对象委托事件的公开程度</param>
        /// <returns>创建的委托</returns>
        public static Delegate AttachEvent(object instance,
            string eventName,
            MethodInfo methodInfo,
            object methodCarrier = null,
            int index = -1,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            try
            {
                methodCarrier = methodCarrier == default ? instance : methodCarrier;
                if ((instance is Type ? instance : instance?.GetType()) is Type instanceType
                    && GainEvent(instanceType, eventName, bindingFlag.ToBindingFlags())
                    is EventInfo eventInfo)
                    if (GetFieldInfo(instanceType, eventInfo.Name) is FieldInfo eventFieldInfo)
                        if (methodInfo != default
                            && AddOrGetEventParameters(eventInfo).ToArrayType() is Type[] eventParametersTypes
                            && methodInfo.GetParameters().ToArrayType() is Type[] methodParametersTypes
                            && eventParametersTypes.Equal(methodParametersTypes))
                            if ((methodInfo.IsStatic ?
                                Delegate.CreateDelegate(eventInfo.EventHandlerType, 
                                methodInfo.DeclaringType,
                                methodInfo.Name) :
                                Delegate.CreateDelegate(eventInfo.EventHandlerType,
                                methodCarrier,
                                methodInfo.Name)) is Delegate del)
                            {
                                var eventdel = AddOrGetEventsDefaultDelegate(eventFieldInfo, instance);
                                var delArray = eventdel?.GetInvocationList() ?? EmptyArrays.Delegate;
                                if (index < 0 || index >= delArray.Length)
                                    eventdel = eventdel != default ? Delegate.Combine(eventdel, del) : del;
                                else
                                {
                                    var delList = delArray.ToList();
                                    delList.Insert(index, del);
                                    delArray = delList.ToArray();
                                    eventdel = Delegate.Combine(delArray);
                                }
                                eventFieldInfo.SetValue(eventFieldInfo.IsStatic ? null : instance,
                                    AddOrUpdateEventsDefaultDelegate(eventFieldInfo, eventdel));
                                return eventdel;
                            }
                return default;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        /// <summary>
        /// 尝试添加对象委托事件
        /// 目标方法名称目标方法参数需符合事件参数否则会创建失败
        /// 参数 1 创建对象委托事件的对象或静态事件所属对象类型
        /// 参数 2 创建对象委托事件名称
        /// 参数 3 传入的委托
        /// 参数 4 创建对象委托事件的要插入的索引 如果为-1表示默认在最后插入 如果index超出list范围也会在最后插入
        /// 参数 5 创建对象委托事件的公开程度
        /// </summary>
        /// <param name="instance">创建对象委托事件的对象或静态事件所属对象类型</param>
        /// <param name="eventName">创建对象委托事件名称</param>
        /// <param name="del">传入的委托</param>
        /// <param name="index"> 创建对象委托事件的要插入的索引 如果为-1表示默认在最后插入 如果index超出list范围也会在最后插入</param>
        /// <param name="bindingFlag">创建对象委托事件的公开程度</param>
        /// <returns>添加完成后的对象委托事件</returns>
        public static Delegate AttachEvent(object instance,
            string eventName,
            Delegate del,
            int index = -1,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            try
            {
                if ((instance is Type ? instance : instance?.GetType()) is Type instanceType
                    && GainEvent(instanceType, eventName, bindingFlag.ToBindingFlags())
                    is EventInfo eventInfo)
                    if (GetFieldInfo(instanceType, eventInfo.Name) is FieldInfo eventFieldInfo)
                    {
                        var eventdel = AddOrGetEventsDefaultDelegate(eventFieldInfo, instance);
                        var delArray = eventdel?.GetInvocationList() ?? EmptyArrays.Delegate;
                        if (index < 0 || index >= delArray.Length)
                            eventdel = eventdel != default ? Delegate.Combine(eventdel, del) : del;
                        else
                        {
                            var delList = delArray.ToList();
                            delList.Insert(index, del);
                            delArray = delList.ToArray();
                            eventdel = Delegate.Combine(delArray);
                        }
                        eventFieldInfo.SetValue(eventFieldInfo.IsStatic ? null : instance,
                            AddOrUpdateEventsDefaultDelegate(eventFieldInfo, eventdel));
                        return eventdel;
                    }
                return default;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        /// <summary>
        /// 移除事件委托
        /// 参数 1 要移除的委托事件的对象或静态事件所属对象类型
        /// 参数 2 要移除的事件名称
        /// 参数 3 要移除的事件索引要删除全部则设置为小于0的int 默认为-1删除全部
        /// 参数 4 移除对象委托事件的公开程度
        /// </summary>
        /// <param name="instance">要移除的委托事件的对象或静态事件所属对象类型</param>
        /// <param name="eventName">要移除的事件名称</param>
        /// <param name="index">要移除的事件索引要删除全部则设置为小于0的int 默认为-1删除全部</param>
        /// <param name="bindingFlag">移除对象委托事件的公开程度</param>
        /// <returns></returns>
        public static Delegate DetachEvent(object instance,
            string eventName,
            int index = -1,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            try
            {
                if ((instance is Type ? instance : instance?.GetType()) is Type instanceType
                    && GainEvent(instanceType, eventName, bindingFlag.ToBindingFlags())
                    is EventInfo eventInfo)
                    if (GetFieldInfo(instanceType, eventInfo.Name) is FieldInfo eventFieldInfo)
                        if (AddOrGetEventsDefaultDelegate(eventFieldInfo, instance) is Delegate del)
                        {
                            Delegate ndel = default;
                            if (del.GetInvocationList() is Delegate[] delArray)
                            {
                                if (index >= 0
                                       && index < delArray.Length)
                                {
                                    ndel = delArray[index];
                                    delArray[index] = null;
                                }
                                delArray = delArray?.Where(x => x != default)?.ToArray() ?? EmptyArrays.Delegate;
                                ndel = delArray.Length > 0 ? Delegate.Combine(delArray) : default;
                            }
                            eventFieldInfo.SetValue(eventFieldInfo.IsStatic ? null : instance,
                                AddOrUpdateEventsDefaultDelegate(eventFieldInfo, ndel));
                            return ndel;
                        }
                return default;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// 移除事件委托
        /// 参数 1 要移除的委托事件的对象或静态事件所属对象类型
        /// 参数 2 要移除的事件名称
        /// 参数 3 要移除的委托
        /// 参数 4 移除对象委托事件的公开程度
        /// </summary>
        /// <param name="instance">要移除的委托事件的对象或静态事件所属对象类型</param>
        /// <param name="eventName">要移除的事件名称</param>
        /// <param name="removedel">要移除的委托</param>
        /// <param name="bindingFlag">移除对象委托事件的公开程度</param>
        /// <returns></returns>
        public static Exception DetachEvent(object instance,
            string eventName,
            Delegate removedel,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            try
            {
                if ((instance is Type ? instance : instance?.GetType()) is Type instanceType
                    && GainEvent(instanceType, eventName, bindingFlag.ToBindingFlags())
                    is EventInfo eventInfo)
                    if (GetFieldInfo(instanceType, eventInfo.Name) is FieldInfo eventFieldInfo)
                        if (AddOrGetEventsDefaultDelegate(eventFieldInfo, instance) is Delegate del)
                        {
                            var delArray = del.GetInvocationList()?.Where(x => x != removedel)?.ToArray()??EmptyArrays.Delegate;
                            if(AddOrUpdateEventsDefaultDelegate(eventFieldInfo, delArray.Length > 0 ? Delegate.Combine(delArray) : default) is Delegate ndel)
                                eventFieldInfo.SetValue(eventFieldInfo.IsStatic ? null : instance, ndel);                            
                        }
                return default;
            }
            catch (Exception exception)
            {
                return exception;
            }
        }
        /// <summary>
        /// 执行事件委托
        /// 参数 1 事件载体实例或静态事件所属类型
        /// 参数 2 触发事件名称
        /// 参数 3 要触发的事件索引 执行所有设置为小于0的int 默认为-1执行所有动作
        /// 参数 4 要触发传入的方法执行参数 必须完全符合不然会调用失败 为空的情况下会自动使用参数默认值进行调用
        /// 参数 5 要执行事件的公开程度
        /// </summary>
        /// <param name="instance">事件载体实例或静态事件所属类型</param>
        /// <param name="eventName">触发事件名称</param>
        /// <param name="index">要触发的事件索引 执行所有设置为小于0的int</param>
        /// <param name="parms">要触发传入的方法执行参数 必须完全符合不然会调用失败 为空的情况下会自动使用参数默认值进行调用</param>
        /// <param name="bindingFlag">执行事件的公开程度</param>
        /// <returns>返回执行的委托</returns>
        public static Delegate ExecuteEvent(object instance,
            string eventName,
            int index = -1,
            object[] parms = null,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            parms = parms ?? EmptyArrays.@object;
            if ((instance is Type ? instance : instance?.GetType()) is Type instanceType
            && GainEvent(instanceType, eventName, bindingFlag.ToBindingFlags())
                is EventInfo eventInfo)
                if (GetFieldInfo(instanceType, eventInfo.Name) is FieldInfo eventFieldInfo)
                    if (AddOrGetEventsDefaultDelegate(eventFieldInfo, instance) is Delegate del)
                        if (del.GetInvocationList() is Delegate[] delArray)
                            if (index < delArray.Length
                                && index >= 0)
                            {
                                delArray[index].DynamicInvoke(parms.Length > 0 ?
                                     parms : ToArrayobject(delArray[index].Method.GetParameters().ToArrayType()));
                                return delArray[index];
                            }
                            else
                            {
                                for (var i = 0; i < delArray.Length; i++)
                                    delArray[i].DynamicInvoke(parms.Length > 0 ?
                                    parms : ToArrayobject(delArray[i].Method.GetParameters().ToArrayType()));
                                return del;
                            }
            return default;
        }
        
        /// <summary>
        /// 获取指定事件的委托数量
        /// -1表示为获取到事件
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="eventName"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static int GetEventDelegatesCount(object instance,         
            string eventName,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            if ((instance is Type ? instance : instance?.GetType()) is Type instanceType
            && GainEvent(instanceType, eventName, bindingFlag.ToBindingFlags())
              is EventInfo eventInfo)
                if (GetFieldInfo(instanceType, eventInfo.Name) is FieldInfo eventFieldInfo)
                    if (AddOrGetEventsDefaultDelegate(eventFieldInfo, instance) is Delegate del)
                        return (del.GetInvocationList() ?? EmptyArrays.Delegate).Length;
            return -1;
        }
        /// <summary>
        /// 获取指定事件的所有委托
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="eventName"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static Delegate[] GetEventDelegates(object instance,
            string eventName,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            if ((instance is Type ? instance : instance?.GetType()) is Type instanceType            
                && GainEvent(instanceType, eventName, bindingFlag.ToBindingFlags())              
                is EventInfo eventInfo)
                if (GetFieldInfo(instanceType, eventInfo.Name) is FieldInfo eventFieldInfo)
                    if (AddOrGetEventsDefaultDelegate(eventFieldInfo, instance) is Delegate del)
                        return del.GetInvocationList() ?? EmptyArrays.Delegate;
            return EmptyArrays.Delegate;
        }
        /// <summary>
        /// 获取指定事件的委托
        /// 包含所有委托
        /// 通过GetInvocationList()获取所有执行委托
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="eventName"></param>
        /// <param name="bindingFlag"></param>
        /// <returns></returns>
        public static Delegate GetEventDelegate(object instance,
            string eventName,
            BindingFlags bindingFlag = BindingFlags.Default)
        {
            if ((instance is Type ? instance : instance?.GetType()) is Type instanceType            
                && GainEvent(instanceType, eventName, bindingFlag.ToBindingFlags())              
                is EventInfo eventInfo)                
                if (GetFieldInfo(instanceType, eventInfo.Name) is FieldInfo eventFieldInfo)
                    if (AddOrGetEventsDefaultDelegate(eventFieldInfo, instance) is Delegate del)
                        return del;
            return default;
        }
        #endregion
    }
}
