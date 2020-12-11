using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace Roc.Kernel
{
    /// <summary>
    /// Type帮助类
    /// </summary>
    public static class TypeHelper
    {
        /// <summary>
        /// 判断2个类型数组集合是否相同
        /// </summary>
        /// <param name="types"></param>
        /// <param name="compareTypes"></param>
        /// <returns></returns>
        public static bool Equal(IEnumerable<Type> types, IEnumerable<Type> compareTypes)
        {
            var typesArray = types?.ToArray() ?? EmptyArrays.Type;
            var compareTypesArray = types?.ToArray() ?? EmptyArrays.Type;
            if (typesArray.Length == compareTypesArray.Length)
                if (typesArray.Length == 0)
                    return true;
                else
                    for (var i = 0; i < typesArray.Length; i++)
                        if (i == typesArray.Length - 1
                            && typesArray[i].FullName == compareTypesArray[i].FullName
                            && typesArray[i].AssemblyQualifiedName == compareTypesArray[i].AssemblyQualifiedName)
                            return true;
                        else if (typesArray[i].FullName != compareTypesArray[i].FullName
                            || typesArray[i].AssemblyQualifiedName != compareTypesArray[i].AssemblyQualifiedName)
                            break;
            return false;
        }
        /// <summary>
        /// 获取parameterinfo的类型数组
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Type[] ToArrayType(params ParameterInfo[] parameters)
        {
            return parameters?.Length > 0 ?
                parameters.Select(x => x.ParameterType).ToArray() :
                EmptyArrays.Type;
        }
    }
}
