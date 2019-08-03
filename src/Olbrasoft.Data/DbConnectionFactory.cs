using System;
using System.Data;

namespace Olbrasoft.Data
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly Func<IDbConnection> _buildConnection;

        public DbConnectionFactory(Func<IDbConnection> buildConnection)
        {
            _buildConnection = buildConnection;
        }

        public IDbConnection OpenConnection()
        {
            var dbConn = CreateConnection();
            dbConn.Open();
            return dbConn;
        }

        public IDbConnection CreateConnection()
        {
            return _buildConnection();
        }
    }
}