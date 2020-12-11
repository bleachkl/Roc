using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Roc.Kernel.Extensions.ForRefelctionExpression
{
    public static partial class ExpressionExtension
    {
        /// <summary>
        /// 通过Expression获取要读取的变量名称集合
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static List<string> ToVariablesNames(this Expression expression)
        {
            if (default == expression)
                return default;
            var tp = expression.GetType();
            if (expression is LambdaExpression lambdaExpression
                && lambdaExpression?.Body is NewExpression newExpression)
            {
                if (newExpression.Members?.Count > 0)
                {
                    return newExpression.Members.Select(x => x.Name)?.ToList();
                }
            }
            return default;
        }

        /// <summary>
        /// 通过Expression获取单个的成员名称
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string ToMemberName(this Expression expression)
        {
            if (default == expression)
                return default;
            var tp = expression.GetType();
            if (expression is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }
            else if (expression is LambdaExpression lambdaExpression)
            {
                return ToMemberName(lambdaExpression.Body);
            }
            else if (expression is MethodCallExpression methodCallExpression)
            {
                return methodCallExpression.Method.Name;
            }
            return default;
        }
    }
}
