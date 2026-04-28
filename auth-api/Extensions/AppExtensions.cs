using auth_api.Contexts;
using auth_api.Features.Auth;
using auth_api.Services.Auth;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace auth_api.Extensions;

public static class AppExtensions
{
    public static void AddInfrastructure(this WebApplicationBuilder builder)
    {
        // OpenAPI & Scalar Documentation
        builder.Services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, context, cancellationToken) =>
            {
                document.Info.Title = "API Xác thực (Authentication API)";
                document.Info.Version = "v1";
                document.Info.Description = "API cho việc xác thực và phân quyền người dùng sử dụng JWT tokens. Bao gồm các điểm cuối cho đăng nhập và đăng ký.";
                return Task.CompletedTask;
            });
        });
        builder.Services.AddEndpointsApiExplorer();

        // Database
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<AppDbContext>());

        // Services
        builder.Services.AddScoped<IAuthService, AuthService>();
    }

    public static void UseAppMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference("/docs", options =>
            {
                options.Title = "Auth Docs 🚀";
                options.Layout = ScalarLayout.Modern;
                options.Theme = ScalarTheme.DeepSpace;
            });
        }

        app.UseHttpsRedirection();
        app.MapAuthEndpoints();
    }
}
