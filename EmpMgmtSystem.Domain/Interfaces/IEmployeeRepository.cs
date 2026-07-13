using EmpMgmtSystem.Domain.Entities;

namespace EmpMgmtSystem.Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee?> GetEmployeeByIdAsync(int empId);
}
