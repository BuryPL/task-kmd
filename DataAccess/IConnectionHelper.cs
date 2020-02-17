using System;
using System.Data;

namespace DataAccess
{
    public interface IConnectionHelper
    {
        T Execute<T>(Func<IDbConnection, T> getData);
    }
}