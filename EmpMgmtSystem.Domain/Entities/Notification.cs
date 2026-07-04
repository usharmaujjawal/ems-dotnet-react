using System;
using System.Collections.Generic;

namespace EmpMgmtSystem.Domain.Entities;

public partial class Notification
{
    public int NotifId { get; set; }

    public int EmpId { get; set; }

    public string NotifType { get; set; } = null!;

    public string Message { get; set; } = null!;

    public bool IsRead { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Employee Emp { get; set; } = null!;
}
