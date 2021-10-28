using DatabaseIManager;
using DatabaseResult;
using Microsoft.Extensions.Configuration;
using System;
using Npgsql;
using System.Data;

namespace DatabaseManager_PostgreSql
{
    public class DatabaseManager : IDatabaseManager
    {
        public const string ConnectionStringSectionName = "DevForPostgreSql";

        private readonly IConfiguration _config;
        public DatabaseManager(IConfiguration config)
        {
            _config = config;
        }

        public DbResult ExecuteQuery(string qry)
        {
            try
            {
                var connectionString = _config.GetConnectionString(ConnectionStringSectionName);
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(qry, connection))
                    {
                        cmd.Prepare();
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        DataSet _ds = new DataSet();
                        DataTable _dt = new DataTable();
                        da.Fill(_ds);
                        _dt = _ds.Tables[0];

                        return new DbResult(DbResult.EN_RESULT_CODE.Positive, 0, _dt, _dt.Rows.Count);
                    }
                }
            }
            catch(NpgsqlException exNpgSql)
            {
                return new DbResult(DbResult.EN_RESULT_CODE.Negative, exNpgSql.ErrorCode, null, 0, exNpgSql.Message);
            }
            catch (Exception exAll)
            {
                return new DbResult(DbResult.EN_RESULT_CODE.Negative, exAll.HResult, null, 0, exAll.Message);
            }
        }

        public DbResult ExecuteNonQuery()
        {
            throw new NotImplementedException();
        }
    }
}
