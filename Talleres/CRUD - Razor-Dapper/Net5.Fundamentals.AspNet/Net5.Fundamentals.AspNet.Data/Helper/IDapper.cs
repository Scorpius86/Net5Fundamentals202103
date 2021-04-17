using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Net5.Fundamentals.AspNet.Data.Helper
{
    public interface IDapper
    {
        int Execute(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);
        T Get<T>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);
        List<T> GetAll<T>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);
        DbConnection GetDbConnection();
        T Insert<T>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string sql, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure);
    }
}