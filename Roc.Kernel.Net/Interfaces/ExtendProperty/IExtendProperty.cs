using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel
{
    //thick; thick and big; bulky; loudhuge
    /// <summary>
    /// 增强类属性相关操作接口
    /// 实现IGuid.Guid Guid
    /// 实现IDirective.Directive 操作指令
    /// </summary>
    public interface IExtendProperty : 
        IGuid, IDirective, 
        IGrabChangedProperties, IPropertySet, 
        IOnlyExecuteOnPropertyChanged, IBeforePropertySet, 
        IPropertyChanged, IDisposable
    {

    }
}
