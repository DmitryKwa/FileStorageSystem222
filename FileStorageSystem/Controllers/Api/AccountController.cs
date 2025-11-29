using FileStorageSystem.Models;
using FileStorageSystem.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace FileStorageSystem.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DocumentStorageContext _context;
        public AccountController(DocumentStorageContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsername()
        {
            return Ok(User.Identity.Name);
        }

        [HttpPost("login")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                string passSHA512 = Props.ToSHA512(model.Password);

                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == passSHA512);

                if (user != null)
                {
                    await Authorizate(model.Email, user.Role); // аутентификация

                    return RedirectToPage("/Main");
                }
                return BadRequest("Неверный логин или пароль");
                //ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return BadRequest("Bad");
        }

        private async Task Authorizate(string email, string role)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "Cookies");
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}