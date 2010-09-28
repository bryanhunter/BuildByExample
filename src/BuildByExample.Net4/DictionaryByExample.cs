using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BuildByExample
{
    public static class DictionaryByExample
    {
        public static Dictionary<string, object> Build<T>(Expression<Func<T>> typeInitializer)
        {
            var initExpression = typeInitializer.Body as MemberInitExpression;

            if (initExpression == null)
                throw new ArgumentException(
                    "The typeInitializer's Body must be a MemberInitExpression (e.g. ()=> new GoodViewModel {Id=42}).");

            return initExpression.Bindings
                .ToDictionary(x => x.Member.Name, x => GetConstantExpression(((MemberAssignment)x).Expression).Value);
        }

        private static ConstantExpression GetConstantExpression(Expression expression)
        {
            if (expression.NodeType == ExpressionType.Constant) return expression as ConstantExpression;

            Type type = expression.Type;

            if (type.IsValueType)
            {
                expression = Expression.Convert(expression, typeof(object));
            }

            Expression<Func<object>> lambda = Expression.Lambda<Func<object>>(expression);
            Func<object> compiledFunc = lambda.Compile();

            return Expression.Constant(compiledFunc(), type);
        }
    }
}