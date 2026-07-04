Use master;
GO


IF DB_ID('EmpMgmtDB') IS NULL
	CREATE DATABASE EmpMgmtDB;
GO

USE EmpMgmtDB;
GO

--- Create Schemas

If NOT EXISTS(SELECT 1 FROM sys.schemas WHERE name = 'auth')
	EXEC('CREATE SCHEMA [auth]');
GO

If NOT EXISTS(SELECT 1 FROM sys.schemas WHERE name = 'org')
	EXEC('CREATE SCHEMA [org]');
GO

If NOT EXISTS(SELECT 1 FROM sys.schemas WHERE name = 'ops')
	EXEC('CREATE SCHEMA [ops]');
GO

If NOT EXISTS(SELECT 1 FROM sys.schemas WHERE name = 'hr')
	EXEC('CREATE SCHEMA [hr]');
GO

IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'syslog')  -- 'system' is reserved in SQL Server
    EXEC('CREATE SCHEMA [syslog]');
GO


CREATE TABLE [auth].[Role]
(
	roleId INT IDENTITY(1,1) CONSTRAINT PK_tblRole_roleId PRIMARY KEY,
	roleName NVARCHAR(100) NOT NULL CONSTRAINT UQ_tblRole_roleName UNIQUE,
	roleLevel NVARCHAR(50) NOT NULL,
	permissionsJson NVARCHAR(MAX), -- by default nullable 
	createdAt DATETIME2 NOT NULL CONSTRAINT DF_tblRole_createdAt DEFAULT GETDATE() 

);
GO

CREATE TABLE [org].[Department]
(
	deptId INT IDENTITY(1,1) CONSTRAINT PK_tblDept_deptId PRIMARY KEY,
	deptName NVARCHAR(150) NOT NULL,
	costCenter NVARCHAR(50),
	deptCode NVARCHAR(20) NOT NULL CONSTRAINT UQ_tblDept_deptCode UNIQUE,
	[location] NVARCHAR(200),
	headEmpId INT, -- FK added after tblEmp
	createdAt DATETIME2 NOT NULL CONSTRAINT DF_tblDept_createdAt DEFAULT GETDATE(),
	isActive BIT NOT NULL CONSTRAINT DF_tblDept_isActive DEFAULT 1 -- 1 : active and 0 : inactive
);
GO

CREATE TABLE [auth].[Employee]
(
	empId INT IDENTITY(1,1) CONSTRAINT PK_tblEmp_empId PRIMARY KEY, 
	empCode NVARCHAR(10) CONSTRAINT UQ_tblEmp_empCode UNIQUE, -- Inline Named unique CONSTRAINT
		-- this is a computed col
	firstName NVARCHAR(100) NOT NULL,
	lastName NVARCHAR(100) NOT NULL,
	email NVARCHAR(255) NOT NULL CONSTRAINT UQ_tblEmp_email UNIQUE,
	passwordHash NVARCHAR(512) NOT NULL,
	phone NVARCHAR(20),
	dateOfBirth date NOT NULL,
	gender NVARCHAR(20),
	[address] NVARCHAR(500),
	hireDate date NOT NULL,
	empStatus NVARCHAR(30) NOT NULL CONSTRAINT DF_tblEmp_empStatus DEFAULT 'active', -- active|terminated|inactive
	deptId INT NOT NULL,
	managerId INT CONSTRAINT
	FK_tblEmp_managerId Foreign key (managerId) REFERENCES [auth].[Employee](empId), -- Inline Named FK CONSTRAINT
		-- self-referential FK
	roleId INT REFERENCES [auth].[Role](roleId), -- Inline shorthand FK CONSTRAINT
	profilePicUrl NVARCHAR(500),
	emergencyContact NVARCHAR(200),
	createdAt DATETIME2 NOT NULL CONSTRAINT DF_tblEmp_createdAt DEFAULT GETDATE(),
	updatedAt DATETIME2 NOT NULL CONSTRAINT DF_tblEmp_updatedAt DEFAULT GETDATE(),

	-- Table-level CONSTRAINT
	CONSTRAINT 
	FK_tblEmp_deptId Foreign Key (deptId) REFERENCES [org].[Department](deptId)
	On delete No Action -- on deletion of a dept from tblDept , do nothing with the record present in tblEmp for that deptId
	on update cascade -- on updation of a deptId in tblDept, update the same deptId in tblEmp as well
	
);
GO

