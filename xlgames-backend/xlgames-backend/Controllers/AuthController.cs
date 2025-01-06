using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using xlgames_backend.ApplicationContext;
using xlgames_backend.DTOs;
using xlgames_backend.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using xlgames_backend.MySqlApplicationContext;
using System.Runtime.CompilerServices;

namespace xlgames_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly MySqlApplicationDbContext _mysqlcontext;

        public AuthController(ApplicationDbContext context, MySqlApplicationDbContext mysqlcontext)
        {
            _context = context;
            _mysqlcontext = mysqlcontext;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            User? user = await _context.Users
                .AsNoTracking()
                .Where(u => u.Name == loginDTO.Name).FirstOrDefaultAsync();
            if (user is null)
            {
                return BadRequest("Аккаунт не найден");
            }
            if (!BC.Verify(loginDTO.Password, user.Password))
            {
                return BadRequest("Неверный пароль");
            }
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Name) };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));
            return Ok();
        }
    }
}
