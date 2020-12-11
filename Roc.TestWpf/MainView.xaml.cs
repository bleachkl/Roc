using Roc.Kernel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Roc.TestWpf
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = ViewModel;
        }
        public MainViewModel ViewModel { get; set; } = new MainViewModel();

        private void btn_tstDymAtt_Click(object sender, RoutedEventArgs e)
        {
            this.txt_DymAtt.Text = typeof(ClsA).GetCustomAttribute<ViewNameAttribute>().ViewName;
        }
    }
}
