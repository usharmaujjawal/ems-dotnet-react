using System;
using System.Collections.Generic;

namespace EmpMgmtSystem.Domain.Entities;

public partial class Payroll
{
    public int PayrollId { get; set; }

    public int EmpId { get; set; }

    public int DeptId { get; set; }

    public int? ProjectId { get; set; }

    public DateOnly PayPeriodStart { get; set; }

    public DateOnly PayPeriodEnd { get; set; }

    public decimal BaseSalary { get; set; }

    public decimal? HourlyRate { get; set; }

    public decimal? HoursWorked { get; set; }

    public decimal? ProjectBillingAmt { get; set; }

    public decimal? Bonus { get; set; }

    public decimal? Deductions { get; set; }

    public decimal? Tax { get; set; }

    public decimal? NetPay { get; set; }

    public string PayStatus { get; set; } = null!;

    public int? ProcessedBy { get; set; }

    public DateTime? ProcessedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Department Dept { get; set; } = null!;

    public virtual Employee Emp { get; set; } = null!;

    public virtual Employee? ProcessedByNavigation { get; set; }

    public virtual Project? Project { get; set; }
}
