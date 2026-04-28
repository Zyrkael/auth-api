using auth_api.Configurations;
using auth_api.Contexts;
using Microsoft.EntityFrameworkCore;

namespace auth_api.Extensions;

public static class DatabaseExtensions
{
    public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(AppConstants.ConnectionStrings.DefaultConnection);
        var dbProvider = configuration.GetSection(AppConstants.ConnectionStrings.SectionName)[AppConstants.ConnectionStrings.DbProvider];

        services.AddDbContext<AppDbContext>(options =>
        {
            if (dbProvider?.Equals(AppConstants.DbProviders.MySql, StringComparison.OrdinalIgnoreCase) == true)
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
            else
            {
                options.UseSqlServer(connectionString);
            }
        });
        
        services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<AppDbContext>());
    }
}
