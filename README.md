# EMS (Employee Management System) - .NET & React

A full-stack **Employee Management System** built with a modern **Clean Architecture** pattern, featuring:

- **Backend**: .NET 9.0 Web API with layered architecture
- **Frontend**: React.js 19 + Vite
- **Database**: SQL Server with Entity Framework Core
- **Testing**: xUnit with Moq framework

## Project Overview

This is a professional full-stack application demonstrating enterprise-level architecture patterns and best practices.

---

## 📋 Project Structure

```
ems-dotnet-react/
├── EmpMgmtSystem.Domain/              # Core Domain Layer
├── EmpMgmtSystem.Application/         # Application Layer (CQRS, Services, DTOs)
├── EmpMgmtSystem.Infra/               # Infrastructure Layer (Data Access, Repositories)
├── EmpMgmtSystem.API/                 # Presentation Layer (Web API)
├── EmpMgmtSystem.UI/                  # Frontend (React + Vite)
├── tests/                              # Unit Tests
│   ├── EmpMgmtSystem.Domain.Tests/
│   ├── EmpMgmtSystem.Application.Tests/
│   ├── EmpMgmtSystem.Infra.Tests/
│   └── EmpMgmtSystem.API.Tests/
├── DbScripts/                          # Database Scripts
│   ├── Schema/                        # Database schema creation
│   └── Procedures/                    # Stored procedures
├── Documents/                          # Documentation
└── EmpMgmtSystem.sln                  # Solution file
```

---

## 🏗️ Clean Architecture Layers

### 1. **Domain Layer** (EmpMgmtSystem.Domain)

- **Created**: `dotnet new classlib -n EmpMgmtSystem.Domain`
- **Purpose**: Core business logic, entities, and domain interfaces
- **Contains**: Entities, Enums, Interfaces, ValueObjects
- **Dependencies**: None (no external dependencies)
- [View Domain Layer Details →](./EmpMgmtSystem.Domain/README.md)

### 2. **Application Layer** (EmpMgmtSystem.Application)

- **Created**: `dotnet new classlib -n EmpMgmtSystem.Application`
- **Purpose**: Business rules, use cases, DTOs, and service contracts
- **Contains**: DTOs, Services, Validators, Mappings, Common utilities
- **Dependencies**: Domain layer only
- [View Application Layer Details →](./EmpMgmtSystem.Application/README.md)

### 3. **Infrastructure Layer** (EmpMgmtSystem.Infra)

- **Created**: `dotnet new classlib -n EmpMgmtSystem.Infra`
- **Purpose**: Data access, repositories, database context, and external services
- **Contains**: DbContext, Repositories, UnitOfWork, Persistence Configurations
- **Dependencies**: Domain + Application layers
- [View Infrastructure Layer Details →](./EmpMgmtSystem.Infra/README.md)

### 4. **API Layer** (EmpMgmtSystem.API)

- **Created**: `dotnet new webapi -n EmpMgmtSystem.API`
- **Purpose**: HTTP endpoints, controllers, middleware, and API configuration
- **Contains**: Controllers, Middleware, Filters, Extensions, Configurations
- **Dependencies**: All layers (Domain, Application, Infrastructure)
- [View API Layer Details →](./EmpMgmtSystem.API/README.md)

### 5. **UI Layer** (EmpMgmtSystem.UI)

- **Created**: `npm create vite@latest EmpMgmtSystem.UI`
- **Purpose**: React frontend with Vite bundler
- **Contains**: Components, Pages, Services, Hooks, Context, Utils
- **Technology**: React 18+, Vite, Axios
- [View UI Layer Details →](./EmpMgmtSystem.UI/README.md)

---

## 🔧 Project Creation Steps

### Step 1: Create Solution

```bash
dotnet new sln -n ems-dotnet-react
cd ems-dotnet-react
```

### Step 2: Create Projects (Clean Architecture)

```bash
# Domain Layer (Core Business Logic)
dotnet new classlib -n EmpMgmtSystem.Domain

# Application Layer (Use Cases & Business Rules)
dotnet new classlib -n EmpMgmtSystem.Application

# Infrastructure Layer (Data Access & External Services)
dotnet new classlib -n EmpMgmtSystem.Infra

# API Layer (Presentation)
dotnet new webapi -n EmpMgmtSystem.API
```

### Step 3: Add Projects to Solution

```bash
dotnet sln add EmpMgmtSystem.Domain
dotnet sln add EmpMgmtSystem.Application
dotnet sln add EmpMgmtSystem.Infra
dotnet sln add EmpMgmtSystem.API
```

