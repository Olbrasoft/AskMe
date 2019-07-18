namespace Olbrasoft.Data.Querying
{
    public interface IHandle<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}