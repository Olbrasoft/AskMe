using System.Data;

namespace Olbrasoft.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection OpenConnection();

        IDbConnection CreateConnection();
    }
}