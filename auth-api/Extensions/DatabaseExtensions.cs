using auth_api.Configurations;
using auth_api.Contexts;
using Microsoft.EntityFrameworkCore;

namespace auth_api.Extensions;

public static class DatabaseExtensions
{
    public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        var dbProvider = configuration.GetSection(AppConstants.ConnectionStrings.SECTION_NAME)[AppConstants.ConnectionStrings.DB_PROVIDER];

        services.AddDbContext<AppDbContext>(options =>
        {
            if (dbProvider?.Equals(AppConstants.DbProviders.MY_SQL, StringComparison.OrdinalIgnoreCase) == true)
            {
                var connectionString = configuration.GetConnectionString(AppConstants.ConnectionStrings.MY_SQL_CONNECTION);
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
            else
            {
                var connectionString = configuration.GetConnectionString(AppConstants.ConnectionStrings.SQL_SERVER_CONNECTION);
                options.UseSqlServer(connectionString);
            }
        });
        
        services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<AppDbContext>());
    }
}
