using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel.IOs
{
    // <summary>
    /// 文件/文件夹打开关闭保存帮助类
    /// </summary>
    public partial class SelectFolderFileHelper
    {
        /// <summary>
        /// 选择打开文件路径
        /// </summary>
        /// <param name="defaultpath"></param>
        /// <param name="filter"></param>
        /// <param name="defaultext"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string SelectOpenFile(string defaultpath = null, string filter = null, string defaultext = null, string filename = null)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = filter ?? "All files(*.*)|*.*";
            if (!string.IsNullOrWhiteSpace(defaultext))
            {
                openFileDialog.DefaultExt = defaultext;
            }
            openFileDialog.InitialDirectory = defaultpath;
            if (!string.IsNullOrWhiteSpace(filename))
            {
                openFileDialog.FileName = filename;
            }
            bool? result = openFileDialog.ShowDialog();
            //点了ok按钮进入
            if (result == true)
            {
                return openFileDialog.FileName;
            }
            return string.Empty;
        }
        /// <summary>
        /// 选择保存文件路径
        /// </summary>
        /// <param name="defaultpath"></param>
        /// <param name="filter"></param>
        /// <param name="defaultext"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string SelectSaveFile(string defaultpath = null, string filter = null, string defaultext = null, string filename = null)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = filter ?? "All files(*.*)|*.*";
            if (!string.IsNullOrWhiteSpace(defaultext))
            {
                saveFileDialog.DefaultExt = defaultext;
            }
            saveFileDialog.InitialDirectory = defaultpath;
            if (!string.IsNullOrWhiteSpace(filename))
            {
                saveFileDialog.FileName = filename;
            }
            bool? result = saveFileDialog.ShowDialog();
            //点了ok按钮进入
            if (result == true)
            {
                return saveFileDialog.FileName;
            }
            return string.Empty;
        }
        /// <summary>
        /// 选择文件夹路径
        /// </summary>
        /// <param name="defdir"></param>
        /// <returns></returns>
        public static string SelectFolder(string defdir = null)
        {
            WPFFolderBrowser.WPFFolderBrowserDialog folderBrowserDialog = new WPFFolderBrowser.WPFFolderBrowserDialog() { FileName = defdir ?? string.Empty };
            var selected = (bool)folderBrowserDialog.ShowDialog();
            if (selected)
            {
                return folderBrowserDialog.FileName;
            }
            return string.Empty;
        }
    }
}
