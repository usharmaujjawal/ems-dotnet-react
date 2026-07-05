using EmpMgmtSystem.Domain;
using EmpMgmtSystem.Domain.Entities;
using EmpMgmtSystem.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EmpMgmtSystem.Infra;

public class EmployeeRepository(AppDbContext context) : IEmployeeRepository
{
    private readonly AppDbContext _context = context;
    public Task<List<Role>> GetRolesAsync()
    {
        // this will actually call the dbContext to fetch all the roles from db via Roles DbSet property
        return _context.Roles.ToListAsync();
    }

}
