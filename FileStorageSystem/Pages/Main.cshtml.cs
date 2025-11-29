using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FileStorageSystem.Pages
{
    [Authorize(Roles = "Админ, Пользователь")]
    public class main_pageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
