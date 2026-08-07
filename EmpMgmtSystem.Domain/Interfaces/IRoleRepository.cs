using EmpMgmtSystem.Domain.Entities;

namespace EmpMgmtSystem.Domain.Interfaces;

public interface IRoleRepository
{
    Task<List<Role>> GetAllAsync();
}
