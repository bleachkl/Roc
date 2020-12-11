using System;

namespace FastJson
{
    /// <summary>
    /// 标识类只会有特性标记的属性才会序列化
    /// 被标记的类只有属性被标记为JsonKey才会被Json序列化
    /// </summary>
    public class JsonPartAttribute : Attribute
    {
        /// <summary>
        /// 标识类只会有特性标记的属性才会序列化
        /// 被标记的类只有属性被标记为JsonKey才会被Json序列化
        /// </summary>
        public JsonPartAttribute()
        {

        }
    }
}