-- Back-fill Department head FK
Alter table [org].[Department]
Add CONSTRAINT FK_tblDept_headEmpId Foreign Key (headEmpId) REFERENCES [auth].[Employee]
GO


CREATE TABLE [org].[Project]
(
	projectId INT IDENTITY(1,1) CONSTRAINT PK_tblProject_projectId PRIMARY KEY,
	projectName NVARCHAR(200) NOT NULL,
	projectCode NVARCHAR(50) CONSTRAINT UQ_tblProject_projectCode UNIQUE,
	deptId INT NOT NULL CONSTRAINT FK_tblProject_deptId REFERENCES [org].[Department](deptId), -- Inline Named ShortHand FK CONSTRAINT
	leadEmpId INT CONSTRAINT FK_tblProject_leadEmpId foreign Key REFERENCES [auth].[Employee](empId),
	startDate date NOT NULL,
	endDate date,
	[status] NVARCHAR(30) NOT NULL CONSTRAINT DF_tblProject_status DEFAULT 'active',-- active|completed|onHold|cancelled
	budget DECIMAL(18,2), -- Precision = 18 ? up to 18 digits total.
						  -- Scale = 2 ? 2 digits after the DECIMAL.
	billingRate DECIMAL(10,2), --Precision = 10 ? up to 10 digits total.
							   -- Scale = 2 ? 2 digits after the DECIMAL.
	clientName NVARCHAR(200),
	[description] NVARCHAR(MAX),
	createdAt DATETIME2 NOT NULL CONSTRAINT DF_tblProject_createdAt DEFAULT GETDATE()

);
GO

CREATE TABLE [org].[EmployeeProject]
(
	empProjId INT IDENTITY(1,1) CONSTRAINT PK_tblEmpProj_empProjId PRIMARY KEY,
	empId INT NOT NULL CONSTRAINT FK_tblEmpProj_empId REFERENCES [auth].[Employee](empId),
	projectId INT NOT NULL CONSTRAINT FK_tblEmpProj_projId REFERENCES [org].[Project](projectId),
	assignmentRole NVARCHAR(100),
	assignedFrom DATE NOT NULL,
	assignedTo DATE,
	allocationPct DECIMAL(5,2) CONSTRAINT DF_tblEmpProj_allocationPct DEFAULT 100.00, -- % of time on this project
	createdAt DATETIME2 NOT NULL CONSTRAINT DF_tblEmpProj_createdAt DEFAULT GETDATE(),
);
GO

CREATE TABLE [ops].[Attendance]
(
	attendanceId INT IDENTITY(1,1) CONSTRAINT PK_tblAttendance_attendanceId PRIMARY KEY,
	empId INT NOT NULL CONSTRAINT FK_tblAttendance_empId REFERENCES [auth].[Employee](empId),
	attendanceDate DATE NOT NULL,
	checkIn DATETIME2,
	checkOut DATETIME2,
	totalHours DECIMAL(5,2), -- this is a computed col
	entryMethod NVARCHAR(20) NOT NULL CONSTRAINT DF_tblAttendance_entryMthd DEFAULT 'swipe', --swipe|manual|remote
	[status] NVARCHAR(30) NOT NULL CONSTRAINT DF_tblAttendance_status DEFAULT 'present',--present|absent|halfDay|wfh|holiday
	remarks NVARCHAR(500),
	createdAt DATETIME2 NOT NULL CONSTRAINT DF_tblAttendance_createdAt DEFAULT GETDATE(),
);
GO


