using AutoMapper;

namespace Altairis.AskMe.Data
{
    public abstract class MapProfile<TSource, TDestination> : Profile
    {
        protected IMappingExpression<TSource, TDestination> Expression;

        protected MapProfile()
        {
            Expression = CreateMap<TSource, TDestination>();
        }
    }
}