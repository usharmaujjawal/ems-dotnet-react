using EmpMgmtSystem.Application.DTOs;
using EmpMgmtSystem.Domain.Entities;

namespace EmpMgmtSystem.Application.Interfaces;

public interface ITokenService
{
    TokenResult GenerateTokens(Employee employee);
    TokenResult GenerateAccessToken(Employee employee);
    TokenResult GenerateRefreshToken();
}
