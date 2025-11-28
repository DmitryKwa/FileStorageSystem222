using Microsoft.Data.SqlClient;

namespace FileStorageSystem.Services
{
    public class Authorization
    {
        /*
         * Авторизация пользователя, если пользователь был авторизован успешно, вернет True, если нет, то очевидно
         */
        public bool AuthorizationUser(string login, string pass)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=FSS;Trusted_Connection=True;";
            DB db = new(connectionString);

            try
            {
                db.OpenConnection();
                if (db.ConnectionStatus())
                {
                    string query = "SELECT COUNT(*) FROM Users WHERE Email = @username AND PasswordHash = @password";
                    SqlCommand command = new SqlCommand(query, db._connection);
                    string passSHA512 = Props.ToSHA512(pass);
                    
                    command.Parameters.AddWithValue("@username", login);
                    command.Parameters.AddWithValue("@password", passSHA512);

                    int userCount = (int)command.ExecuteScalar();
                    return userCount > 0;
                }
            }
            catch (SqlException ex)
            {
                Logger.LogError($"User=---Login_User---",
                           $"Error. " +
                           $"id=---ID_User---", ex);
                return false;
            }
            finally
            {
                db.CloseConnection();
            }
            return false;
        }
    }
}
