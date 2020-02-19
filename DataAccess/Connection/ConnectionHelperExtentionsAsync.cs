using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DataAccess
{
    public static class ConnectionHelperExtensionsAsync
    {
        public static async Task<IEnumerable<T>> QueryAsync<T>(this IConnectionHelper source, string query, object parameters = null)
        {
            return await source.ExecuteAsync(async c => await c.QueryAsync<T>(query, parameters));
        }

        public static async Task<T> QueryFirstOrDefaultAsync<T>(this IConnectionHelper source, string query, object parameters = null)
        {
            return await source.ExecuteAsync(async c => await c.QueryFirstOrDefaultAsync<T>(query, parameters));
        }

        public static async Task<int> ExecuteRetAsync(this IConnectionHelper source, string command, object parameters = null)
        {
           return await source.ExecuteAsync(async c => await c.ExecuteAsync(command, parameters));
        }

        public static async void ExecuteAsync(this IConnectionHelper source, string command, object parameters = null)
        {
            await source.ExecuteAsync(async c => await c.ExecuteAsync(command, parameters));
        }
    }
}
