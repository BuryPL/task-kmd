using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace DataAccess
{
    public static class ConnectionHelperExtensions
    {
        public static IEnumerable<T> Query<T>(this IConnectionHelper source, string query, object parameters = null)
        {
            return source.Execute(c => c.Query<T>(query, parameters));
        }

        public static T QueryFirstOrDefault<T>(this IConnectionHelper source, string query, object parameters = null)
        {
            return source.Execute(c => c.QueryFirstOrDefault<T>(query, parameters));
        }

        public static void Execute(this IConnectionHelper source, string command, object parameters = null)
        {
            source.Execute(c => c.Execute(command, parameters));
        }
    }
}
