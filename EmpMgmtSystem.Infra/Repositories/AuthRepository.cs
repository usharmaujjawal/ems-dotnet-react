using EmpMgmtSystem.Domain.Entities;
using EmpMgmtSystem.Domain.Interfaces;
using EmpMgmtSystem.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EmpMgmtSystem.Infra.Repositories;

public class AuthRepository(AppDbContext dbContext) : IAuthRepository
{

    private readonly AppDbContext _dbContext = dbContext;
    public Task<Employee?> GetByEmailAsync(string email)
    {
        return _dbContext.Employees.Where(emp => emp.Email == email).FirstOrDefaultAsync();
    }
}
