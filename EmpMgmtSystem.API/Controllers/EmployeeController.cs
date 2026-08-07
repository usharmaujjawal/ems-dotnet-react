using EmpMgmtSystem.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpMgmtSystem.API.Controllers// this is block level namespace
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeController(IEmployeeService empService) : ControllerBase // this is primary constr syntax(Modern C#12 feature)
    {

        private readonly IEmployeeService _empService = empService;

    }
}
