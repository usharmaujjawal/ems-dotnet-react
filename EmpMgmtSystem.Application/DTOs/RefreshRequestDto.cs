using System.ComponentModel.DataAnnotations;

namespace EmpMgmtSystem.Application.DTOs;

public class RefreshRequestDto
{
    [Required(ErrorMessage = "RefreshToken is required")]
    public string? RefreshToken { get; set; }
}
