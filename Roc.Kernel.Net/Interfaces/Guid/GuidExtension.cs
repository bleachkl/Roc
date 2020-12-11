using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel
{
    public static class GuidHelper
    {
        /// <summary>
        /// 生成一个Guid
        /// Guid格式 00000000-0000-0000-0000-000000000000
        /// 返回一个guid字符串
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string GenerateGuid()
        {
            return Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 新建一个Guid
        /// Guid格式 00000000-0000-0000-0000-000000000000
        /// 返回一个Guid对象
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static Guid CreateGuid()
        {
            return Guid.NewGuid();
        }
    }
    /// <summary>
    /// 实现Guid的拓展
    /// </summary>
    public static class GuidExtension
    {
        /// <summary>
        /// 空Guid
        /// </summary>
        public static Guid EmptyGuid { get; internal set; } = Guid.Empty;

        /// <summary>
        /// 空Guid字符串
        /// </summary>
        public static string EmptyGuidString { get; internal set; } = "00000000-0000-0000-0000-000000000000";
        /// <summary>
        /// Guid模板字符串
        /// </summary>
        internal static string ms_GuidStringTemplate { get; set; } = "{########}-{###1}-{###2}-{###3}-{############}";
        /// <summary>
        /// 生成一个Guid
        /// Guid格式 00000000-0000-0000-0000-000000000000
        /// 返回一个guid字符串
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string GenerateGuid(this object instance)
        {
            return Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 新建一个Guid
        /// Guid格式 00000000-0000-0000-0000-000000000000
        /// 返回一个Guid对象
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static Guid CreateGuid(this object instance)
        {
            return Guid.NewGuid();
        }
        /// <summary>
        /// 生成一个Guid指定guid
        /// 传入的guid必须是一个标准Guid字符串
        /// 00000000-0000-0000-0000-000000000000
        /// 返回一个guid字符串
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static string GenerateGuid(this object instance, string guid)
        {
            Guid newGuid;
            if (Guid.TryParse(guid, out newGuid))
                return newGuid.ToString();
            return EmptyGuid.ToString();
        }
        /// <summary>
        /// 新建一个Guid指定guid
        /// 传入的guid必须是一个标准Guid字符串
        /// 00000000-0000-0000-0000-000000000000
        /// 返回一个Guid对象
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static Guid CreateGuid(this object instance, string guid)
        {
            Guid newGuid;
            if (Guid.TryParse(guid, out newGuid))
                return newGuid;
            return EmptyGuid;
        }
    }
}
