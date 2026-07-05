using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmpMgmtSystem.Application.Interfaces;
using EmpMgmtSystem.Application.DTOs;

namespace EmpMgmtSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                var userData = await _authService.LoginAsync(dto);

                if (userData == null) return Ok(new { message = "Login failed for the user" });

                return Ok(userData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto)
        {
            throw new NotImplementedException();
        }

    }
}
