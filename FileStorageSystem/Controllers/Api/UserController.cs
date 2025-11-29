using FileStorageSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileStorageSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Админ")]
    public class UserController : ControllerBase
    {
        private readonly DocumentStorageContext _context;

        public UserController(DocumentStorageContext context)
        {
            _context = context;
        }

        [HttpGet("{email}")]
        public async Task<User> GetUser(string email)
        {
            /*try
            {
                {
                    string query = "SELECT * FROM Users WHERE Email = @email";
                    SqlCommand command = new SqlCommand(query, db._connection);

                    command.Parameters.AddWithValue("@email", email);

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (await reader.ReadAsync()) // Читаем данные асинхронно
                    {
                        // Создаем объект Users и заполняем его данными из reader
                        User user = new User
                        {
                            Email = reader.GetString(reader.GetOrdinal("Email")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            SurName = reader.GetString(reader.GetOrdinal("SurName")),
                            Patronymic = reader.GetString(reader.GetOrdinal("Patronymic")),
                            Password = reader.GetString(reader.GetOrdinal("Password")),
                            Role = reader.GetString(reader.GetOrdinal("Role")),
                        };
                        return user;
                    }
                    else
                    {
                        return null; // Пользователь с таким email не найден
                    }
                }
            }
            catch (SqlException ex)
            {
                Logger.LogError($"User=---Login_User---",
                           $"Error. " +
                           $"id=---ID_User---", ex);
                return null;
            }
            finally
            {
                db.CloseConnection();
            }*/
            return null;
        }

        [HttpPost("fff")]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}