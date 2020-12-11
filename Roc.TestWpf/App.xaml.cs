using FastJson;
using Roc.Kernel;
using Roc.Kernel.Attributes;
using Roc.Kernel.Extensions.ForJson;
using Roc.Kernel.Extensions.ForRefelction;
using Roc.Kernel.Extensions.ForString;
using Roc.Kernel.Reflections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Roc.TestWpf
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    [Description("App")]
    public partial class App : Application
    {
        [ViewName(typeof(App))]
        [ViewIndex(typeof(App))]
        [Index(typeof(App))]
        [Identify(typeof(App))]
        [DataField(typeof(App))]
        [Sign(typeof(App))]
        [JsonKey(typeof(App))]
        public string Index { get; set; }
        public static string AppDir { get; } = new FileInfo(typeof(App).Assembly.Location).DirectoryName;
        protected override void OnStartup(StartupEventArgs e)
        {
           
            base.OnStartup(e);
        }
    }
}
