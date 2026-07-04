using System;
using System.Collections.Generic;

namespace EmpMgmtSystem.Domain.Entities;

public partial class AuditLog
{
    public int LogId { get; set; }

    public int? EmpId { get; set; }

    public string Action { get; set; } = null!;

    public string? TableAffected { get; set; }

    public int? RecordId { get; set; }

    public string? OldValue { get; set; }

    public string? NewValue { get; set; }

    public DateTime ActionAt { get; set; }

    public string? IpAddress { get; set; }

    public virtual Employee? Emp { get; set; }
}
