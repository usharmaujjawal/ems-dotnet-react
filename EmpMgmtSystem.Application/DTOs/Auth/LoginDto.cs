using System.ComponentModel.DataAnnotations;
namespace EmpMgmtSystem.Application.DTOs;


public class LoginDto
{
    [Required(ErrorMessage = "Email field is required")]
    [EmailAddress(ErrorMessage = "Email Address is not in proper format")]
    public string? EmailId { get; set; }

    [Required(ErrorMessage = "Password field is required")]
    public string? Password { get; set; }
}
