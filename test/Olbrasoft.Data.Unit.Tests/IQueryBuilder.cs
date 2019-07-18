using System;
using System.Linq.Expressions;
using Olbrasoft.Data.Querying;

namespace Olbrasoft.Data.Unit.Tests
{
    public interface IQueryBuilder
    {
        TQuery Build<TQuery>() where TQuery : IQuery;

        TQuery Build<TQuery>(Expression<Func<TQuery,object>> memberSelector, object value) where TQuery : IQuery;
    }
}