using EmpMgmtSystem.Domain.Interfaces;
using EmpMgmtSystem.Domain.Entities;
using EmpMgmtSystem.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EmpMgmtSystem.Infra.Repositories;

public class EmployeeRepository(AppDbContext dbContext) : IEmployeeRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public Task<Employee?> GetEmployeeById(int empId)
    {
        return _dbContext.Employees.FirstOrDefaultAsync(emp => emp.EmpId == empId);
    }
}
