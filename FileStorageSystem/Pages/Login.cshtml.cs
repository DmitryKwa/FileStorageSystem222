using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FileStorageSystem.Pages
{
    public class login_pageModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostMyMethodAsync() // Новый метод для клика
        {
            // Ваша логика здесь (например, уведомление или работа с БД)
            // Например, добавьте вывод в консоль или логику из предыдущего чата


            // Верните RedirectToPage или PartialView, если нужно обновить страницу
            return null;
        }
    }
}
