using Roc.Kernel;
using Roc.Kernel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.TestWpf
{
    public class MainViewModel : NotifyObject
    {
        /// <summary>    
        ///  Title 标题
        ///  protected internal 
        /// </summary>
        protected internal string m_Title = "Roc测试";
        /// <summary>
        /// Title 标题
        /// </summary>
        public virtual string Title
        {
            get => m_Title;
            set => Set(ref m_Title, value);
        }
    }
    [ViewName(typeof(ClsA))]
    public class ClsA : NotifyObject
    {
        [DataField]
        public override string Guid { get => base.Guid; set => Set(ref m_Guid, value); }
        [Index(1)]
        [DataField]
        public virtual int Index { get; set; }
    }
    [Index(3)]
    public class ClsB : ClsA
    {
        [Index(2)]
        public override int Index { get; set; }
    }
}
