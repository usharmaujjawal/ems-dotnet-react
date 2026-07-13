using EmpMgmtSystem.Domain.Entities;
using EmpMgmtSystem.Domain.Interfaces;
using EmpMgmtSystem.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EmpMgmtSystem.Infra.Repositories;

public class RoleRepository(AppDbContext dbContext) : IRoleRepository
{
    private readonly AppDbContext _dbContext = dbContext;
    public async Task<List<Role>> GetAllAsync()
    {
        // this will actually call the dbContext to fetch all the roles from db via Roles DbSet property
        return await _dbContext.Roles.ToListAsync();
    }

}
