using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel.Net
{
    public static class CompilerHelper
    {
        //        using System;
        //using System.Collections.Generic;
        //using System.Linq;
        //using System.Runtime.CompilerServices;
        //using System.Text;
        //using Roc.Kernel.Strings;

        /// <summary>
        /// 引用空间模板
        /// </summary>
        public static string UsingTemplate { get; } =
            string.Format(@"{0}\r\n{1}\r\n{2}\r\n{3}\r\n{4}\r\n",
                $@"using System;" +
                $@"using System.Collections.Generic;" +
                $@"using System.Linq; " +
                $@"using System.Runtime.CompilerServices;" +
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
        public static void Compile()
        {
            // The C# code to execute
            string code = "using System; " +
                          "using System.IO; " +
                          "public class MyClass{ " +
                          "   public static void PrintConsole(string message){ " +
                          "       Console.WriteLine(message); " +
                          "   } " +
                          "} ";

            // Compiler and CompilerParameters
            CSharpCodeProvider codeProvider = new CSharpCodeProvider();
            CompilerParameters compParameters = new CompilerParameters();

            // Compile the code
            CompilerResults res = codeProvider.CompileAssemblyFromSource(compParameters, code);

            // Create a new instance of the class 'MyClass'　　　　// 有命名空间的，需要命名空间.类名
            object myClass = res.CompiledAssembly.CreateInstance("MyClass");

            // Call the method 'PrintConsole' with the parameter 'Hello World'
            // "Hello World" will be written in console
            myClass.GetType().GetMethod("PrintConsole").Invoke(myClass, new object[] { "Hello World" });
        }
    }
}
