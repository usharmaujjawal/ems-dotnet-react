using System;
using System.Collections.Generic;

namespace EmpMgmtSystem.Infra.Persistence.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? EmpCode { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Phone { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public DateOnly HireDate { get; set; }

    public string EmpStatus { get; set; } = null!;

    public int DeptId { get; set; }

    public int? ManagerId { get; set; }

    public int? RoleId { get; set; }

    public string? ProfilePicUrl { get; set; }

    public string? EmergencyContact { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    public virtual ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual Department Dept { get; set; } = null!;

    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();

    public virtual ICollection<Employee> InverseManager { get; set; } = new List<Employee>();

    public virtual ICollection<LeaveReq> LeaveReqApprovedByNavigations { get; set; } = new List<LeaveReq>();

    public virtual ICollection<LeaveReq> LeaveReqEmps { get; set; } = new List<LeaveReq>();

    public virtual Employee? Manager { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Payroll> PayrollEmps { get; set; } = new List<Payroll>();

    public virtual ICollection<Payroll> PayrollProcessedByNavigations { get; set; } = new List<Payroll>();

    public virtual ICollection<PerfRating> PerfRatingEmps { get; set; } = new List<PerfRating>();

    public virtual ICollection<PerfRating> PerfRatingRatedByNavigations { get; set; } = new List<PerfRating>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<WorkLog> WorkLogApprovedByNavigations { get; set; } = new List<WorkLog>();

    public virtual ICollection<WorkLog> WorkLogEmps { get; set; } = new List<WorkLog>();
}
