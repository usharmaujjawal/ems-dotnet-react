using System;
using System.Collections.Generic;

namespace EmpMgmtSystem.Infra.Persistence.Models;

public partial class Asset
{
    public int AssetId { get; set; }

    public int? EmpId { get; set; }

    public string AssetType { get; set; } = null!;

    public string? AssetName { get; set; }

    public string SerialNumber { get; set; } = null!;

    public DateOnly? AssignedDate { get; set; }

    public DateOnly? ReturnDate { get; set; }

    public string AssetStatus { get; set; } = null!;

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Employee? Emp { get; set; }
}
