using EmpMgmtSystem.Infra;

namespace EmpMgmtSystem.Application.DTOs;

public class ValidateRefreshTokenResult
{
    public bool IsValid { get; set; }
    public string? FailureReason { get; set; }
    public RefreshToken? RefreshToken { get; set; }
}
