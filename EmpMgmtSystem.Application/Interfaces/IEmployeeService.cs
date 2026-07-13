using EmpMgmtSystem.Application.DTOs;
using EmpMgmtSystem.Domain.Entities;

namespace EmpMgmtSystem.Application.Interfaces;

public interface IEmployeeService
{
    Task<List<RoleDto>> GetAllRoles();
}
