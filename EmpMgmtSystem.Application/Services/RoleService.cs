using EmpMgmtSystem.Application.DTOs;
using EmpMgmtSystem.Application.Interfaces;
using EmpMgmtSystem.Domain.Entities;
using EmpMgmtSystem.Domain.Interfaces;

namespace EmpMgmtSystem.Application.Services;

public class RoleService(IRoleRepository roleRepo) : IRoleService
{

    private readonly IRoleRepository _roleRepo = roleRepo;
    public async Task<List<RoleDto>> GetAllRolesAsync()
    {
        List<RoleDto> result = new List<RoleDto>();

        List<Role> roles = await _roleRepo.GetAllAsync();

        if (roles == null) return null;

        foreach (Role role in roles)
        {
            result.Add(new RoleDto
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                RoleLevel = role.RoleLevel
            });
        }

        return result;
    }
}
