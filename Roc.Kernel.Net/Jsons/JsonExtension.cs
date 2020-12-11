using Roc.Kernel.Extensions.ForString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel.Extensions.ForJson
{
    /// <summary>
    /// Json拓展
    /// </summary>
    public static class JsonExtension
    {
        /// <summary>
        /// 将一个对象序列化为fastjson格式
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string ToJson(this object instance)
        {
            return FastJson.JSON.ToNiceJSON(instance);
        }
        /// <summary>
        /// 将一个fastjson序列化为对象
        /// </summary>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static object JsonTo(this string jsonStr)
        {
            if(!jsonStr.IsNullOrEmpty())            
                return FastJson.JSON.ToObject(jsonStr);
            return default;
        }
        /// <summary>
        /// 将一个fastjson序列化为指定类型的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static T JsonTo<T>(this string jsonStr)
        {
            if (!jsonStr.IsNullOrEmpty())
                return FastJson.JSON.ToObject<T>(jsonStr);
            return default;
        }
    }
}
