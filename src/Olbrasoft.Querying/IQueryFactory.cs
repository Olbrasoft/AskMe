namespace Olbrasoft.Querying
{
    public interface IQueryFactory
    {
        /// <summary>
        /// Create query
        /// </summary>
        /// <typeparam name="T">Type of concrete query</typeparam>
        /// <returns>Query</returns>
        T Create<T>() where T : IQuery;
        
    }
}