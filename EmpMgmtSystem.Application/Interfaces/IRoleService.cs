using EmpMgmtSystem.Application.DTOs;
using EmpMgmtSystem.Domain.Entities;

namespace EmpMgmtSystem.Application.Interfaces;

public interface IRoleService
{
    Task<List<RoleDto>> GetAllRolesAsync();
}
