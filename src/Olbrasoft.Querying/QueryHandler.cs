using System.Threading;
using System.Threading.Tasks;

namespace Olbrasoft.Querying
{
    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        public TResult Handle(TQuery query)
        {
            return HandleAsync(query).Result;
        }

        public Task<TResult> HandleAsync(TQuery query)
        {
            return HandleAsync(query, default);
        }

        public abstract Task<TResult> HandleAsync(TQuery query, CancellationToken token);
    }

    
    public abstract class QueryHandler<TQuery, TSource, TResult> : QueryHandler<TQuery, TResult> where TQuery : IQuery<TResult> where TSource : class
    {
        private TSource _source;

        protected TSource Source => _source ?? (_source = GetSource());

        protected abstract TSource GetSource();
    }
}