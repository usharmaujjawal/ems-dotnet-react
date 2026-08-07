using EmpMgmtSystem.Domain.Interfaces;
using EmpMgmtSystem.Application.Interfaces;
using EmpMgmtSystem.Application.DTOs;

namespace EmpMgmtSystem.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _empRepo;

    // here the actual ref of repo obj will be created via DI by IoC container : constructor injection
    public EmployeeService(IEmployeeRepository empRepo)
    {
        _empRepo = empRepo;
    }

}
