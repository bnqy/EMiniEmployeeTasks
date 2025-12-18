# EMiniEmployeeTasks

**EMiniEmployeeTasks** is a **Mini Employee & Task Management System** built with **ASP.NET Core Web API (.NET 8)**.
The project demonstrates **clean layered architecture**, **Repository–Service pattern**, **Entity Framework Core**, **JWT authentication**, **validation**, **logging**, and **global exception handling**.

---

## Key Features

* Employee CRUD operations
* Task CRUD operations
* Get tasks by employee (`/employees/{id}/tasks`)
* JWT-based authentication
* Repository & Service layers with managers
* EF Core Code-First with migrations
* Global exception handling middleware
* Centralized logging (NLog)
* DTO-based validation
* Swagger (OpenAPI) with JWT support
* Seeded admin user for testing

---

## Solution Architecture

The solution follows a **strict layered architecture**:

```
API (Presentation)
 └── Controllers
      ↓
Service (Business Logic)
 └── Services + ServiceManager
      ↓
Repository (Data Access)
 └── Repositories + RepositoryManager
      ↓
Entities (Domain Models)
```

### Architectural Rules

* Controllers **never** access EF Core directly
* Repositories **never** contain business logic
* Services coordinate repositories and enforce rules
* DTOs isolate API from domain entities
* JWT logic lives in Service layer
* JWT validation happens in API layer

---

## Project Structure (Simplified)

```
EMiniEmployeeTasks.sln

├── EMiniEmployeeTasks                # API host (Program.cs, config, middleware)
│
├── EMiniEmployeeTasks.API.Presentation
│   └── Controllers
│       ├── AuthController.cs
│       ├── EmployeesController.cs
│       └── TasksController.cs
│
├── EMiniEmployeeTasks.Service
│   ├── AuthService.cs
│   ├── EmployeeService.cs
│   ├── TaskService.cs
│   ├── ServiceManager.cs
│   └── Security
│       └── PasswordHasher.cs
│
├── EMiniEmployeeTasks.Service.Contracts
│   ├── IAuthService.cs
│   ├── IEmployeeService.cs
│   ├── ITaskService.cs
│   └── IServiceManager.cs
│
├── EMiniEmployeeTasks.Repository
│   ├── RepositoryContext.cs
│   ├── RepositoryBase.cs
│   ├── RepositoryManager.cs
│   ├── EmployeeRepository.cs
│   ├── TaskRepository.cs
│   ├── UserRepository.cs
│   ├── Configuration
│   ├── Seed
│   │   └── UserSeeder.cs
│   └── Migrations
│
├── EMiniEmployeeTasks.Entities.Domain
│   ├── Models
│   │   ├── BaseEntity.cs
│   │   ├── Employee.cs
│   │   ├── TaskItem.cs
│   │   └── User.cs
│   └── Exceptions
│
├── EMiniEmployeeTasks.Shared
│   └── DTOs
│
├── Contracts.Interfaces
│   └── Repository & logger interfaces
│
└── LoggerService
    └── NLog implementation
```

---

## Technologies Used

* ASP.NET Core Web API (.NET 8)
* C#
* Entity Framework Core
* SQL Server
* JWT (JSON Web Tokens)
* AutoMapper
* NLog
* Swagger / OpenAPI
* Dependency Injection
* Data Annotations Validation

---

## Getting Started

### Prerequisites

* .NET SDK 8.0+
* SQL Server
* EF Core CLI (optional)

```bash
dotnet tool install --global dotnet-ef
```

---

### Run the Application
#### Open the Package Manager Console window and create first 
migration: 
```bash
PM> Add-Migration DBCreate
PM> Update-Database 
```

```bash
dotnet restore
dotnet ef database update
dotnet run
```

API at:

```
https://localhost:7285
http://localhost:5172
```

Swagger UI:

```
https://localhost:7285/swagger
```

---

## 🔐 Authentication (JWT)

### Login

```
POST /api/auth/login
```

**Request**

```json
{
  "username": "admin",
  "password": "admin123"
}
```

**Response**

```json
{
  "token": "<JWT_TOKEN>"
}
```

---

### Using the Token

Add this header to **all protected endpoints**:

```
Authorization: Bearer <JWT_TOKEN>
```

---

## 🔒 Protected Endpoints

All endpoints except `/api/auth/login` require authentication.

Protected via:

```csharp
[Authorize]
```

---

## 📚 API Endpoints

### Auth

| Method | Endpoint          | Description           |
| ------ | ----------------- | --------------------- |
| POST   | `/api/auth/login` | Login and receive JWT |

---

### Employees

| Method | Endpoint                    | Description        |
| ------ | --------------------------- | ------------------ |
| GET    | `/api/Employees`            | Get all employees  |
| GET    | `/api/Employees/{id}`       | Get employee by ID |
| POST   | `/api/Employees`            | Create employee    |
| PUT    | `/api/Employees/{id}`       | Update employee    |
| DELETE | `/api/Employees/{id}`       | Delete employee    |
| GET    | `/api/Employees/{id}/tasks` | Get employee tasks |

---

### Tasks

| Method | Endpoint          | Description    |
| ------ | ----------------- | -------------- |
| GET    | `/api/Tasks`      | Get all tasks  |
| GET    | `/api/Tasks/{id}` | Get task by ID |
| POST   | `/api/Tasks`      | Create task    |
| PUT    | `/api/Tasks/{id}` | Update task    |
| DELETE | `/api/Tasks/{id}` | Delete task    |

---

## Validation Rules

Validation is enforced using **DTOs** and **business rules**.

### Employee

* FirstName – required
* LastName – required
* Email – required, valid format

### Task

* Title – required
* EmployeeId – must exist

### Auth

* Username – required
* Password – required

---

## ❗ Global Error Handling

* Implemented via middleware
* No try/catch in controllers
* Custom domain exceptions (`EmployeeNotFoundException`, etc.)
* Safe, consistent error responses

**Example**

```json
{
  "statusCode": 404,
  "message": "Employee not found"
}
```

---

## Database & Migrations

* EF Core Code-First
* Migrations located in `EMiniEmployeeTasks.Repository`
* Includes:

  * Employees
  * Tasks
  * Users (for authentication)

### Apply migrations

```bash
dotnet ef database update

or

 PM> Update-Database
```
---

## Seeded User

An admin user is automatically seeded at startup:

```
Username: admin
Password: admin123
```

---

## Swagger & Testing

Swagger UI is configured with JWT support.

**Steps**

1. Call `/api/auth/login`
2. Copy token
3. Click **Authorize**
4. Paste `Bearer <token>`
5. Call protected endpoints