using EmpMgmtSystem.Application.DTOs;
using EmpMgmtSystem.Infra;

namespace EmpMgmtSystem.Application.Interfaces;

public interface IRefreshTokenService
{
    Task<ValidateRefreshTokenResult> ValidateRefreshTokenResultAsync(string token);
    Task<RefreshToken> RotateRefreshTokenAsync(RefreshToken oldRefreshToken, TokenResult refreshToken);

}
