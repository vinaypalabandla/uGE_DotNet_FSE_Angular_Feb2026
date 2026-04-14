using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication8.ContactManagement.DAL.Data;
using WebApplication8.ContactManagement.DAL.Models;

namespace WebApplication8.ContactManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("login")]
        public IActionResult Login(User login)
        {
            var user = _context.Users
                .FirstOrDefault(x => x.Username == login.Username &&
                                     x.Password == login.Password);

            if (user == null)
                return Unauthorized();

            var claims = new[]
            {
              new Claim(ClaimTypes.Name, user.Username ?? ""),
              new Claim(ClaimTypes.Role, user.Role ?? "")
        };
            var key = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes("ThisIsMyVeryStrongSecretKey1234567890")
            );

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}