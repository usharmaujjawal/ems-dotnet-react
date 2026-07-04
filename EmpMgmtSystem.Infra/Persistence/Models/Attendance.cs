using System;
using System.Collections.Generic;

namespace EmpMgmtSystem.Infra.Persistence.Models;

public partial class Attendance
{
    public int AttendanceId { get; set; }

    public int EmpId { get; set; }

    public DateOnly AttendanceDate { get; set; }

    public DateTime? CheckIn { get; set; }

    public DateTime? CheckOut { get; set; }

    public decimal? TotalHours { get; set; }

    public string EntryMethod { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string? Remarks { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Employee Emp { get; set; } = null!;
}
