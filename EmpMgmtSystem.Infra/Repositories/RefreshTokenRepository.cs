using EmpMgmtSystem.Domain.Interfaces;
using EmpMgmtSystem.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EmpMgmtSystem.Infra.Repositories;

public class RefreshTokenRepository(AppDbContext dbContext) : IRefreshTokenRepository
{

    private readonly AppDbContext _dbContext = dbContext;

    public async Task<RefreshToken?> GetByTokenAsync(string token)
    {
        return await _dbContext.RefreshTokens.FirstOrDefaultAsync(tk => tk.Token == token);
    }

    public async Task<RefreshToken?> AddAsync(RefreshToken token)
    {
        await _dbContext.RefreshTokens.AddAsync(token);// Added
        int result = await _dbContext.SaveChangesAsync(); // Commits the changes into the db
        return token;
    }

    public async Task<RefreshToken?> UpdateAsync(RefreshToken token)
    {
        _dbContext.RefreshTokens.Update(token); //Modified
        await _dbContext.SaveChangesAsync(); // Commits changes into db
        return token;
    }
}
