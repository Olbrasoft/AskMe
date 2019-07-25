namespace Olbrasoft.Querying.DependencyInjection
{
    public class AwesomeQuery:Query<bool>
    {
        public AwesomeQuery(IQueryDispatcher dispatcher) : base(dispatcher)
        {
        }
    }
}
