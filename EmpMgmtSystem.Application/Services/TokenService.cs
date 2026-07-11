using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmpMgmtSystem.Application.DTOs;
using EmpMgmtSystem.Application.Interfaces;
using EmpMgmtSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmpMgmtSystem.Application.Services;

public class TokenService(IConfiguration configuration) : ITokenService
{

    private readonly IConfiguration _configuration = configuration;


    public TokenResult GenerateTokens(Employee employee)
    {
        TokenResult accessToken = GenerateAccessToken(employee);

        return new TokenResult
        {
            AccessToken = accessToken.AccessToken,
            AccessTokenExpiration = accessToken.AccessTokenExpiration
        };
    }
    public TokenResult GenerateAccessToken(Employee employee)
    {
        var jwtSettings = _configuration.GetSection("Jwt");

        string secret_Key = jwtSettings.GetValue<string>("Secret_Key") ?? throw new InvalidOperationException("JWT Secret_Key is missing!");

        string issuer = jwtSettings.GetValue<string>("Issuer") ?? string.Empty;
        string audience = jwtSettings.GetValue<string>("Audience") ?? string.Empty;

        int accessTokenExpirationMinutes = jwtSettings.GetValue<int>("EXPIRATION_MINUTES");
        DateTime accessTokenExpiration = DateTime.UtcNow.AddMinutes(accessTokenExpirationMinutes);


        Claim[] userClaims = new Claim[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, employee.EmpCode ?? string.Empty), // Subject(userId) - here EmpCode

            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JWT Unique Id : useful for tracking/revoking tokens.

            new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64), // Issued at(date & time of token generation) JWT spec requires iat to be a numeric date (Unix timestamp). Using ToUnixTimeSeconds() ensures compliance.

            new Claim(ClaimTypes.NameIdentifier, employee.Email), // Unique Name identifier for the user/emp (Email)

            new Claim(ClaimTypes.Name, $"{employee.FirstName} {employee.LastName}".Trim()), // Name of the user/emp 

            new Claim(ClaimTypes.Email, employee.Email)
        };

        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret_Key));

        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken tokenGenerator = new JwtSecurityToken(
            issuer,// first arg(_configuration["Jwt:Issuer"]) → mapped to the iss claim in the JWT payload.
            audience,//second arg(_configuration["Jwt:Audience"])→ mapped to the aud claim in the JWT payload.
            claims: userClaims,// third argument (claims) → our custom claims (sub, email, role, etc.).
            expires: accessTokenExpiration,  // the expires parameter → mapped to the exp claim in the JWT payload.
            signingCredentials: signingCredentials  // The signingCredentials → used to sign the token.
        );

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        string token = tokenHandler.WriteToken(tokenGenerator);

        return new TokenResult()
        {
            AccessToken = token,
            AccessTokenExpiration = accessTokenExpiration
        };
    }

}
