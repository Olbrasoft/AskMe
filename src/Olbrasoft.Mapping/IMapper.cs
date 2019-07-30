namespace Olbrasoft.Mapping
{
    
    public interface IMapper
    {
        TDestination MapTo<TDestination>(object source);
    }
    
  
}