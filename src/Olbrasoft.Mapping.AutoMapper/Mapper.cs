namespace Olbrasoft.Mapping.AutoMapper
{
    public class Mapper : IMapper
    {
        private readonly global::AutoMapper.IMapper _mapper;

        public Mapper(global::AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination MapTo<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}