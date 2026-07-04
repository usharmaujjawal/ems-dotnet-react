using System;
using System.Collections.Generic;

namespace EmpMgmtSystem.Domain.Entities;

public partial class Department
{
    public int DeptId { get; set; }

    public string DeptName { get; set; } = null!;

    public string? CostCenter { get; set; }

    public string DeptCode { get; set; } = null!;

    public string? Location { get; set; }

    public int? HeadEmpId { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Employee? HeadEmp { get; set; }

    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
