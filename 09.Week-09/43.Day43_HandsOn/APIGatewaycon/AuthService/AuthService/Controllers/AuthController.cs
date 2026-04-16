using AuthService.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthenticateController : ControllerBase
{
    private readonly AuthDbContext _context;
    private readonly JwtService _jwt;

    public AuthenticateController(AuthDbContext context, JwtService jwt)
    {
        _context = context;
        _jwt = jwt;
    }

 
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserModel user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return Ok(user);
    }

   
    [HttpPost("login")]
    public IActionResult Login(UserModel requestUser)
    {
        var user = _context.Users.FirstOrDefault(x =>
            x.Email == requestUser.Email &&
            x.Password == requestUser.Password);

        if (user == null) return Unauthorized();

        var token = _jwt.GenerateToken(user);

        return Ok(new { token });
    }
}