using ContcatManagemetServiceDebug.DTOs;

namespace ContcatManagemetServiceDebug.Services
{
    public interface IAuthService
    {
        Task<string> Register(RegisterDto dto);
        Task<string> Login(LoginDto dto);
    }
}
