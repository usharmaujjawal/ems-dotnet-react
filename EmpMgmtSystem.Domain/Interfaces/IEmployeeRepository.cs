using EmpMgmtSystem.Domain.Entities;

namespace EmpMgmtSystem.Domain.Interfaces;

public interface IEmployeeRepository
{
    Task<List<Role>> GetRolesAsync();
}