### Step 4: Add Project References (Dependency Graph)

```bash
# API depends on Application & Infrastructure
dotnet add EmpMgmtSystem.API/EmpMgmtSystem.API.csproj reference EmpMgmtSystem.Application/EmpMgmtSystem.Application.csproj
dotnet add EmpMgmtSystem.API/EmpMgmtSystem.API.csproj reference EmpMgmtSystem.Infra/EmpMgmtSystem.Infra.csproj

# Application depends on Domain
dotnet add EmpMgmtSystem.Application/EmpMgmtSystem.Application.csproj reference EmpMgmtSystem.Domain/EmpMgmtSystem.Domain.csproj

# Infrastructure depends on Application & Domain
dotnet add EmpMgmtSystem.Infra/EmpMgmtSystem.Infra.csproj reference EmpMgmtSystem.Application/EmpMgmtSystem.Application.csproj
dotnet add EmpMgmtSystem.Infra/EmpMgmtSystem.Infra.csproj reference EmpMgmtSystem.Domain/EmpMgmtSystem.Domain.csproj
```

### Step 5: Create Testing Projects (xUnit + Moq)

```bash
# Navigate to solution root
cd ems-dotnet-react
mkdir tests
cd tests

# Domain tests
dotnet new xunit -n EmpMgmtSystem.Domain.Tests
dotnet add EmpMgmtSystem.Domain.Tests/EmpMgmtSystem.Domain.Tests.csproj reference ../EmpMgmtSystem.Domain/EmpMgmtSystem.Domain.csproj

# Application tests
dotnet new xunit -n EmpMgmtSystem.Application.Tests
dotnet add EmpMgmtSystem.Application.Tests/EmpMgmtSystem.Application.Tests.csproj reference ../EmpMgmtSystem.Application/EmpMgmtSystem.Application.csproj

# Infrastructure tests
dotnet new xunit -n EmpMgmtSystem.Infra.Tests
dotnet add EmpMgmtSystem.Infra.Tests/EmpMgmtSystem.Infra.Tests.csproj reference ../EmpMgmtSystem.Infra/EmpMgmtSystem.Infra.csproj

# API tests
dotnet new xunit -n EmpMgmtSystem.API.Tests
dotnet add EmpMgmtSystem.API.Tests/EmpMgmtSystem.API.Tests.csproj reference ../EmpMgmtSystem.API/EmpMgmtSystem.API.csproj

# Add test projects to solution (from root)
cd ..
dotnet sln add tests/EmpMgmtSystem.Domain.Tests
dotnet sln add tests/EmpMgmtSystem.Application.Tests
dotnet sln add tests/EmpMgmtSystem.Infra.Tests
dotnet sln add tests/EmpMgmtSystem.API.Tests
```

### Step 6: Create React Frontend

```bash
npm create vite@latest EmpMgmtSystem.UI
cd EmpMgmtSystem.UI
npm install
```

### Step 7 : Add the folders to different project based on the folder structure that we are going to use for the solution(initially we can keep only necessary folder then add as & when needed)

### Step 8 : Adding packages for EFCore : Need to add those packages into Infra project

```bash
cd EmpMgmtSystem.Infra

# Core EF package - mandatory
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0

# Database-specific provider(Changes based on DB) - without this we can’t connect to db.
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.0

# Design package (for migrations) - In-memory testing → Design not needed
dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0
```

-- Since all the dotnet-ef related cmds are run at root level and API(webapi) is our startup project so the usoft.EFCore.Design pkg should also be installed at the API project as well

- Note
  - if getting version incompatible error while running migrations or scaffolding cmds then install compatible versions i.e check the version of EFCore compatible with .NETCore version of our application.
  - to make sure that pkgs are installed check the
    <ItemGroup> tag in the .csproj file of that project where pkgs are installed
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="9.0.0" />
    </ItemGroup>

### Step 9 : Init - scaffolding models and DbContext

    - If using DB First Approach : Need to run scaffold cmds at root level(dotnet cli cmd)

        dotnet ef dbcontext scaffold "connStr" Microsoft.EntityFrameworkCore.SqlServer
        --project MyApp.Infrastructure
        --startup-project MyApp.API
        --output-dir Persistence/Models
        --context-dir Persistence/DbContext
        --context AppDbContext


    - If using Code First Approach : Need to run migrations cmds at root level(dotnet cli cmds)
        # dotnet ef migrations add InitialCreate

        - After creating migration we need to update the db using
        # dotnet ef database update


    - Notes:
        - if getting error like : ems-dotnet-react\EmpMgmtSystem.API\bin\Debug\net9.0\EmpMgmtSystem.Infra.dll' not found.
            - first we need to build our solution in order for the dll to be created
            - and all the references should be correctly updated i.e API --> Infra, Application

