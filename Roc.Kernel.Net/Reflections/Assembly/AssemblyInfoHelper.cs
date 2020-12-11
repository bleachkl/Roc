using FastJson;
using Roc.Kernel.Attributes;
using Roc.Kernel.Extensions.ForString;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel.Reflections
{
    /// <summary>
    /// 程序集帮助类
    /// </summary>
    public static class AssemblyHelper
    {
        static AssemblyHelper()
        {
        }
        /// <summary>
        /// 竞争操作时的一部锁对象
        /// async
        /// </summary>
        internal static readonly object ms_AsyncLock = new object();
        /// <summary>
        /// 存储程序集信息的字典
        /// </summary>
        internal static ConcurrentBag<AssemblyInfo> ms_ViewNamesInfos = new ConcurrentBag<AssemblyInfo>();
        /// <summary>
        /// 添加或获取
        /// </summary>
        /// <param name="type"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public static AssemblyInfo AddOrGet(Type type, string category)
        {
            lock (ms_AsyncLock)
            {
                var viewNamesInfo = ms_ViewNamesInfos.FirstOrDefault(x => x.Assembly == type.Assembly
                && x.Category == category);
                if (viewNamesInfo == default)
                    ms_ViewNamesInfos.Add(viewNamesInfo = new AssemblyInfo(type.Assembly,
                        category));
                return viewNamesInfo;
            }
        }
        /// <summary>
        /// 获取显示名称路径
        /// </summary>
        /// <param name="type"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string GetValuePath(Type type, string member)
        {
            if(member.IsNullOrEmpty())
                return $"{type.FullName}";
            else
                return $"{type.FullName}.{member}";
        }
        /// <summary>
        /// 获取拓展字典中的对应值
        /// category 分类名称
        /// type 类型
        /// member 成员名称
        /// </summary>
        /// <param name="category"></param>
        /// <param name="type"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string GetExtendValue(string category, Type type, string member)
        {
            if (AddOrGet(type, category) is AssemblyInfo viewNamesInfo)
                return viewNamesInfo.GetValue(type, member);
            return default;
        }
        /// <summary>
        /// 获取拓展字典中的对应值
        /// <T>用指定类型名称做分类名称
        /// type 类型
        /// member 成员名称
        /// </summary>
        /// <param name="T">用指定类型名称做分类名称</param>
        /// <param name="type"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string GetExtendValue<T>(Type type, string member)
        {
            return GetExtendValue(typeof(T).FullName, type, member);
        }
        public static string[] Categories { get; set; } = new string[]            
        {
            typeof(ViewNameAttribute).FullName,
            typeof(ViewIndexAttribute).FullName,
            typeof(DataFieldAttribute).FullName,
            typeof(IdentifyAttribute).FullName,
            typeof(SignAttribute).FullName,
            typeof(IndexAttribute).FullName,
            typeof(JsonKeyAttribute).FullName,
        };
        /// <summary>
        /// 初始化
        /// 参数 1 是否生成拓展文件
        /// 可通过完全限定名的KeyValue进行特性配置
        /// 例如 "System.Windows.Window.Title" : "Title"
        /// </summary>
        /// <param name="generateAttributeExtendFile">是否生成属性拓展文件</param>
        public static void Initial(bool generateAttributeExtendFile = true)
        {
            if (generateAttributeExtendFile)
            {
                typeof(ExtendInfoClass).GetCustomAttribute<ViewNameAttribute>();
                typeof(ExtendInfoClass).GetCustomAttribute<ViewIndexAttribute>();
                typeof(ExtendInfoClass).GetCustomAttribute<DataFieldAttribute>();
                typeof(ExtendInfoClass).GetCustomAttribute<IdentifyAttribute>();
                typeof(ExtendInfoClass).GetCustomAttribute<SignAttribute>();
                typeof(ExtendInfoClass).GetCustomAttribute<IndexAttribute>();
                typeof(ExtendInfoClass).GetCustomAttribute<JsonKeyAttribute>();
            }
        }
    }
    [DataField(typeof(ExtendInfoClass))]
    [Identify(typeof(ExtendInfoClass))]
    [ViewName(typeof(ExtendInfoClass))]
    [ViewIndex(typeof(ExtendInfoClass))]
    [JsonKey(typeof(ExtendInfoClass))]
    [Index(typeof(ExtendInfoClass))]
    [Sign(typeof(ExtendInfoClass))]
    public abstract class ExtendInfoClass
    {
        
    }
}
