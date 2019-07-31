namespace Olbrasoft.Querying.Business
{
    public class ServiceWithQueryFactory
    {
        private readonly IQueryFactory _factory;

        public ServiceWithQueryFactory(IQueryFactory factory)
        {
            _factory = factory;
        }

        protected TQuery GetQuery<TQuery>() where TQuery :IQuery
        {
            return _factory.CreateQuery<TQuery>();
        }
    }
}