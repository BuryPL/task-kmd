using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<T> ExecuteAsync<T>(Func<IDbConnection, Task<T>> getData)
        {
            using (DbConnection conn = System.Data.SqlClient.SqlClientFactory.Instance.CreateConnection())
            {
                conn.ConnectionString = _connectionString;
                await conn.OpenAsync();

                return await getData(conn);
            }
        }
    }
}
