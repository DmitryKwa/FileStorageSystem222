using FileStorageSystem.Pages;
using FileStorageSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FileStorageSystem.Controllers.Api
{

    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly DocumentStorageContext _context;
        private readonly ILogger<PrivacyModel> _logger;

        public HealthController(DocumentStorageContext context, ILogger<PrivacyModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        /*
         * Проверка, авторизация пользователя admin, в бд без SHA512
         */
        // GET api/<HealthController>/5
        [HttpGet("ConnectionBD - Auth. User admin")]
        public async Task<string> Get(int id)
        {
            Authorization authorization = new Authorization();
            try
            {
                if (authorization.AuthorizationUser("admin", "admin"))
                {
                    return "Я красавчик";
                }
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
            finally
            {

            }
            return "иду я нахуй";
        }

        [HttpGet("DatabaseConnectivity")]
        public async Task<ActionResult> GetDatabaseConnectivity()
        {
            try
            {
                // Проверяем подключение, выполняя простой запрос (например, проверка существования записей в таблице Counterparties)
                bool canConnect = await _context.Database.CanConnectAsync();
                if (canConnect)
                {
                    // Дополнительно: попробуем выполнить простой запрос
                    bool hasData = await _context.Counterparties.AnyAsync();
                    return Ok(new { Message = "Подключение к БД успешно", HasData = hasData });
                }
                else
                {
                    return StatusCode(500, "Не удалось подключиться к БД");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выполнения: {ex.Message}");
                Console.WriteLine($"Внутреннее исключение: {ex.InnerException?.Message}");
                Logger.LogError($"User=admin",
                                $"DB connecting error. ", ex);
            }

            return StatusCode(500, "Не удалось подключиться к БД");
        }
    }
}
