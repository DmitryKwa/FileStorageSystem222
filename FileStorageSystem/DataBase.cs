using Microsoft.Data.SqlClient;

namespace FileStorageSystem
{
    public class DataBase
    {
        private string? _connectionString;
        private SqlConnection? _connection;

        public void DatabaseConnection(string connectionString = 
            "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=FSS;Integrated Security=True;")
        {
            try
            {
                _connectionString = connectionString;
                _connection = new SqlConnection(_connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выполнения: {ex.Message}");
                Console.WriteLine($"Внутреннее исключение: {ex.InnerException?.Message}");
                Logger.LogError($"User=admin",
                                $"DB connecting error. ", ex);
            }
            Logger.LogInfo($"User=admin",
                           $"DB connecting. " +
                           $"id=0");
        }

        public SqlConnection GetConnection() => _connection;

        public void OpenConnection()
        {
            try
            {
                if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();
                    Console.WriteLine("Подключение к базе данных успешно установлено.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выполнения: {ex.Message}");
                Console.WriteLine($"Внутреннее исключение: {ex.InnerException?.Message}");
                Logger.LogError($"User=admin",
                                $"DB connection error. ", ex);
            }
            Logger.LogInfo($"User=admin",
                           $"Establishing a connection to the DB. " +
                           $"id=0");
        }

        public void CloseConnection()
        {
            try
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                    Console.WriteLine("Подключение к базе данных закрыто.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выполнения: {ex.Message}");
                Console.WriteLine($"Внутреннее исключение: {ex.InnerException?.Message}");
                Logger.LogError($"User=admin",
                                $"DB closing error", ex);
            }
            Logger.LogInfo($"User=admin",
                           $"Closing the connection to the DB. " +
                           $"id=0");
        }

        // Пример выполнения запроса (можно добавить другие методы для разных операций)
        public SqlDataReader ExecuteQuery(string query)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, _connection);
                return command.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выполнения: {ex.Message}");
                Console.WriteLine($"Внутреннее исключение: {ex.InnerException?.Message}");
                Logger.LogError($"User=admin",
                                $"Error for executing a request - {query}. ", ex);
            }
            Logger.LogInfo($"User=admin",
                           $"Executing a request {query}. " +
                           $"id=0");
            return null;
        }

        // Метод для выполнения запроса без возвращаемого значения (например, INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string query)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, _connection);
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выполнения: {ex.Message}");
                Console.WriteLine($"Внутреннее исключение: {ex.InnerException?.Message}");
                Logger.LogError($"User=admin",
                                $"Error for executing a request - {query}. ", ex);
            }
            Logger.LogInfo($"User=admin",
                           $"Executing a request {query}. " +
                           $"id=0");
            return 0;
        }

        // Для высвобождения ресурсов
        public void Dispose()
        {
            try
            {
                if (_connection != null)
                {
                    if (_connection.State == System.Data.ConnectionState.Open)
                    {
                        _connection.Close();
                    }
                    _connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выполнения: {ex.Message}");
                Console.WriteLine($"Внутреннее исключение: {ex.InnerException?.Message}");
                Logger.LogError($"User=admin",
                                $"Error dispose", ex);
            }
            Logger.LogInfo($"User=admin",
                           $"Dispose to DB. " +
                           $"id=0");
        }
    }
}
