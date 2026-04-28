using Scalar.AspNetCore;

namespace auth_api.Extensions;

public static class OpenApiExtensions
{
    public static void AddOpenApiDocumentation(this IServiceCollection services)
    {
        services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, context, cancellationToken) =>
            {
                document.Info.Title = "API Xác thực (Authentication API)";
                document.Info.Version = "v1";
                document.Info.Description = "API cho việc xác thực và phân quyền người dùng sử dụng JWT tokens. Bao gồm các điểm cuối cho đăng nhập và đăng ký.";
                return Task.CompletedTask;
            });
        });
        services.AddEndpointsApiExplorer();
    }

    public static void UseOpenApiDocumentation(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference("/docs", options =>
            {
                options.Title = "Auth API v1 🚀";
                options.Layout = ScalarLayout.Modern;
                options.Theme = ScalarTheme.DeepSpace;

                options.DisableDefaultFonts();
                options.CustomCss = @"
                    @import url('https://fonts.googleapis.com/css2?family=JetBrains+Mono:ital,wght@0,100..800;1,100..800&display=swap');
                    :root {
                        --scalar-font: 'JetBrains Mono', monospace;
                    }
                    code, kbd, samp, pre {
                        font-family: 'JetBrains Mono', monospace !important;
                    }
                ";
                
                options.HideClientButton = false;
            });
        }
    }
}
