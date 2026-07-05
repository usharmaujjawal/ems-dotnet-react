using EmpMgmtSystem.Domain.Entities;

namespace EmpMgmtSystem.Domain;

public interface IEmployeeRepository
{
    Task<List<Role>> GetRolesAsync();
}
