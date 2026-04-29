# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Quick Start

```bash
dotnet run --project auth-api
```

API docs available at `http://localhost:5184/docs` (Scalar with JetBrains Mono font).

## Database

- **Provider**: Configurable via `appsettings.Development.json` (`DbProvider`: "SqlServer" or "MySql")
- **Migrations**: Use `dotnet ef` commands in the `auth-api` directory
- **Context**: `AppDbContext` implements `IAppDbContext` for testability

## Architecture

**Layered structure:**

- **Entities** (`Entities/`): Domain models (`User`, `BaseEntity`)
- **Dtos** (`Dtos/`): Request/Response objects for API contracts
- **Services** (`Services/`): Business logic (`IAuthService`, `AuthService`)
- **Features** (`Features/`): Endpoint definitions (`AuthEndpoints`)
- **Extensions** (`Extensions/`): DI setup, middleware, database configuration
- **Contexts** (`Contexts/`): Database context interfaces and implementations
- **Configurations** (`Configurations/`): Entity configurations, constants
- **Utils** (`Utils/`): Shared helpers (`PasswordHelper`, `ValidationHelper`)

## Key Patterns

- **Clean separation**: Endpoints map to services; services use DbContext directly
- **Password hashing**: BCrypt with work factor 11 (`PasswordHelper`)
- **Validation**: `ValidationHelper` for email and Vietnamese phone numbers
- **Response format**: `BaseResponse<T>` wraps all API responses with status, message, data
- **OpenAPI**: Scalar documentation with Deep Space theme and JetBrains Mono font

## Common Commands

| Task | Command |
|------|---------|
| Run app | `dotnet run --project auth-api` |
| Add migration | `dotnet ef migrations add <Name> --project auth-api` |
| Update database | `dotnet ef database update --project auth-api` |
| Remove migration | `dotnet ef migrations remove --project auth-api` |

## Current State

- **Register endpoint**: Fully implemented (email validation, duplicate check, password hashing)
- **Login endpoint**: Placeholder - returns dummy token (needs JWT implementation)
