using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace pokedex_back.Infrastructure
{
    public class SqlServerRepository : IDisposable
    {
        private IConfiguration _config;
        private SqlConnection _connection = null;
        private string _connectionStringId;
        private string _connectionString;

        public SqlServerRepository(IConfiguration config)
        {
            _config = config;
            UseConnectionString(_config.GetConnectionString("DefaultConnection"));
        }

        public virtual string ConnectionStringId
        {
            get { return _connectionStringId; }
        }

        protected SqlConnection Database
        {
            get
            {
                if(_connection == null)
                {
                    _connection = new SqlConnection(_connectionString);
                }

                return _connection;
            }
        }

        public SqlServerRepository UseConnectionStringId( string connectionStringId)
        {
            _connectionStringId = connectionStringId;

            return this;
        }

        public SqlServerRepository UseConnectionString(string connectionString)
        {
            _connectionString = connectionString;

            return this;
        }

        public void Dispose()
            {
            if(_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
