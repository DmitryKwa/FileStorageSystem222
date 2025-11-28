using FileStorageSystem.Model;
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

        // GET api/<HealthController>/5
        [HttpGet("db2")]
        public async Task<string> Get(int id)
        {
            string connectionString = "Server=(localdb)\\mssqllocaldb;Database=FSS;Trusted_Connection=True;";
            DB db = new(connectionString);
            try
            {
                db.OpenConnection();

                if (db.ConnectionStatus())
                {
                    return "Подключение открыто";
                }
                return "Иду я нахуй";
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                db.CloseConnection();
            }
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
