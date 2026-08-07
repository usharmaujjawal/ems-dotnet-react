using EmpMgmtSystem.Infra;

namespace EmpMgmtSystem.Domain.Interfaces;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByTokenAsync(string token);

    Task<RefreshToken?> AddAsync(RefreshToken token);

    Task<RefreshToken?> UpdateAsync(RefreshToken token);
}
