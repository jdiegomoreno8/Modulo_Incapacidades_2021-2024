using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace LibreriasIncapacidades.AccesoDatos
{
	public class DapperWrapper : IDapperWrapper
	{
		public IEnumerable<T> Query<T>(IDbConnection connection, string sql, CommandType commandType)
		{
			return connection.Query<T>(sql, commandType);
		}

		public IEnumerable<T> Query<T>(IDbConnection connection, string sql, object param, CommandType commandType)
		{
			return connection.Query<T>(sql, param, commandType:commandType);
		}

		public IEnumerable<T> Query<T>(IDbConnection connection, string sql, Type[] types, Func<object[], T> map, object param = null, IDbTransaction transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = null, CommandType? commandType = null)
        {
			return connection.Query<T>(sql, types, map, param, splitOn: splitOn, commandType: commandType);
		}

		public int Execute(IDbConnection connection, string sql, object param, CommandType commandType)
		{
			return connection.Execute(sql, param, commandType: commandType);
		}
	}
}
