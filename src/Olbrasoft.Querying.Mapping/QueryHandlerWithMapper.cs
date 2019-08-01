using Olbrasoft.Mapping;

namespace Olbrasoft.Querying.Mapping
{
    public abstract class QueryHandlerWithMapper<TQuery, TResult> : QueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly IMapper _mapper;

        protected QueryHandlerWithMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected TDestination MapTo<TDestination>(object source)
        {
            return _mapper.MapTo<TDestination>(source);
        }

    }
}