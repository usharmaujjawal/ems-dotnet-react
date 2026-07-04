using EmpMgmtSystem.Domain;

namespace EmpMgmtSystem.Application;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _empRepo;

    // here the actual ref of repo obj will be created via DI by IoC container : constructor injection
    public EmployeeService(IEmployeeRepository empRepo)
    {
        _empRepo = empRepo;
    }

    public async Task<List<RoleDto>> GetAllRoles()
    {
        List<RoleDto> result = new List<RoleDto>();

        var roles = await _empRepo.GetRolesAsync();

        if (roles == null) return null;

        foreach (var role in roles)
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
