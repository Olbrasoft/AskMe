namespace Olbrasoft.Data.Querying
{
    public interface IQueryFactory
    {
        /// <summary>
        /// Get query
        /// </summary>
        /// <typeparam name="T">Type of concrete query</typeparam>
        /// <returns>Query</returns>
        T Get<T>() where T : IQuery;
    }
}