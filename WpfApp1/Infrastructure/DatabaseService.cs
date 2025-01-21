using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using WpfApp1.Core;

namespace WpfApp1.Infrastructure
{
    internal class DatabaseService : IDatabaseService
    {
        
        private readonly OracleConnection _connection;
        public DatabaseService(string connectionString)
        {
            
            _connection = new OracleConnection(connectionString);
            _connection.Open();
        }

        public OracleConnection GetConnection()
        {
            if (_connection.State != System.Data.ConnectionState.Open)
                _connection.Open();
            return _connection;
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
