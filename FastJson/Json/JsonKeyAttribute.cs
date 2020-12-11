using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace FastJson
{
    /// <summary>
    /// 表示是一个Json属性或字段
    /// </summary>
    public class JsonKeyAttribute : Attribute
    {
        /// <summary>
        /// 表示是一个Json属性或字段
        /// </summary>
        public JsonKeyAttribute()
        {
        }
        /// <summary>
        /// 表示是一个Json属性或字段
        /// 并指定Json的键名
        /// </summary>
        public JsonKeyAttribute(string jsonKey,
            [CallerMemberName] string variableName = "")
        {
            m_JsonKey = jsonKey;
        }
        /// <summary>
        /// 签名名称特性
        /// 参数 1 成员所属类型
        /// 参数 2 被标记Property或Field
        /// </summary>
        /// <param name="callerType">成员所属类型</param>
        /// <param name="jsonKey">默认名称</param>
        /// <param name="variableName">被标记Property或Field名称</param>
        public JsonKeyAttribute(Type callerType, 
            string jsonKey="",
            [CallerMemberName] string variableName = "")
        {
            m_JsonKey = GetExtendValue<JsonKeyAttribute>(callerType, variableName);
            m_JsonKey = string.IsNullOrEmpty(m_JsonKey) ? jsonKey : m_JsonKey;
            m_JsonKey = string.IsNullOrEmpty(m_JsonKey) ? variableName : m_JsonKey;
            m_VariableName = variableName;
        }
        const string mc_FileExtensionName = ".ead";

        const string mc_Folder = "AssemblyInfo";

        static readonly object lockobj = new object();// string mc_FileExtensionName = ".ead";
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
            var assembly = type.Assembly;
            var category = typeof(T).FullName;
            //D:\FXk1ng(框架)\Roc\Roc.TestWpf\bin\Debug\Roc.TestWpf.exe
            var assemblyP = assembly.ManifestModule.FullyQualifiedName.Substring(0,
                assembly.ManifestModule.FullyQualifiedName.LastIndexOf("\\"));
            var path = Path.Combine(assemblyP,
                $"{mc_Folder}",
                $"{category}",
                $"{assembly.ManifestModule.Name.Substring(0, assembly.ManifestModule.Name.LastIndexOf("."))}" +
                $"{mc_FileExtensionName}");
            if (File.Exists(path))
            {
                lock (lockobj)
                {
                    //var cnt = System.IO.File.ReadAllText(path); 
                    if (!hasReadedDictionary.ContainsKey(path))
                    {
                        hasReadedDictionary.Add(path, true);
                        ms_ExtendInfos = JSON.ToObject<Dictionary<string, string>>(System.IO.File.ReadAllText(path));
                    }
                }
                var fullName = string.Empty;
                if (string.IsNullOrEmpty(member))
                    fullName = $"{type.FullName}";
                else
                    fullName = $"{type.FullName}.{member}";
                if (ms_ExtendInfos.ContainsKey(fullName))
                    return ms_ExtendInfos[fullName];
                return default;
            }
            else
            {
                lock (lockobj)
                {
                    if (!System.IO.File.Exists(path))
                    {
                        var demoDic = new Dictionary<string, string>();
                        demoDic.Add("FullPropertyName", "Value");
                        demoDic.Add("System.Windows.Window.Title", "Title");
                        var fileinfo = new FileInfo(path);
                        if (!(fileinfo.Directory?.Exists == true))
                            fileinfo.Directory.Create();
                        System.IO.File.WriteAllText(path, JSON.ToNiceJSON(demoDic), System.Text.Encoding.UTF8);
                    }
                }
            }
            //ReadExtendInfos();
            return default;
        }
        internal static Dictionary<string, bool> hasReadedDictionary = new Dictionary<string, bool>();
        static bool m_HasRead = false;
        static Dictionary<string, string> ms_ExtendInfos { get; set; } = new Dictionary<string, string>();
        /// <summary>
        /// 对应的Json键名
        /// 为空时表示属性或字段明为键名
        /// </summary>
        private string m_JsonKey;
        /// <summary>
        /// 对应的Json键名
        /// 为空时表示属性或字段明为键名
        /// </summary>
        public string JsonKey => m_JsonKey;
        /// <summary>
        /// 被标记Property或Field名称
        /// protected internal
        /// </summary>
        protected internal string m_VariableName;
        /// <summary>
        /// 被标记Property或Field名称
        /// </summary>
        public string VariableName => m_VariableName;
    }
}