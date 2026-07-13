using EmpMgmtSystem.Application.DTOs;
namespace EmpMgmtSystem.Application.Interfaces;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterDto dto);
    Task<AuthResponseDto> LoginAsync(LoginDto dto);
    Task<bool> ForgotPasswordAsync(string email);
    Task<TokenResult> RefreshTokenAsync(string refreshToken);
    Task<bool> LogOutAsync(string token);

}
