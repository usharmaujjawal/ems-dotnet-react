using System;
using System.Collections.Generic;

namespace EmpMgmtSystem.Infra.Persistence.Models;

public partial class LeaveReq
{
    public int LeaveId { get; set; }

    public int EmpId { get; set; }

    public string LeaveType { get; set; } = null!;

    public DateOnly FromDate { get; set; }

    public DateOnly ToDate { get; set; }

    public int? TotalDays { get; set; }

    public string? Reason { get; set; }

    public string Status { get; set; } = null!;

    public int? ApprovedBy { get; set; }

    public DateTime? ApprovedAt { get; set; }

    public DateTime AppliedOn { get; set; }

    public virtual Employee? ApprovedByNavigation { get; set; }

    public virtual Employee Emp { get; set; } = null!;
}