### Step 9.i After scaffolding (your responsibility)

    - Move files to proper folders
    	--output-dir Domain/Entities  We cannot give like this while scaffolding
    	This is relative to the Infrastructure project, not the Domain project.
    	❌ Problem: EF Core cannot scaffold directly into another project (Domain).

    	It will create a folder named Domain/Entities inside Infrastructure, not inside your Domain project.

    	If you truly want entities in Domain, you’ll need to move them manually or scaffold into Infrastructure and then refactor.


    - Register DbContext in API (i.e in Program.cs)
        - Whenever a controller or service asks for AppDbContext, ASP.NET Core creates one using the SQL Server connection string.

        - EF Core then uses that connection string to connect to your database and run queries/migrations.

### Step10 : to add controller class with boiler plate code we can use the below CLI cmd

```bash run at the api level
dotnet new apicontroller -n EmployeeController -o Controllers
```

### Step11 : Follow this graph to create service, repo interfaces and classes

    Controller (API Layer)
            ↓
    IEmployeeService (Application\Interfaces)
            ↓
    EmployeeService (Application\Services)
            ↓
    IEmployeeRepository (Domain\Interfaces)
            ↓
    EmployeeRepository (Infrastructure\Repositories)
            ↓
    AppDbContext (Infrastructure\Persistence)
            ↓
       Database

    - Generic dotnet CLI cmds
    	dotnet new class -n MyClass
    	dotnet new interface -n IMyService
    	dotnet new record -n MyRecord
    	dotnet new struct -n MyStruct

### Step 12 : Enabling swagger

```bash
Step i : install the nugget pkg - EmpMgmtSystem.API(project since it contains the Program.cs file)
		- and then install the version of swashbuckle compatible with .NET Version
	    dotnet add package Swashbuckle.AspNetCore --version 6.5.0  # compatible with .NET6/7/8

Step ii : Configure in Program.cs

Note:
    - DotNetCore WebAPI comes with prebuilt configuration for OpenAPI specification i.e json based API specification and can be accessed via : https://localhost:{port}/openapi/v1.json
    - to enable swagger UI we need to follow above steps
```

### Step 13 : Enabling JWT Authentication

    - a : Install the pkg into the API project: gives the middleware to validate JWTs automatically.
        dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 9.0.1 // compatible with .NET 9

    - b : Add Audience, Issuer, Expiration into the appsettings.json file & secrete_key into env variables or users_secrete

    - c : Enable jwt validation into the Program.cs file by defining all the configurations(what needs to be validated etc)

### step 14 : Added logic for Token Generation into TokenService

    - In order to access IConfiguration into Service(a class library), we need to install these below package(version 9.0.0 is compatible with .net9).
        dotnet add package Microsoft.Extensions.Configuration.Abstractions --version 9.0.0
        dotnet add package Microsoft.Extensions.Configuration.Binder --version 9.0.0 // this is required to use GetValue<T>()

    - We don’t need to install all packages in the Web API project — JwtBearer is sufficient.
    	-But we do need to install IdentityModel packages in our Application project if we’re generating tokens there
            dotnet add package System.IdentityModel.Tokens.Jwt
            dotnet add package Microsoft.IdentityModel.Tokens

### Step 15 : Enabling Refresh Token mechanism

    - a : We need to create a  RefreshToken entity class(having details about refresh token)
        - create the table refreshToken then run scaffolding command to get the entity class generated for this table(run this command at the project root level)

            dotnet ef dbcontext scaffold "ConnStr" Microsoft.EntityFrameworkCore.SqlServer --output-dir ../EmpMgmtSystem.Domain/Entities --context-dir Persistence/Context --context TempDbContext --project EmpMgmtSystem.Infra --startup-project EmpMgmtSystem.API --table RefreshToken --force

            - Since we have already moved the EFCore generated model classes into the Domain\Entities so we need to give this folder as the --output-dir
            - Also since AppDbContext is already created in the Infra project, we have to use a tempDbContext class which will have the changes only for the above table
            - Manual work : copy paste the changes from tempDbContext to AppDbContext & remove the temp context file.


        - it is better to have a separate table to store refresh token we can then track(Multiple sessions per user, Revocation & auditing etc)

    - b: then we need to create RefreshToken related service and repositories(if required) to handle operations related to refresh-token.

### Notes

    - In order to access IConfigurations from projects other than WebAPI(available by default in Controllers and other files) eg: A classlib, we need to install the below package

        dotnet add package Microsoft.Extensions.Configuration.Abstractions

