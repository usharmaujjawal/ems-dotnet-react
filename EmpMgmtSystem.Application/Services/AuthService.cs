using EmpMgmtSystem.Application.Interfaces;
using EmpMgmtSystem.Application.DTOs;
using EmpMgmtSystem.Domain.Interfaces;

namespace EmpMgmtSystem.Application.Services;

public class AuthService(IAuthRepository authRepo, ITokenService tokenService) : IAuthService
{
    private readonly IAuthRepository _authRepo = authRepo;
    private readonly ITokenService _tokenService = tokenService;
    public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
    {
        // step i : check whether emailId exists or not 
        var emp = await _authRepo.GetByEmailAsync(dto.EmailId);

        if (emp == null) return null;

        if (dto.Password != emp.PasswordHash)
        {
            return new AuthResponseDto
            {
                ErrorMessage = "Password does not matches"
            };
        }

        // generating tokens 
        TokenResult tokenResult = _tokenService.GenerateTokens(emp);

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
            AccessTokenExpiration = tokenResult.AccessTokenExpiration
        };
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
