using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using auth_api.Contexts;
using auth_api.Services.Auth;

namespace auth_api.Extensions;

public static class ServiceCollectionExtensions
{
    // Register application services (e.g., Auth)
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }

    // Register database context and related abstractions
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<AppDbContext>());
        return services;
    }
}
