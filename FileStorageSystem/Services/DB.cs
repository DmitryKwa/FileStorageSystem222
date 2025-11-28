using Microsoft.Data.SqlClient;
using System.Data;

namespace FileStorageSystem.Services
{
    public class DB
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public DB(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
        }

        public bool ConnectionStatus ()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                return false;
            }
            return true;
        }

        public void OpenConnection()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public DataTable ExecuteQuery(string query)
        {
            OpenConnection();

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
        }

        public int ExecuteNonQuery(string query)
        {
            OpenConnection();

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                return command.ExecuteNonQuery();
            }
        }

        public void Dispose()
        {
            CloseConnection();
            _connection.Dispose();
        }
    }
}
