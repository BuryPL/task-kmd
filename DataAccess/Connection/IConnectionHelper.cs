using System;
using System.Data;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IConnectionHelper
    {
        Task<T> ExecuteAsync<T>(Func<IDbConnection, Task<T>> getData);
    }
}