namespace Olbrasoft.Data.Querying
{
    public interface IQueryHandler<in TQuery, TResult> : IHandle<TQuery, TResult>, IHandleAsync<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}