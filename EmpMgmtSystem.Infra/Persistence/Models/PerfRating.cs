using System;
using System.Collections.Generic;

namespace EmpMgmtSystem.Infra.Persistence.Models;

public partial class PerfRating
{
    public int RatingId { get; set; }

    public int EmpId { get; set; }

    public int RatedBy { get; set; }

    public byte Quarter { get; set; }

    public short Year { get; set; }

    public decimal RatingScore { get; set; }

    public string? Feedback { get; set; }

    public string? GoalsNextQtr { get; set; }

    public string RatingStatus { get; set; } = null!;

    public DateTime? AcknowledgedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Employee Emp { get; set; } = null!;

    public virtual Employee RatedByNavigation { get; set; } = null!;
}
