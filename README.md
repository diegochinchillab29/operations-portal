# Operations Portal

A full-stack operations management platform for monitoring and managing services, deployments, incidents, vulnerabilities, and documentation.

## Projects

| Project | Description | Technologies |
|---------|-------------|--------------|
| [OpsPortal.API](OpsPortal.API/) | RESTful backend API | .NET 10, ASP.NET Core, EF Core, SQL Server |

## Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server) (LocalDB, Express, or full edition)

### Quick Start

```bash
# Clone the repository
git clone https://github.com/diegochinchillab29/operations-portal.git
cd operations-portal

# Run the API
cd OpsPortal.API
dotnet run
```

The API will be available at `https://localhost:5001` with Swagger documentation at `/swagger`.

## Repository Structure

```
operations-portal/
├── OpsPortal.API/        # Backend REST API
│   ├── Controllers/      # API endpoints
│   ├── Data/             # Database context
│   ├── Models/           # Domain entities
│   └── Services/         # Business logic
└── README.md             # This file
```

## Features

- **Service Management**: Track and manage operational services
- **Deployment Tracking**: Monitor deployments across environments
- **Incident Reporting**: Report and track service incidents
- **Vulnerability Management**: Document and track security vulnerabilities
- **Documentation**: Maintain service documentation

## License

This project is licensed under the MIT License.