## 📁 Detailed Folder Structure

### Backend Folder Structure

```
ems-dotnet-react/
├── EmpMgmtSystem.Domain/
│   ├── Entities/              # Domain models
│   ├── Interfaces/            # Repository & service contracts
│   ├── Enums/                 # Business enums
│   └── Exceptions/            # Domain exceptions
│
├── EmpMgmtSystem.Application/
│   ├── DTOs/                  # Data Transfer Objects
│   ├── Interfaces/            # Service contracts
│   ├── Services/              # Business logic implementation
│   ├── Validators/            # FluentValidation
│   ├── Mappings/              # AutoMapper profiles
│   └── Common/                # Helpers & constants
│
├── EmpMgmtSystem.Infra/
│   ├── Persistence/
│   │   ├── Context/          # AppDbContext (EF Core)
│   │   ├── Configurations/   # Entity configurations
│   │   └── Migrations/       # DB migrations
│   ├── Repositories/         # Repository implementations
│   ├── UnitOfWork/           # UnitOfWork pattern
│   └── Logging/              # Serilog configuration
│
├── EmpMgmtSystem.API/
│   ├── Controllers/          # API endpoints
│   ├── Middleware/           # Custom middleware
│   ├── Filters/              # Action & exception filters
│   ├── Configurations/       # API setup
│   ├── Program.cs            # Startup configuration
│   └── appsettings.json      # Configuration
│
└── tests/                     # All unit tests
    ├── EmpMgmtSystem.Domain.Tests/
    ├── EmpMgmtSystem.Application.Tests/
    ├── EmpMgmtSystem.Infra.Tests/
    └── EmpMgmtSystem.API.Tests/
```

### Frontend Folder Structure

```
EmpMgmtSystem.UI/
├── public/                   # Static files
├── src/
│   ├── assets/              # Images, fonts, styles
│   ├── components/          # Reusable UI components
│   ├── pages/               # Page components
│   ├── services/            # API calls (Axios)
│   ├── hooks/               # Custom React hooks
│   ├── context/             # Context API providers
│   ├── utils/               # Helper utilities
│   ├── store/               # State management
│   ├── App.jsx              # Root component
│   └── main.jsx             # Entry point
├── index.html               # Vite entry HTML
├── package.json
└── vite.config.js
```

---

## 🛠️ Technology Stack

### Backend

- **.NET Framework**: .NET 9.0
- **ORM**: Entity Framework Core (EF Core)
- **Testing**: xUnit + Moq
- **Validation**: FluentValidation
- **Mapping**: AutoMapper
- **Logging**: Serilog
- **Authentication**: JWT (JSON Web Tokens)

### Frontend

- **Framework**: React 18+
- **Build Tool**: Vite
- **HTTP Client**: Axios
- **State Management**: Context API / Zustand
- **Styling**: CSS3

### Database

- **Database**: SQL Server
- **Migrations**: EF Core Code-First Migrations

---

## 🔗 Dependency Graph

```
┌─────────────────────────────────┐
│    EmpMgmtSystem.API            │
│   (Presentation Layer)          │
└─────────────────────────────────┘
         │         │
         ↓         ↓
    ┌────────┐  ┌──────────────┐
    │  App   │  │ Infra        │
    │ Layer  │  │ (Data Access)│
    └────────┘  └──────────────┘
         │         │
         └────┬────┘
              ↓
    ┌─────────────────────┐
    │ EmpMgmtSystem.Domain│
    │  (Core/Business)    │
    └─────────────────────┘
```

---

## 🚀 Getting Started

### Prerequisites

- .NET 9.0 SDK or later
- SQL Server (Express or Full)
- Node.js 18+ and npm
- Visual Studio Code or Visual Studio 2022+

### Backend Setup

```bash
# Navigate to root
cd ems-dotnet-react

# Restore NuGet packages
dotnet restore

# Build solution
dotnet build

# Run API (starts on http://localhost:5000)
dotnet run --project EmpMgmtSystem.API
```

### Frontend Setup

```bash
cd EmpMgmtSystem.UI

# Install dependencies
npm install

# Run development server (starts on http://localhost:5173)
npm run dev

# During development we can use
dotnet watch run # Hot reload enabled(Changes will reflect without restarting the application). Cltr + R to restart
```

### Database Setup

---

## 📝 License

This project is licensed under the MIT License - see [LICENSE](./LICENSE) file for details.

---

## 👨‍💻 Contributing

Contributions are welcome! Please follow the Clean Architecture principles and ensure all tests pass before submitting a pull request.
