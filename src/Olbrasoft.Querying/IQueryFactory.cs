namespace Olbrasoft.Querying
{
    public interface IQueryFactory
    {
        /// <summary>
        /// CreateQuery query
        /// </summary>
        /// <typeparam name="T">Type of concrete query</typeparam>
        /// <returns>Query</returns>
        T CreateQuery<T>() where T : IQuery;
        
    }
}