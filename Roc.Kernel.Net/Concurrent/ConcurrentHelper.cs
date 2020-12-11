using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel.Concurrent
{
    /// <summary>
    /// 表示对象的线程安全的集合帮助类
    /// </summary>
    public static class ConcurrentHelper
    {
        /// <summary>
        /// 转换为常规数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conList"></param>
        /// <returns></returns>
        public static T[] ToArrayNormal<T>(ConcurrentBag<T> conList)
        {
            return conList?.ToArray()?.Reverse()?.ToArray();
        }
        /// <summary>
        /// 获取索引
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conList"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static int IndexOf<T>(ConcurrentBag<T> conList, T item, Predicate<T> predicate = default)
        {
            if (ToArrayNormal(conList) is T[] arrayT)
                return predicate == default?
                    Array.IndexOf(arrayT, item) :
                    Array.FindIndex(arrayT, predicate);
            return -1;
        }
    }
}
