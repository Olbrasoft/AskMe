using System;
using System.Linq.Expressions;
using System.Reflection;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.Data.Unit.Tests
{
    public static class QueryExtensions
    {
        private static PropertyInfo Property<T>(Expression<Func<T, object>> property)
        {
            var lambda = (LambdaExpression)property;
            MemberExpression memberExpression;

            if (lambda.Body is UnaryExpression expression)
            {
                var unaryExpression = expression;

                memberExpression = (MemberExpression)unaryExpression.Operand;
            }
            else
            {
                memberExpression = (MemberExpression)lambda.Body;
            }

            return (PropertyInfo)memberExpression.Member;
        }

        public static T SetAndReturn<T, TValue>(this T target, Expression<Func<T, object>> memberSelector, TValue value) where T : IQuery
        {
            var property = Property(memberSelector);

            if (property != null)
            {
                property.SetValue(target, value, null);
            }

            return target;
        }
    }
}