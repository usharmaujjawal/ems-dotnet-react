using EmpMgmtSystem.Application.Interfaces;
using EmpMgmtSystem.Application.DTOs;
using EmpMgmtSystem.Domain.Interfaces;
using EmpMgmtSystem.Infra;
using EmpMgmtSystem.Domain.Entities;

namespace EmpMgmtSystem.Application.Services;

public class AuthService(IAuthRepository authRepo, ITokenService tokenService, IRefreshTokenRepository refreshTokenRepo, IEmployeeRepository employeeRepo) : IAuthService
{
    private readonly IAuthRepository _authRepo = authRepo;
    private readonly ITokenService _tokenService = tokenService;

    private readonly IEmployeeRepository _employeeRepo = employeeRepo;

    private readonly IRefreshTokenRepository _refreshTokenRepo = refreshTokenRepo;
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
                ErrorMessage = "Password does not matches"
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
        RefreshToken? dbStoredRefreshToken = await _refreshTokenRepo.GetByTokenAsync(refreshToken);

        if (dbStoredRefreshToken == null)
            throw new UnauthorizedAccessException("Invalid token");

        // Step iii : fetch the emp based on the refreshToken
        Employee? emp = await _employeeRepo.GetEmployeeById(dbStoredRefreshToken.EmpId);

        // Step ii : generate new tokens 
        TokenResult newTokenResult = _tokenService.GenerateTokens(emp);

        // Step iii : Need to update the refreshToken table 
        // RefreshToken newRefreshToken = new RefreshToken
        // {
        //     EmpId = emp.EmpId,
        //     Token = newTokenResult.RefreshToken,
        //     CreatedByIp = "IP Of the system",
        //     CreatedAt = DateTime.UtcNow,
        //     ExpiresAt = newTokenResult.RefreshTokenExpiration
        // };

        dbStoredRefreshToken.CreatedAt = DateTime.UtcNow;
        dbStoredRefreshToken.Token = newTokenResult.RefreshToken;
        dbStoredRefreshToken.ExpiresAt = newTokenResult.RefreshTokenExpiration;

        // We need to use the same object that is being retrieved from db. if we pass a new object EFCore will insert that object instead of updating the existing one
        await _refreshTokenRepo.UpdateAsync(dbStoredRefreshToken);

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
}
