using Roc.Kernel.Extensions.ForIO;
using Roc.Kernel.Extensions.ForJson;
using Roc.Kernel.Extensions.ForString;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Roc.Kernel.Reflections
{
    /// <summary>
    /// 程序集信息
    /// </summary>
    public class AssemblyInfo : IDisposable
    {
        /// <summary>
        /// 竞争操作时的一部锁对象
        /// async
        /// </summary>
        internal static readonly object ms_AsyncLock = new object();
        ~ AssemblyInfo()
        {
            Dispose();
        }
        public virtual void Dispose()
        {
            Assembly = default;
            m_ExtendInfos?.Clear();
            m_ExtendInfos = default;
            m_FilePath = default;
        }
        public AssemblyInfo()
        {

        }
        const string mc_FileExtensionName = ".ead";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="category"></param>
        /// <param name="fileExtensionName"></param>
        public AssemblyInfo(Assembly assembly,
            string category, 
            string fileExtensionName = mc_FileExtensionName)
        {
            Assembly = assembly;
            Category = category;
            FileExtensionName = fileExtensionName;
            GetExtendInfosFile();
            ReadExtendInfos();
        }
        /// <summary>
        /// 获取显示名称
        /// </summary>
        /// <param name="type"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public string GetValue(Type type, string member= null)
        {
            if (GetExtendInfoKey(type, member) is string fullName
                && ExtendInfos.ContainsKey(fullName))
                return ExtendInfos[fullName];
            return default;
        }
        /// <summary>
        /// 获取包含有程序集显示名称的字典文件路径
        /// </summary>
        /// <returns></returns>
        public string GetExtendInfosFile()
        {
            return FilePath = GetExtendInfosFile(Assembly, Category, FileExtensionName);
        }
        const string mc_Folder = nameof(AssemblyInfo);
        /// <summary>
        /// 文件夹路径
        /// </summary>
        public string Folder { get; } = mc_Folder;
        /// <summary>
        /// 信息类型
        /// </summary>
        public string Category { get; internal set; }
        /// <summary>
        /// 文件拓展名
        /// </summary>
        public string FileExtensionName { get; internal set; }
        /// <summary>
        /// 程序集信息一个程序集信息对应一个ExtendInfos文件
        /// </summary>
        public Assembly Assembly { get; internal set; }
        /// <summary>
        /// 是否读取过
        /// FilePath变化时自动变化为false
        /// </summary>
        bool m_HasRead = false;
        /// <summary>
        /// ExtendInfos文件路径
        /// </summary>
        private string m_FilePath;
        /// <summary>
        /// ExtendInfos文件路径
        /// </summary>
        public string FilePath
        {
            get => m_FilePath;
            internal set
            {
                m_HasRead = value.IsNullOrEmpty() ?
                    true : object.Equals(value, m_FilePath);
                m_FilePath = value;
            }
        }
        /// <summary>
        /// 显示名称 ExtendInfos
        /// </summary>
        private Dictionary<string, string> m_ExtendInfos =
         new Dictionary<string, string>();
        /// <summary>
        /// 显示名称 ExtendInfos
        /// </summary>
        public Dictionary<string, string> ExtendInfos
        {
            get => m_ExtendInfos;
            internal set
            {
                m_ExtendInfos = value;
            }
        }
        /// <summary>
        /// 读取ExtendInfos字典
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> ReadExtendInfos()
        {
            if (!m_HasRead)
                m_ExtendInfos = ReadExtendInfos(FilePath) ??
                    new Dictionary<string, string>();
            m_HasRead = true;
            return m_ExtendInfos;
        }
        /// <summary>
        /// 生成ExtendInfos路径
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="folder"></param>
        /// <param name="fileExtensionName"></param>
        /// <returns></returns>
        public static string GetExtendInfosFile(Assembly assembly, 
            string category, 
            string fileExtensionName = mc_FileExtensionName)
        {
            return Path.Combine(assembly.ManifestModule.FullyQualifiedName.GetDirectory(),
                $"{mc_Folder}",
                $"{category}",
                $"{assembly.ManifestModule.Name.Substring(0, assembly.ManifestModule.Name.LastIndexOf(strings.ENPeriod))}" +
                $"{fileExtensionName}");
        }
        /// <summary>
        /// 从指定path中读取ExtendInfos字典
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ReadExtendInfos(string path)
        {
            lock (ms_AsyncLock)
                if (!path.FileExit())
                {
                    var demoDic = new Dictionary<string, string>();
                    demoDic.Add("FullPropertyName", "Value");
                    demoDic.Add("System.Windows.Window.Title", "Title");
                    path.WriteText(demoDic.ToJson());
                }
            return path?.ReadText()?.JsonTo<Dictionary<string, string>>();
        }
        /// <summary>
        /// 获取ExtendInfoKey
        /// 即显示名称的键值
        /// </summary>
        /// <param name="type"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static string GetExtendInfoKey(Type type, string member=null)
        {
            if(member.IsNullOrEmpty())
                return $"{type.FullName}";
            else
                return $"{type.FullName}{strings.ENPeriod}{member}";
        }
    }
}
