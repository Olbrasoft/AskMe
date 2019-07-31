namespace Olbrasoft.Querying.Business
{
    public class AwesomeServiceWithQueryFactory :ServiceWithQueryFactory
    {
        public AwesomeServiceWithQueryFactory(IQueryFactory factory) : base(factory)
        {
        }

        public void CallGetQuery()
        {
            GetQuery<Query<bool>>();
        }
    }
}