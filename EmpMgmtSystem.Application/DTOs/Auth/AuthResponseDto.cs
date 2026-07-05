namespace EmpMgmtSystem.Application.DTOs;

public class AuthResponseDto
{
    public int EmployeeId { get; set; }
    public string? EmployeeFirstName { get; set; }
    public string? EmployeeLastName { get; set; }
    public int? EmployeeRoleId { get; set; }
    public string? EmployeeEmail { get; set; }
    public string? ProfilePicUrl { get; set; }

    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }
}
