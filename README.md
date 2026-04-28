# auth-api

A lightweight **ASP.NET Core** authentication API example written in C#.
Target framework: **.NET 10**
## 📦 Project structure
```
/auth-api
│   README.md               # 📖 This file
│   Program.cs              # 🏁 Application entry point
│   appsettings.json        # ⚙️ Configuration
│
├─ Dtos
│   ├─ Auth
│   │   ├─ Requests
│   │   │   ├─ Login_Request.cs
│   │   │   └─ Register_Request.cs
│   │   └─ Responses
│   │       ├─ Login_Response.cs
│   │       └─ Register_Response.cs
│   └─ Common
│       └─ BaseResponse.cs   # 📦 Generic response wrapper
│
├─ Features
│   └─ Auth
│       └─ AuthEndpoints.cs # 🌐 API endpoints (login, register)
│
├─ Services
│   └─ Auth
│       ├─ IAuthService.cs
│       └─ AuthService.cs   # 🛠️ Business logic
│
├─ Utils
│   └─ Security
│       └─ ValidationHelper.cs  # ✅ Validation helpers (email, phone)
│
└─ Extensions
    ├─ ServiceCollectionExtensions.cs
    └─ EndpointRouteBuilderExtensions.cs
```

## 🚀 Getting started
1. **Prerequisites**
   - .NET 10 SDK (or newer, the project targets .NET 10)
   - A SQL Server instance if you plan to add persistence
2. **Clone the repo**
   ```bash
   git clone <repo‑url>
   cd auth-api
   ```
3. **Restore packages & build**
   ```bash
   dotnet restore
   dotnet build
   ```
4. **Run locally**
   ```bash
   dotnet run
   ```
   The API will be available at `http://localhost:5000` (or the port shown in the console).

## 📡 API endpoints
| Method | Route   | Request DTO                     | Response DTO (wrapped)                     |
|--------|---------|--------------------------------|--------------------------------------------|
| POST   | `/login`    | `Login_Request`                | `BaseResponse<Login_Response>`               |
| POST   | `/register` | `Register_Request`             | `BaseResponse<Register_Response>`            |

All responses follow the **BaseResponse<T>** format:
```json
{
  "status": 0,
  "message": "Thành công",
  "data": { ... }   // null when no payload
}
```
- `status`: `0` = success, non‑zero = error code.
- `message`: Human‑readable description.
- `data`: Generic payload of type `T`. Use `null` (or omit) when there is no data.

## 🛡️ ValidationHelper (utils/security)
The `ValidationHelper` class provides static helpers for:
- **Email** validation (`IsValidEmail`).
- **Vietnam phone** validation (`IsValidVietnamPhone`).
- **Phone normalization** (`NormalizeVietnamPhone`).

## 🧩 Extensibility
- Add new DTOs under `Dtos/…` and expose them via endpoints in `Features/…`.
- Register additional services in `Extensions/ServiceCollectionExtensions.cs` and map routes in `Extensions/EndpointRouteBuilderExtensions.cs`.

---
*This README is a quick‑start guide; feel free to expand it with detailed documentation, testing instructions, and deployment steps.*