using EmpMgmtSystem.Application.Interfaces;
using EmpMgmtSystem.Application.DTOs;
using EmpMgmtSystem.Domain.Interfaces;
using EmpMgmtSystem.Infra;
using EmpMgmtSystem.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace EmpMgmtSystem.Application.Services;

public class AuthService(IAuthRepository authRepo, ITokenService tokenService, IRefreshTokenRepository refreshTokenRepo, IEmployeeRepository employeeRepo, IRefreshTokenService refreshTokenService) : IAuthService
{
    private readonly IAuthRepository _authRepo = authRepo;
    private readonly ITokenService _tokenService = tokenService;
    private readonly IEmployeeRepository _employeeRepo = employeeRepo;
    private readonly IRefreshTokenRepository _refreshTokenRepo = refreshTokenRepo;
    private readonly IRefreshTokenService _refreshTokenService = refreshTokenService;
    public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
    {
        // step i : check whether emailId exists or not 
        Employee? emp = await _authRepo.GetByEmailAsync(dto.EmailId);

        if (emp == null) return null;

        // comparing password from the request with the hashed password
        if (!BCrypt.Net.BCrypt.Verify(dto.Password, emp.PasswordHash))
        {
            return new AuthResponseDto
            {
                ErrorMessage = "Invalid credentials"
            };
        }

        // generating tokens 
        TokenResult tokenResult = _tokenService.GenerateTokens(emp);

        // Need to update the refreshToken into the db - persistent to db
        RefreshToken refreshToken = new RefreshToken
        {
            EmpId = emp.EmpId,
            CreatedAt = DateTime.UtcNow,
            Token = tokenResult.RefreshToken,
            ExpiresAt = tokenResult.RefreshTokenExpiration
        };

        await _refreshTokenRepo.AddAsync(refreshToken);

        return new AuthResponseDto
        {
            EmployeeFirstName = emp.FirstName,
            EmployeeLastName = emp.LastName,
            EmployeeId = emp.EmpId,
            EmployeeRoleId = emp.RoleId,
            EmployeeEmail = emp.Email,
            ProfilePicUrl = emp.ProfilePicUrl,
            IsSuccess = true,

            // tokens
            AccessToken = tokenResult.AccessToken,
            AccessTokenExpiration = tokenResult.AccessTokenExpiration,
            RefreshToken = tokenResult.RefreshToken,
            RefreshTokenExpiration = tokenResult.RefreshTokenExpiration
        };
    }

    public async Task<TokenResult> RefreshTokenAsync(string refreshToken)
    {
        // Step i : Validate refreshToken
        ValidateRefreshTokenResult validateTokenResult = await _refreshTokenService.ValidateRefreshTokenResultAsync(refreshToken);

        if (validateTokenResult == null || validateTokenResult.RefreshToken == null)
            throw new UnauthorizedAccessException("Invalid token");

        // Step ii : fetch the emp based on the refreshToken
        Employee? emp = await _employeeRepo.GetEmployeeByIdAsync(validateTokenResult.RefreshToken.EmpId);

        // Step iii : generate new tokens 
        TokenResult newTokenResult = _tokenService.GenerateTokens(emp);

        // Step iv : Rotating refresh token since we have generated new tokens
        await _refreshTokenService.RotateRefreshTokenAsync(validateTokenResult.RefreshToken, newTokenResult);

        return newTokenResult;
    }

    public async Task<bool> ForgotPasswordAsync(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> RegisterAsync(RegisterDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> LogOutAsync(string token)
    {
        // step i : fetch the refreshToken saved in the db
        RefreshToken? refreshToken = await _refreshTokenRepo.GetByTokenAsync(token);

        if (refreshToken == null || (refreshToken.IsExpired == true)) return false;

        // mark the existing refreshToken as expired
        refreshToken.ExpiresAt = DateTime.UtcNow;

        // updating the refreshToken in the db 
        await _refreshTokenRepo.UpdateAsync(refreshToken);

        return true;
    }
}
