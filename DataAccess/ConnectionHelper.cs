using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DataAccess
{
    public sealed class ConnectionHelper : IConnectionHelper
    {
        private readonly string _connectionString;

        public ConnectionHelper(string connectionString)
        {
            if(string.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException();

            _connectionString = connectionString;
        }

        public T Execute<T>(Func<IDbConnection, T> getData)
        {
            using (DbConnection conn = System.Data.SqlClient.SqlClientFactory.Instance.CreateConnection())
            {
                conn.ConnectionString = _connectionString;
                conn.Open();

                return getData(conn);
            }
        }
    }
}
