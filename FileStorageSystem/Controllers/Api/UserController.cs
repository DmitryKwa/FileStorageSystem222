using FileStorageSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using FileStorageSystem.Model;
using FileStorageSystem.Model.ForApi;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileStorageSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DocumentStorageContext _context;

        public UserController(DocumentStorageContext context)
        {
            _context = context;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginForm form)
        {
            string passSHA512 = Props.ToSHA512(form.Password);

            var result = await (from user in _context.Users
                          where user.Email == form.Email && user.Password == form.Password
                          select user.Email).FirstOrDefaultAsync();

            if (result != null)
            {
                return Ok(result);
            }
            return 
            try
            {
                    
                /*int userCount = (int)command.ExecuteScalar();
                if (userCount > 0)
                {
                    return Ok("Вы авторизованы");
                }*/
                return BadRequest("Неверный логин или пароль");
            }
            catch (SqlException ex)
            {
                Logger.LogError($"User=---Login_User---",
                           $"Error. " +
                           $"id=---ID_User---", ex);
                return StatusCode(500);
            }
        }

        // GET api/<UserController>/5
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

        // POST api/<UserController>
        [HttpPost("fff")]
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