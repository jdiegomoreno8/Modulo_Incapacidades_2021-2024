using System;
using System.Collections.Generic;
using System.Data;

namespace LibreriasAutorizaciones.AccesoDatos
{
    public interface IDapperWrapper
    {
        IEnumerable<T> Query<T>(IDbConnection connection, string sql, CommandType commandType);

        IEnumerable<T> Query<T>(IDbConnection connection, string sql, object param, CommandType commandType);

        IEnumerable<T> Query<T>(IDbConnection connection, string sql, Type[] types, Func<object[], T> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null);

        int Execute(IDbConnection connection, string sql, object param, CommandType commandType);
    }
}