CREATE TABLE [ops].[WorkLog]
(
	workHoursId INT IDENTITY(1,1) CONSTRAINT PK_tblWorkLog_workHoursId PRIMARY KEY,
	empId INT NOT NULL CONSTRAINT FK_tblWorkLog_empId REFERENCES [auth].[Employee](empId),
	projectId INT NOT NULL CONSTRAINT FK_tblWorkLog_projectId REFERENCES [org].[Project](projectId),
	workDate DATE NOT NULL,
	hoursLogged DECIMAL(5,2) NOT NULL,
	taskDescription NVARCHAR(MAX), 
	approvalStatus NVARCHAR(20) NOT NULL CONSTRAINT DF_tblWorkLog_approvalStatus DEFAULT 'pending',--pending|approved|rejected
	approvedBy INT CONSTRAINT FK_tblWorkLog_approvedBy REFERENCES [auth].[Employee](empId),
	approvedAt DATETIME2,
	createdAt DATETIME2 NOT NULL CONSTRAINT DF_tblWorkLog_createdAt DEFAULT GETDATE(),
);
GO

CREATE TABLE [ops].[Payroll]
(
	payrollId INT IDENTITY(1,1) CONSTRAINT PK_tblPayroll_payrollId PRIMARY KEY ,
	empId INT NOT NULL CONSTRAINT FK_tblPayroll_empId REFERENCES [auth].[Employee](empId),
	deptId INT NOT NULL CONSTRAINT FK_tblPayroll_deptId REFERENCES [org].[Department](deptId),
	projectId INT CONSTRAINT FK_tblPayroll_projectId REFERENCES [org].[Project](projectId),
	payPeriodStart DATE NOT NULL,
	payPeriodEnd DATE NOT NULL,
	baseSalary DECIMAL(18,2) NOT NULL,
	hourlyRate DECIMAL(10,2),
	hoursWorked DECIMAL(7,2),
	projectBillingAmt DECIMAL(18,2), -- hours * tblProject.billingRate
	bonus DECIMAL(18,2) CONSTRAINT DF_tblPayroll_bonus DEFAULT 0,
	deductions DECIMAL(18,2) CONSTRAINT DF_tblPayroll_deductions DEFAULT 0,
	tax DECIMAL(18,2) CONSTRAINT DF_tblPayroll_tax DEFAULT 0,
	netPay DECIMAL(18,2), -- this is a computed col
	payStatus NVARCHAR(20) NOT NULL CONSTRAINT DF_tblPayroll_payStatus DEFAULT 'pending', --pending|processed|paid
	processedBy INT CONSTRAINT FK_tblPayroll_processedBy REFERENCES [auth].[Employee](empId),
	processedAt DATETIME2,
	createdAt DATETIME2 NOT NULL CONSTRAINT DF_tblPayroll_createdAt DEFAULT GETDATE(),
);
GO

CREATE TABLE [hr].[LeaveReq]
(
	leaveId INT IDENTITY(1,1) CONSTRAINT PK_tblLeaveReq_leaveId PRIMARY KEY ,
	empId INT NOT NULL CONSTRAINT FK_tblLeaveReq_empId REFERENCES [auth].[Employee](empId),
	leaveType NVARCHAR(50) NOT NULL,
	fromDate DATE NOT NULL,
	toDate DATE NOT NULL,
	totalDays INT, --this is calculated col
	reason NVARCHAR(500),
	[status] NVARCHAR(20) NOT NULL CONSTRAINT DF_tblLeaveReq_status DEFAULT 'pending',-- pending|approved|rejected|cancelled
	approvedBy INT CONSTRAINT FK_tblLeaveReq_approvedBy REFERENCES [auth].[Employee](empId),
	approvedAt DATETIME2,
	appliedOn DATETIME2 NOT NULL CONSTRAINT DF_tblLeaveReq_appliedOn DEFAULT GETDATE(),
);
GO

