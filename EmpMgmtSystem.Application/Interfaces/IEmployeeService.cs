namespace EmpMgmtSystem.Application;

public interface IEmployeeService
{
    Task<List<RoleDto>> GetAllRoles();
}
