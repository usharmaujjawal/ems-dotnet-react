using EmpMgmtSystem.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace // this is block level namespace
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController(IEmployeeService empService) : ControllerBase // this is primary constr syntax(Modern C#12 feature)
    {

        private readonly IEmployeeService _empService = empService;

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await _empService.GetAllRoles();

                if (roles == null || roles.Count == 0)
                    return NotFound(new { message = "No roles found." });

                return Ok(roles);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