CREATE TABLE [hr].[PerfRating]
(
	ratingId INT IDENTITY(1,1) CONSTRAINT PK_tblPerfRating_ratingId PRIMARY KEY,
	empId INT NOT NULL CONSTRAINT FK_tblPerfRating_empId REFERENCES [auth].[Employee](empId),
	ratedBy INT NOT NULL CONSTRAINT FK_tblPerfRating_ratedBy REFERENCES [auth].[Employee](empId),
	[quarter] TINYINT NOT NULL, -- 1,2,3,4
	[year] SMALLINT NOT NULL, 
	ratingScore DECIMAL(3,1) NOT NULL, -- 1.0 : 5.0
	feedback NVARCHAR(MAX),
	goalsNextQtr NVARCHAR(MAX),
	ratingStatus NVARCHAR(20) NOT NULL CONSTRAINT DF_tblPerfRating_ratingStatus DEFAULT 'draft',
	acknowledgedAt DATETIME2,
	createdAt DATETIME2 NOT NULL CONSTRAINT DF_tblPerfRating_createdAt DEFAULT GETDATE(),
);
GO

CREATE TABLE [hr].[Asset]
(
	assetId INT IDENTITY(1,1) CONSTRAINT PK_tblAsset_assetId PRIMARY KEY, 
	empId INT CONSTRAINT FK_tblAsset_empId REFERENCES [auth].[Employee](empId), -- by default col is nullable except PK cols they are NOT NULL + UNIQUE by  also FK col can have null values but PK cann't
	assetType NVARCHAR(100) NOT NULL,
	assetName NVARCHAR(200),
	serialNumber NVARCHAR(100) NOT NULL CONSTRAINT UQ_tblAsset_serialNumber UNIQUE,
	assignedDate DATE,
	returnDate DATE,
	assetStatus NVARCHAR(30) NOT NULL CONSTRAINT DF_tblAsset_assetStatus DEFAULT 'available',-- available|assigned|returned|damaged
	notes NVARCHAR(500),
	createdAt DATETIME2 NOT NULL CONSTRAINT DF_tblAsset_createdAt DEFAULT GETDATE(),
);
GO

CREATE TABLE [syslog].[Notification]
(
	notifId INT IDENTITY(1,1)  CONSTRAINT PK_tblNotification_notifId PRIMARY KEY,
    empId INT NOT NULL CONSTRAINT FK_tblNotification_empId REFERENCES [auth].[Employee](empId),
	notifType NVARCHAR(50) NOT NULL,
	[message] NVARCHAR(MAX) NOT NULL,
	isRead BIT NOT NULL CONSTRAINT DF_tblNotification_isRead DEFAULT 0,
	createdAt DATETIME2 NOT NULL CONSTRAINT DF_tblNotification_createdAt DEFAULT GETDATE(),
);
GO

CREATE TABLE [syslog].[AuditLog]
(
	logId INT IDENTITY(1,1) CONSTRAINT PK_tblAuditLog_logId PRIMARY KEY,
	empId INT CONSTRAINT FK_tblAuditLog_empId REFERENCES [auth].[Employee](empId),
	[action]  NVARCHAR(100) NOT NULL,
	tableAffected NVARCHAR(100),
	recordId INT,
	oldValue NVARCHAR(MAX),
	newValue NVARCHAR(MAX),
	actionAt DATETIME2 NOT NULL CONSTRAINT DF_tblAuditLog_actionAt DEFAULT GETDATE(),
	ipAddress NVARCHAR(50)
);
GO

-- Adding CONSTRAINTs explicillty
-- 1. ops.WorkLog — hours must be positive and MAX 24
ALTER TABLE [ops].[WorkLog]
ADD CONSTRAINT CK_tblWorkLog_hoursLogged
    CHECK (hoursLogged > 0 AND hoursLogged <= 24);
GO

-- 2. hr.LeaveReq — end date must be on or after start date
ALTER TABLE [hr].[LeaveReq]
ADD CONSTRAINT CK_tblLeaveReq_dates
    CHECK (toDate >= fromDate);
GO

-- 3. hr.PerfRating — score must be between 1.0 and 5.0
ALTER TABLE [hr].[PerfRating]
ADD CONSTRAINT CK_tblPerfRating_ratingScore
    CHECK (ratingScore BETWEEN 1.0 AND 5.0);
GO

-- 4. hr.PerfRating — quarter must be 1, 2, 3, or 4
ALTER TABLE [hr].[PerfRating]
ADD CONSTRAINT CK_tblPerfRating_quarter
    CHECK (quarter BETWEEN 1 AND 4);
GO