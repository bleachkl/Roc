using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel
{
    //thick; thick and big; bulky; loudhuge
    /// <summary>
    /// 实现属性设定方法的接口
    /// </summary>
    public interface IPropertySet
    {
        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="fieldValue">属性对应的值字段</param>
        /// <param name="newValue">新的值</param>
        /// <param name="action">设定时关联的动作 参数1传递新的值 参数2传递原始值 参数3返回属性所属对象</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>有变化返回true,无变化返回false</returns>
        bool Set<T>(ref T fieldValue, T newValue, Action<T, T, object> action = default, [CallerMemberName] string propertyName = "");
    }
}
