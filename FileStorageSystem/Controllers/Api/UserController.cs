using FileStorageSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using FileStorageSystem.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileStorageSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // POST api/<UserController>
        [HttpPost]
        public async Task<bool> Login([FromBody] (string login, string password) user)
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
                    string passSHA512 = Props.ToSHA512(user.password);

                    command.Parameters.AddWithValue("@username", user.login);
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

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
