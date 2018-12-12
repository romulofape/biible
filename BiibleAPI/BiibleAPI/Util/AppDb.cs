using MySql.Data.MySqlClient;
using System;
using System.Data.Common;
using System.Threading.Tasks;

namespace BiibleAPI.Util
{
    public class AppDb : IDisposable
    {
        private MySqlConnection _Connection;

        public AppDb(string connectionString)
        {
            _Connection = new MySqlConnection(connectionString);
        }

        public void Dispose()
        {
            _Connection.Close();
        }

        public async Task<DbDataReader> ExecutarSQL(string sql)
        {
            AbriConexao();

            MySqlCommand cmd = _Connection.CreateCommand();
            cmd.CommandText = sql;
            return await cmd.ExecuteReaderAsync();
        }

        public async Task<int> ExecutarComando(string sql)
        {
            AbriConexao();

            MySqlCommand cmd = _Connection.CreateCommand();
            cmd.CommandText = sql;          
            await cmd.ExecuteNonQueryAsync();
            return (int)cmd.LastInsertedId;
        }

        public void AbriConexao()
        {
            if (_Connection.State == System.Data.ConnectionState.Closed)
            {
                _Connection.OpenAsync();
            }
        }
    }
}
