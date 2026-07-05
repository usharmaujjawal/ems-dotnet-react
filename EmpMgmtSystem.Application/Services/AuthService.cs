using EmpMgmtSystem.Application.Interfaces;
using EmpMgmtSystem.Application.DTOs;

namespace EmpMgmtSystem.Application.Services;

public class AuthService : IAuthService
{
    public Task<bool> ForgotPasswordAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<AuthResponseDto> LoginAsync(LoginDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RegisterAsync(RegisterDto dto)
    {
        throw new NotImplementedException();
    }
}
