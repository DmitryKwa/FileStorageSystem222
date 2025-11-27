using FileStorageSystem.Model;
using FileStorageSystem.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        // GET: api/<HealthController>
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

        // GET api/<HealthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HealthController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HealthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HealthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
