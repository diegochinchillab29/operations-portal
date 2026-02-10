# OpsPortal API

A RESTful API for managing operational services, deployments, incidents, vulnerabilities, and documentation. Built with ASP.NET Core and Entity Framework Core.

## Table of Contents

- [Overview](#overview)
- [Technologies](#technologies)
- [Project Structure](#project-structure)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Configuration](#configuration)
- [API Endpoints](#api-endpoints)
- [Database](#database)
- [License](#license)

## Overview

OpsPortal API provides a centralized backend for operations management, enabling teams to:

- Track and manage services and their ownership
- Monitor deployments across environments
- Report and track incidents
- Document vulnerabilities
- Maintain service documentation

## Technologies

| Technology | Version |
|------------|---------|
| .NET | 10.0 |
| ASP.NET Core | 10.0 |
| Entity Framework Core | 10.0.2 |
| SQL Server | Latest |
| Swagger/OpenAPI | Integrated |

## Project Structure

```
OpsPortal.API/
├── Controllers/          # API endpoints
│   └── ServicesController.cs
├── Data/                 # Database context
│   └── OpsPortalContext.cs
├── Models/               # Domain entities
│   ├── Deployment.cs
│   ├── Documentation.cs
│   ├── Environment.cs
│   ├── Incident.cs
│   ├── Service.cs
│   └── Vulnerability.cs
├── Properties/           # Launch settings
│   └── launchSettings.json
├── Services/             # Business logic layer
│   ├── IOpsDataService.cs
│   └── OpsDataService.cs
├── appsettings.json      # Application configuration
├── appsettings.Development.json
├── OpsPortal.API.csproj  # Project file
├── OpsPortal.sln         # Solution file
└── Program.cs            # Application entry point
```

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server) (LocalDB, Express, or full edition)
- IDE of choice (Visual Studio 2022, VS Code, or Rider)

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/diegochinchillab29/operations-portal.git
cd operations-portal/OpsPortal.API
```

### 2. Configure the Database Connection

Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=OpsPortalDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

### 3. Apply Database Migrations

```bash
dotnet ef database update
```

### 4. Run the Application

```bash
dotnet run
```

The API will be available at:
- HTTPS: `https://localhost:5001`
- HTTP: `http://localhost:5000`

### 5. Access Swagger UI

Navigate to `https://localhost:5001/swagger` to explore the API documentation.

## Configuration

### Environment Variables

| Variable | Description | Default |
|----------|-------------|---------|
| `ASPNETCORE_ENVIRONMENT` | Runtime environment | `Development` |
| `ConnectionStrings__DefaultConnection` | Database connection string | - |

### CORS Configuration

The API is configured to allow requests from `http://localhost:3000` for frontend development. Modify the CORS policy in `Program.cs` for production deployments.

## API Endpoints

### Services

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/services` | Retrieve all services |
| GET | `/api/services/{id}` | Retrieve a specific service |
| POST | `/api/services` | Create a new service |
| POST | `/api/services/{serviceId}/incidents` | Report an incident for a service |

### Request/Response Examples

#### Create a Service

```http
POST /api/services
Content-Type: application/json

{
  "name": "Payment Gateway",
  "ownerTeam": "Platform Team",
  "repoUrl": "https://github.com/org/payment-gateway"
}
```

#### Response

```json
{
  "id": 1,
  "name": "Payment Gateway",
  "ownerTeam": "Platform Team",
  "repoUrl": "https://github.com/org/payment-gateway",
  "deployments": [],
  "incidents": [],
  "vulnerabilities": [],
  "docs": []
}
```

## Database

### Entity Relationships

- **Service**: Core entity representing a managed service
  - Has many Deployments
  - Has many Incidents
  - Has many Vulnerabilities
  - Has many Documentation entries

### Running Migrations

```bash
# Add a new migration
dotnet ef migrations add <MigrationName>

# Apply migrations
dotnet ef database update

# Remove last migration
dotnet ef migrations remove
```

## Development

### Building the Project

```bash
dotnet build OpsPortal.API.csproj
```

### Running Tests

```bash
dotnet test
```

### Next Steps
- Add unit and integration tests for controllers and services.
- Implement logging and monitoring for better observability.
- Implement additional endpoints for deployments, incidents, vulnerabilities, and documentation.
- Add authentication and authorization for secure access.
- Integrate with CI/CD pipelines for automated testing and deployment.

### Code Style

This project follows standard .NET coding conventions and uses nullable reference types.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
