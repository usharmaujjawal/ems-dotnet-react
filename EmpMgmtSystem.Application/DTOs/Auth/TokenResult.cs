namespace EmpMgmtSystem.Application.DTOs;

public class TokenResult
{
    public string AccessToken { get; set; } // jwtToken
    public DateTime AccessTokenExpiration { get; set; }
    public string RefreshToken { get; set; } // random cryptographically generated string
    public DateTime RefreshTokenExpiration { get; set; }
}
