using EmpMgmtSystem.Application.DTOs;
using EmpMgmtSystem.Application.Interfaces;
using EmpMgmtSystem.Domain.Entities;
using EmpMgmtSystem.Domain.Interfaces;
using EmpMgmtSystem.Infra;

namespace EmpMgmtSystem.Application.Services;

public class RefreshTokenService(IRefreshTokenRepository refreshTokenRepo) : IRefreshTokenService
{
    private readonly IRefreshTokenRepository _refreshTokenRepo = refreshTokenRepo;
    public async Task<ValidateRefreshTokenResult> ValidateRefreshTokenResultAsync(string token)
    {
        // Step i : fetch the token stored in the db 
        RefreshToken? dbStoredRefreshToken = await _refreshTokenRepo.GetByTokenAsync(token);

        // Step ii : Validate the refreshToken 
        if (dbStoredRefreshToken == null || dbStoredRefreshToken.Token == null)
        {
            return new ValidateRefreshTokenResult
            {
                IsValid = false,
                FailureReason = "Token does not exist"
            };
        }

        else if (dbStoredRefreshToken.IsExpired == true)
        {
            return new ValidateRefreshTokenResult
            {
                IsValid = false,
                FailureReason = "Token is expired"
            };
        }

        else if (dbStoredRefreshToken.IsRevoked == true)
        {
            return new ValidateRefreshTokenResult
            {
                IsValid = false,
                FailureReason = "Token is revoked"
            };
        }

        return new ValidateRefreshTokenResult
        {
            IsValid = true,
            RefreshToken = dbStoredRefreshToken
        };
    }
    public async Task<RefreshToken> RotateRefreshTokenAsync(RefreshToken oldRefreshToken, TokenResult refreshToken)
    {
        oldRefreshToken.ExpiresAt = DateTime.UtcNow;
        // We need to use the same object that is being retrieved from db. if we pass a new object EFCore will insert that object instead of updating the existing one
        await _refreshTokenRepo.UpdateAsync(oldRefreshToken);

        RefreshToken newRefreshToken = new RefreshToken
        {
            EmpId = oldRefreshToken.EmpId,
            Token = refreshToken.RefreshToken,
            CreatedByIp = "IP Of the system",
            CreatedAt = DateTime.UtcNow,
            ExpiresAt = refreshToken.RefreshTokenExpiration
        };

        // we need to add the newRefreshToken into the RefreshToken table.
        await _refreshTokenRepo.AddAsync(newRefreshToken);

        return newRefreshToken;
    }

}
