using FileStorageSystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public IActionResult OnPostMyMethod() // Новый метод для клика
        {
            // Ваша логика здесь (например, уведомление или работа с БД)
            // Например, добавьте вывод в консоль или логику из предыдущего чата
            try
            {
                
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
