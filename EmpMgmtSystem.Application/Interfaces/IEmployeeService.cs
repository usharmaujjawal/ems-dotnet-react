using EmpMgmtSystem.Application.DTOs;

namespace EmpMgmtSystem.Application.Interfaces;

public interface IEmployeeService
{
    Task<List<RoleDto>> GetAllRoles();
}
