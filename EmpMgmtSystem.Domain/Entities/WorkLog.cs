using System;
using System.Collections.Generic;

namespace EmpMgmtSystem.Domain.Entities;

public partial class WorkLog
{
    public int WorkHoursId { get; set; }

    public int EmpId { get; set; }

    public int ProjectId { get; set; }

    public DateOnly WorkDate { get; set; }

    public decimal HoursLogged { get; set; }

    public string? TaskDescription { get; set; }

    public string ApprovalStatus { get; set; } = null!;

    public int? ApprovedBy { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Employee? ApprovedByNavigation { get; set; }

    public virtual Employee Emp { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
