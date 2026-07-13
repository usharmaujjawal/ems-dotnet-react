using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmpMgmtSystem.Application.Interfaces;
using EmpMgmtSystem.Application.DTOs;

namespace EmpMgmtSystem.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("logout")]
        public async Task<IActionResult> LogOut(RefreshRequestDto refreshRequestDto)
        {
            if (refreshRequestDto == null || string.IsNullOrEmpty(refreshRequestDto.RefreshToken))
            {
                return Unauthorized(new { message = "Invalid refresh token" });
            }
            try
            {
                bool status = await _authService.LogOutAsync(refreshRequestDto.RefreshToken);

                if (!status)
                    return Unauthorized(new { message = "Invalid or already revoked token" });

                return Ok(new { message = "Logout successful" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            throw new NotImplementedException();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                AuthResponseDto userData = await _authService.LoginAsync(dto);

                if (userData == null) return NotFound(new { message = "Employee does not exist. Please check" });

                return Ok(userData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshRequestDto refreshRequestDto)
        {
            if (refreshRequestDto == null || string.IsNullOrEmpty(refreshRequestDto.RefreshToken))
                return Unauthorized(new { message = "Invalid refresh token" });

            try
            {
                TokenResult newToken = await _authService.RefreshTokenAsync(refreshRequestDto.RefreshToken);
                return Ok(newToken);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }

        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto dto)
        {
            throw new NotImplementedException();
        }

    }
}
