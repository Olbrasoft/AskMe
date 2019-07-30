using Olbrasoft.Mapping;

namespace Olbrasoft.Commanding.Mapping
{
    public abstract class CommandHandlerWithMapper<TCommand> : CommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly IMapper _mapper;

        protected CommandHandlerWithMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        protected TDestination MapTo<TDestination>(object source)
        {
            return _mapper.MapTo<TDestination>(source);
        }
    }
}