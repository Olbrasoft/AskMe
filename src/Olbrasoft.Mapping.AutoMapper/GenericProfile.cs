using AutoMapper;

namespace Olbrasoft.Mapping.AutoMapper
{
    public abstract class GenericProfile<TSource, TDestination> : Profile
    {
        protected IMappingExpression<TSource, TDestination> Expression;

        protected GenericProfile()
        {
            Expression = CreateMap<TSource, TDestination>();
        }
    }
}