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
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpGet("logout")]
        public async Task<IActionResult> LogOut(RefreshRequestDto refreshRequestDto)
        {
            if (refreshRequestDto == null || string.IsNullOrEmpty(refreshRequestDto.RefreshToken))
            {
                _logger.LogWarning("Operation {OperationName}, CorrelationId {CorrelationId}, Message {Message}", "LogOut", HttpContext.TraceIdentifier, "Invalid or empty refresh token.");

                return Unauthorized(new { message = "Invalid refresh token" });
            }
            try
            {
                _logger.LogInformation("Operation {OperationName}, CorrelationId {CorrelationId}, Message {Message}", "LogOut", HttpContext.TraceIdentifier, "Logout requested");

                bool status = await _authService.LogOutAsync(refreshRequestDto.RefreshToken);

                if (!status)
                {
                    _logger.LogWarning("Operation {OperationName}, CorrelationId {CorrelationId}, Message {Message}", "LogOut", HttpContext.TraceIdentifier, "Invalid or already revoked token.");

                    return Unauthorized(new { message = "Invalid or already revoked token" });
                }

                return Ok(new { message = "Logout successful" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Operation {OperationName}, CorrelationId {CorrelationId}", "LogOut", HttpContext.TraceIdentifier);

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

                _logger.LogInformation("Operation {OperationName}, CorrelationId {CorrelationId}, Message {Message}", "Login", HttpContext.TraceIdentifier, "Login requested");

                if (userData == null)
                {
                    _logger.LogWarning("Operation {OperationName}, CorrelationId {CorrelationId}, Message {Message}", "Login", HttpContext.TraceIdentifier, "Employee does not exist");

                    return NotFound(new { message = "Employee does not exist. Please check" });
                }

                return Ok(userData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Operation {OperationName}, CorrelationId {CorrelationId}", "Login", HttpContext.TraceIdentifier);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshRequestDto refreshRequestDto)
        {

            _logger.LogInformation("Operation {OperationName}, CorrelationId {CorrelationId}, Message {Message}", "RefreshToken", HttpContext.TraceIdentifier, "Refresh token requested");

            if (refreshRequestDto == null || string.IsNullOrEmpty(refreshRequestDto.RefreshToken))
            {
                _logger.LogWarning("Operation {OperationName}, CorrelationId {CorrelationId}, Message {Message}", "RefreshToken", HttpContext.TraceIdentifier, "Invalid refresh token.");

                return Unauthorized(new { message = "Invalid refresh token" });
            }

            try
            {
                TokenResult newToken = await _authService.RefreshTokenAsync(refreshRequestDto.RefreshToken);
                return Ok(newToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Operation {OperationName}, CorrelationId {CorrelationId}", "RefreshToken", HttpContext.TraceIdentifier);

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
