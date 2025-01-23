using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XlgamesBackend.Models;
using XlgamesBackend.PostgreSQL;

namespace XlgamesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Переменные
        private readonly PostgreSQLContext _postgreSQLContext;
        #endregion

        #region Конструктор
        public AuthController(PostgreSQLContext postgreSQLContext)
        {
            _postgreSQLContext = postgreSQLContext;
        }
        #endregion

        #region Войти
        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync(User userDto)
        {
            // Получаем пользователя
            User? user = await _postgreSQLContext.Users
                .AsNoTracking()
                .Where(user => Equals(user.Name, userDto.Name))
                .FirstOrDefaultAsync();
            // Если пользователь не найден, то возвращаем ошибку
            if (user is null)
            {
                ModelState.AddModelError("User", "Пользователь не найден");
                return ValidationProblem();
            }
            // Если пароль неверный, то возвращаем ошибку
            if (!BC.Verify(userDto.Password, user.Password))
            {
                ModelState.AddModelError("Password", "Неверный пароль");
                return ValidationProblem();
            }
            // Создаём верификационные данные и сохраняем их у пользователя через Cookie
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Name!) };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
            // Возвращаем ответ
            return Ok();
        }
        #endregion

        [HttpGet("Validate")]
        [Authorize]
        public ActionResult Validate() => Ok();
    }
}
