# 🔐 Auth API (.NET 9)

Một API xác thực tinh gọn, hiệu quả sử dụng ASP.NET Core, được thiết kế để làm nền tảng cho các dự án Backend hiện đại.

## 🚀 Tính năng chính
- **Xác thực JWT**: Đăng nhập và nhận Token bảo mật.
- **Đăng ký**: Tạo tài khoản người dùng mới.
- **Hỗ trợ Đa Cơ sở dữ liệu**: Dễ dàng chuyển đổi giữa **SQL Server** và **MySQL** (Laragon) qua cấu hình.
- **Tài liệu API**: Tích hợp **Scalar** với font **JetBrains Mono** hiện đại tại `/docs`.
- **Cấu trúc Clean**: Code được tách bạch rõ ràng (Extensions, Features, Services).

## 🛠️ Công nghệ sử dụng
- **Framework**: .NET 9 (ASP.NET Core)
- **API Documentation**: OpenAPI + Scalar (JetBrains Mono font)
- **Database**: EF Core (SQL Server & Pomelo MySQL)
- **Security**: BCrypt.Net-Next

## 🚦 Cấu hình Cơ sở dữ liệu
Trong file `appsettings.Development.json`, bạn có thể chọn Provider:
```json
"ConnectionStrings": {
  "SqlServerConnection": "...",
  "MySqlConnection": "...",
  "DbProvider": "SqlServer" // Hoặc "MySql"
}
```

## 🏁 Bắt đầu nhanh
1. **Clone dự án**:
   ```bash
   git clone <repo-url>
   cd auth-api
   ```
2. **Chạy ứng dụng**:
   ```bash
   dotnet run --project auth-api
   ```
3. **Truy cập tài liệu**:
   Mở trình duyệt tại: `http://localhost:5184/docs`

---
*Phát triển bởi Zyrkael*