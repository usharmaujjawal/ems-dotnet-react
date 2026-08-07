using System;
using System.Collections.Generic;

namespace EmpMgmtSystem.Infra;

public partial class RefreshToken
{
    public Guid Id { get; set; }

    public int EmpId { get; set; }

    public string Token { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }

    public bool IsRevoked { get; set; }

    public DateTime? RevokedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? CreatedByIp { get; set; }

    public bool? IsExpired { get; set; }

    public bool? IsActive { get; set; }
}
