using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel.Compilers
{
    /// <summary>
    /// 编译器帮助类
    /// </summary>
    public static class CompilerHelper
    {

        public static void CompileDemo()
        {
            // The C# code to execute
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;");
            sb.Append(Environment.NewLine);
            sb.Append("namespace DynamicCodeGenerate");
            sb.Append(Environment.NewLine);
            sb.Append("{");
            sb.Append(Environment.NewLine);
            sb.Append("    public class HelloWorld");
            sb.Append(Environment.NewLine);
            sb.Append("    {");
            sb.Append(Environment.NewLine);
            sb.Append("        public string OutPut()");
            sb.Append(Environment.NewLine);
            sb.Append("        {");
            sb.Append(Environment.NewLine);
            sb.Append("             return \"Hello world!\";");
            sb.Append(Environment.NewLine);
            sb.Append("        }");
            sb.Append(Environment.NewLine);
            sb.Append("    }");
            sb.Append(Environment.NewLine);
            sb.Append("}");

            string code = sb.ToString();

            // 1.创建编译器
            CSharpCodeProvider csPrivoder = new CSharpCodeProvider();

            // 2.创建编译参数
            CompilerParameters compilerParameter = new CompilerParameters();
            //compilerParameter.ReferencedAssemblies.Add("System.dll");
            //compilerParameter.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            //compilerParameter.GenerateExecutable = true;
            //compilerParameter.GenerateInMemory = false;
            compilerParameter.OutputAssembly = "111.dll";
            //compilerParameter.CompilerOptions = "/optimize";

            // 3.获得编译结果
            string sCode = "namespace TEST\r\n" +
                "{\r\n" +
                "public class Testcls\r\n" +
                "{\r\n";
            sCode += " ";
            sCode += "public int MYId{get;set;}\r\n" +            
                "}\r\n" +
                "}";
            CompilerResults compilerResult = csPrivoder.CompileAssemblyFromSource(compilerParameter, sCode);
            if (compilerResult.Errors.Count > 0)
            { }
            //if (results.Errors.Count > 0)
            //{
            //    textBox2.ForeColor = Color.Red;
            //    foreach (CompilerError CompErr in results.Errors)
            //    {
            //        textBox2.Text = textBox2.Text +
            //                    "Line number " + CompErr.Line +
            //                    ", Error Number: " + CompErr.ErrorNumber +
            //                    ", '" + CompErr.ErrorText + ";" +
            //                    Environment.NewLine + Environment.NewLine;
            //    }
            //}
            //else
            //{
            //    //Successful Compile
            //    textBox2.ForeColor = Color.Blue;
            //    textBox2.Text = "Success!";
            //    //If we clicked run then launch our EXE
            //    if (ButtonObject.Text == "Run") Process.Start(Output);
            //}
        }

        /// <summary>
        /// 引用空间模板
        /// </summary>
        public static string UsingTemplate { get; } =
            string.Format(@"{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n",
                $@"using System;",
                $@"using System.Collections.Generic;",
                $@"using System.Linq; ",
                $@"using System.Runtime.CompilerServices;",
                $@"using System.Text");
        /// <summary>
        /// 将命名空间转为类似于using System;这样的引用字符串
        /// </summary>
        /// <param name="namespace"></param>
        /// <returns></returns>
        public static string ToUsingNamespace(string @namespace)
        {
            return $"{{using {@namespace};}}";
        }
        /// <summary>
        /// C#编译器
        /// </summary>
        internal static CSharpCodeProvider ms_CodeProvider = new CSharpCodeProvider();
        internal static CompilerParameters ms_CompilerParameters = new CompilerParameters();
        public static void Complie(string code, CompilerParameters compilerParameters = default)
        {
            
        }
    }
}
