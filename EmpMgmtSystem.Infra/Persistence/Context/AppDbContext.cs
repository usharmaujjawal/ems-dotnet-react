using System;
using System.Collections.Generic;
using EmpMgmtSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmpMgmtSystem.Infra.Persistence.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asset> Assets { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeProject> EmployeeProjects { get; set; }

    public virtual DbSet<LeaveReq> LeaveReqs { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Payroll> Payrolls { get; set; }

    public virtual DbSet<PerfRating> PerfRatings { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<WorkLog> WorkLogs { get; set; }

    // removed OnConfiguring() since it will be injected from the IoC container
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset>(entity =>
        {
            entity.HasKey(e => e.AssetId).HasName("PK_tblAsset_assetId");

            entity.ToTable("Asset", "hr");

            entity.HasIndex(e => e.SerialNumber, "UQ_tblAsset_serialNumber").IsUnique();

            entity.Property(e => e.AssetId).HasColumnName("assetId");
            entity.Property(e => e.AssetName)
                .HasMaxLength(200)
                .HasColumnName("assetName");
            entity.Property(e => e.AssetStatus)
                .HasMaxLength(30)
                .HasDefaultValue("available")
                .HasColumnName("assetStatus");
            entity.Property(e => e.AssetType)
                .HasMaxLength(100)
                .HasColumnName("assetType");
            entity.Property(e => e.AssignedDate).HasColumnName("assignedDate");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createdAt");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .HasColumnName("notes");
            entity.Property(e => e.ReturnDate).HasColumnName("returnDate");
            entity.Property(e => e.SerialNumber)
                .HasMaxLength(100)
                .HasColumnName("serialNumber");

            entity.HasOne(d => d.Emp).WithMany(p => p.Assets)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblAsset_empId");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK_tblAttendance_attendanceId");

            entity.ToTable("Attendance", "ops");

            entity.Property(e => e.AttendanceId).HasColumnName("attendanceId");
            entity.Property(e => e.AttendanceDate).HasColumnName("attendanceDate");
            entity.Property(e => e.CheckIn).HasColumnName("checkIn");
            entity.Property(e => e.CheckOut).HasColumnName("checkOut");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createdAt");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.EntryMethod)
                .HasMaxLength(20)
                .HasDefaultValue("swipe")
                .HasColumnName("entryMethod");
            entity.Property(e => e.Remarks)
                .HasMaxLength(500)
                .HasColumnName("remarks");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasDefaultValue("present")
                .HasColumnName("status");
            entity.Property(e => e.TotalHours)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("totalHours");

            entity.HasOne(d => d.Emp).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblAttendance_empId");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK_tblAuditLog_logId");

            entity.ToTable("AuditLog", "syslog");

            entity.Property(e => e.LogId).HasColumnName("logId");
            entity.Property(e => e.Action)
                .HasMaxLength(100)
                .HasColumnName("action");
            entity.Property(e => e.ActionAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("actionAt");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .HasColumnName("ipAddress");
            entity.Property(e => e.NewValue).HasColumnName("newValue");
            entity.Property(e => e.OldValue).HasColumnName("oldValue");
            entity.Property(e => e.RecordId).HasColumnName("recordId");
            entity.Property(e => e.TableAffected)
                .HasMaxLength(100)
                .HasColumnName("tableAffected");

            entity.HasOne(d => d.Emp).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK_tblAuditLog_empId");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeptId).HasName("PK_tblDept_deptId");

            entity.ToTable("Department", "org");

            entity.HasIndex(e => e.DeptCode, "UQ_tblDept_deptCode").IsUnique();

            entity.Property(e => e.DeptId).HasColumnName("deptId");
            entity.Property(e => e.CostCenter)
                .HasMaxLength(50)
                .HasColumnName("costCenter");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeptCode)
                .HasMaxLength(20)
                .HasColumnName("deptCode");
            entity.Property(e => e.DeptName)
                .HasMaxLength(150)
                .HasColumnName("deptName");
            entity.Property(e => e.HeadEmpId).HasColumnName("headEmpId");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .HasColumnName("location");

            entity.HasOne(d => d.HeadEmp).WithMany(p => p.Departments)
                .HasForeignKey(d => d.HeadEmpId)
                .HasConstraintName("FK_tblDept_headEmpId");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK_tblEmp_empId");

            entity.ToTable("Employee", "auth");

            entity.HasIndex(e => e.Email, "UQ_tblEmp_email").IsUnique();

            entity.HasIndex(e => e.EmpCode, "UQ_tblEmp_empCode").IsUnique();

            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createdAt");
            entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
            entity.Property(e => e.DeptId).HasColumnName("deptId");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.EmergencyContact)
                .HasMaxLength(200)
                .HasColumnName("emergencyContact");
            entity.Property(e => e.EmpCode)
                .HasMaxLength(10)
                .HasColumnName("empCode");
            entity.Property(e => e.EmpStatus)
                .HasMaxLength(30)
                .HasDefaultValue("active")
                .HasColumnName("empStatus");
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .HasColumnName("firstName");
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .HasColumnName("gender");
            entity.Property(e => e.HireDate).HasColumnName("hireDate");
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .HasColumnName("lastName");
            entity.Property(e => e.ManagerId).HasColumnName("managerId");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(512)
                .HasColumnName("passwordHash");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.ProfilePicUrl)
                .HasMaxLength(500)
                .HasColumnName("profilePicUrl");
            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.Dept).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblEmp_deptId");

            entity.HasOne(d => d.Manager).WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_tblEmp_managerId");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Employee__roleId__440B1D61");
        });

        modelBuilder.Entity<EmployeeProject>(entity =>
        {
            entity.HasKey(e => e.EmpProjId).HasName("PK_tblEmpProj_empProjId");

            entity.ToTable("EmployeeProject", "org");

            entity.Property(e => e.EmpProjId).HasColumnName("empProjId");
            entity.Property(e => e.AllocationPct)
                .HasDefaultValue(100.00m)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("allocationPct");
            entity.Property(e => e.AssignedFrom).HasColumnName("assignedFrom");
            entity.Property(e => e.AssignedTo).HasColumnName("assignedTo");
            entity.Property(e => e.AssignmentRole)
                .HasMaxLength(100)
                .HasColumnName("assignmentRole");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createdAt");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.ProjectId).HasColumnName("projectId");

            entity.HasOne(d => d.Emp).WithMany(p => p.EmployeeProjects)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblEmpProj_empId");

            entity.HasOne(d => d.Project).WithMany(p => p.EmployeeProjects)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblEmpProj_projId");
        });

        modelBuilder.Entity<LeaveReq>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PK_tblLeaveReq_leaveId");

            entity.ToTable("LeaveReq", "hr");

            entity.Property(e => e.LeaveId).HasColumnName("leaveId");
            entity.Property(e => e.AppliedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("appliedOn");
            entity.Property(e => e.ApprovedAt).HasColumnName("approvedAt");
            entity.Property(e => e.ApprovedBy).HasColumnName("approvedBy");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.FromDate).HasColumnName("fromDate");
            entity.Property(e => e.LeaveType)
                .HasMaxLength(50)
                .HasColumnName("leaveType");
            entity.Property(e => e.Reason)
                .HasMaxLength(500)
                .HasColumnName("reason");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("status");
            entity.Property(e => e.ToDate).HasColumnName("toDate");
            entity.Property(e => e.TotalDays).HasColumnName("totalDays");

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.LeaveReqApprovedByNavigations)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("FK_tblLeaveReq_approvedBy");

            entity.HasOne(d => d.Emp).WithMany(p => p.LeaveReqEmps)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblLeaveReq_empId");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotifId).HasName("PK_tblNotification_notifId");

            entity.ToTable("Notification", "syslog");

            entity.Property(e => e.NotifId).HasColumnName("notifId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createdAt");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.IsRead).HasColumnName("isRead");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.NotifType)
                .HasMaxLength(50)
                .HasColumnName("notifType");

            entity.HasOne(d => d.Emp).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblNotification_empId");
        });

        modelBuilder.Entity<Payroll>(entity =>
        {
            entity.HasKey(e => e.PayrollId).HasName("PK_tblPayroll_payrollId");

            entity.ToTable("Payroll", "ops");

            entity.Property(e => e.PayrollId).HasColumnName("payrollId");
            entity.Property(e => e.BaseSalary)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("baseSalary");
            entity.Property(e => e.Bonus)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("bonus");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createdAt");
            entity.Property(e => e.Deductions)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("deductions");
            entity.Property(e => e.DeptId).HasColumnName("deptId");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.HourlyRate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("hourlyRate");
            entity.Property(e => e.HoursWorked)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("hoursWorked");
            entity.Property(e => e.NetPay)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("netPay");
            entity.Property(e => e.PayPeriodEnd).HasColumnName("payPeriodEnd");
            entity.Property(e => e.PayPeriodStart).HasColumnName("payPeriodStart");
            entity.Property(e => e.PayStatus)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("payStatus");
            entity.Property(e => e.ProcessedAt).HasColumnName("processedAt");
            entity.Property(e => e.ProcessedBy).HasColumnName("processedBy");
            entity.Property(e => e.ProjectBillingAmt)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("projectBillingAmt");
            entity.Property(e => e.ProjectId).HasColumnName("projectId");
            entity.Property(e => e.Tax)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("tax");

            entity.HasOne(d => d.Dept).WithMany(p => p.Payrolls)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPayroll_deptId");

            entity.HasOne(d => d.Emp).WithMany(p => p.PayrollEmps)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPayroll_empId");

            entity.HasOne(d => d.ProcessedByNavigation).WithMany(p => p.PayrollProcessedByNavigations)
                .HasForeignKey(d => d.ProcessedBy)
                .HasConstraintName("FK_tblPayroll_processedBy");

            entity.HasOne(d => d.Project).WithMany(p => p.Payrolls)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_tblPayroll_projectId");
        });

        modelBuilder.Entity<PerfRating>(entity =>
        {
            entity.HasKey(e => e.RatingId).HasName("PK_tblPerfRating_ratingId");

            entity.ToTable("PerfRating", "hr");

            entity.Property(e => e.RatingId).HasColumnName("ratingId");
            entity.Property(e => e.AcknowledgedAt).HasColumnName("acknowledgedAt");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createdAt");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.Feedback).HasColumnName("feedback");
            entity.Property(e => e.GoalsNextQtr).HasColumnName("goalsNextQtr");
            entity.Property(e => e.Quarter).HasColumnName("quarter");
            entity.Property(e => e.RatedBy).HasColumnName("ratedBy");
            entity.Property(e => e.RatingScore)
                .HasColumnType("decimal(3, 1)")
                .HasColumnName("ratingScore");
            entity.Property(e => e.RatingStatus)
                .HasMaxLength(20)
                .HasDefaultValue("draft")
                .HasColumnName("ratingStatus");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Emp).WithMany(p => p.PerfRatingEmps)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPerfRating_empId");

            entity.HasOne(d => d.RatedByNavigation).WithMany(p => p.PerfRatingRatedByNavigations)
                .HasForeignKey(d => d.RatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblPerfRating_ratedBy");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK_tblProject_projectId");

            entity.ToTable("Project", "org");

            entity.HasIndex(e => e.ProjectCode, "UQ_tblProject_projectCode").IsUnique();

            entity.Property(e => e.ProjectId).HasColumnName("projectId");
            entity.Property(e => e.BillingRate)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("billingRate");
            entity.Property(e => e.Budget)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("budget");
            entity.Property(e => e.ClientName)
                .HasMaxLength(200)
                .HasColumnName("clientName");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createdAt");
            entity.Property(e => e.DeptId).HasColumnName("deptId");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.LeadEmpId).HasColumnName("leadEmpId");
            entity.Property(e => e.ProjectCode)
                .HasMaxLength(50)
                .HasColumnName("projectCode");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(200)
                .HasColumnName("projectName");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasDefaultValue("active")
                .HasColumnName("status");

            entity.HasOne(d => d.Dept).WithMany(p => p.Projects)
                .HasForeignKey(d => d.DeptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblProject_deptId");

            entity.HasOne(d => d.LeadEmp).WithMany(p => p.Projects)
                .HasForeignKey(d => d.LeadEmpId)
                .HasConstraintName("FK_tblProject_leadEmpId");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK_tblRole_roleId");

            entity.ToTable("Role", "auth");

            entity.HasIndex(e => e.RoleName, "UQ_tblRole_roleName").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("roleId");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createdAt");
            entity.Property(e => e.PermissionsJson).HasColumnName("permissionsJson");
            entity.Property(e => e.RoleLevel)
                .HasMaxLength(50)
                .HasColumnName("roleLevel");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<WorkLog>(entity =>
        {
            entity.HasKey(e => e.WorkHoursId).HasName("PK_tblWorkLog_workHoursId");

            entity.ToTable("WorkLog", "ops");

            entity.Property(e => e.WorkHoursId).HasColumnName("workHoursId");
            entity.Property(e => e.ApprovalStatus)
                .HasMaxLength(20)
                .HasDefaultValue("pending")
                .HasColumnName("approvalStatus");
            entity.Property(e => e.ApprovedAt).HasColumnName("approvedAt");
            entity.Property(e => e.ApprovedBy).HasColumnName("approvedBy");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createdAt");
            entity.Property(e => e.EmpId).HasColumnName("empId");
            entity.Property(e => e.HoursLogged)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("hoursLogged");
            entity.Property(e => e.ProjectId).HasColumnName("projectId");
            entity.Property(e => e.TaskDescription).HasColumnName("taskDescription");
            entity.Property(e => e.WorkDate).HasColumnName("workDate");

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.WorkLogApprovedByNavigations)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("FK_tblWorkLog_approvedBy");

            entity.HasOne(d => d.Emp).WithMany(p => p.WorkLogEmps)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblWorkLog_empId");

            entity.HasOne(d => d.Project).WithMany(p => p.WorkLogs)
                .HasForeignKey(d => d.ProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblWorkLog_projectId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
