using FileStorageSystem.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FileStorageSystem.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly DocumentStorageContext _context;
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(DocumentStorageContext context, ILogger<PrivacyModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostMyMethodAsync() // Новый метод для клика
        {
            // Ваша логика здесь (например, уведомление или работа с БД)
            // Например, добавьте вывод в консоль или логику из предыдущего чата
            

            // Верните RedirectToPage или PartialView, если нужно обновить страницу
            return Redirect("/swagger"); // Или Page() для перезагрузки
        }
    }

}
