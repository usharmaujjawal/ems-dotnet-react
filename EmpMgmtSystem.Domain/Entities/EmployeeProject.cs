using System;
using System.Collections.Generic;

namespace EmpMgmtSystem.Domain.Entities;

public partial class EmployeeProject
{
    public int EmpProjId { get; set; }

    public int EmpId { get; set; }

    public int ProjectId { get; set; }

    public string? AssignmentRole { get; set; }

    public DateOnly AssignedFrom { get; set; }

    public DateOnly? AssignedTo { get; set; }

    public decimal? AllocationPct { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Employee Emp { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
