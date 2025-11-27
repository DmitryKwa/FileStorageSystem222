using FileStorageSystem.Model;
using FileStorageSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace FileStorageSystem.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }



        public async Task<IActionResult> TestDb()
        {
            var result = await _context.TestConnectionAsync();
            if (result.CanConnect)
            {
                return Ok(new { Message = "Подключение успешно", HasData = result.HasData });
            }
            else
            {
                return StatusCode(500, result.ErrorMessage);
            }
        }




        public  async Task<IActionResult> OnPostMyMethodAsync() // Новый метод для клика
        {
            // Ваша логика здесь (например, уведомление или работа с БД)
            // Например, добавьте вывод в консоль или логику из предыдущего чата
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

            // Верните RedirectToPage или PartialView, если нужно обновить страницу
            return RedirectToPage(); // Или Page() для перезагрузки
        }
        public void Test() 
        {
            DataBase dataBase = new DataBase();
            try
            {
                dataBase.DatabaseConnection();
                dataBase.OpenConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка выполнения: {ex.Message}");
                Console.WriteLine($"Внутреннее исключение: {ex.InnerException?.Message}");
                Logger.LogError($"User=admin",
                                $"DB connecting error. ", ex);
            }
            dataBase.CloseConnection();
        }
    }

}
