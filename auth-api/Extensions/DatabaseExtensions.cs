using auth_api.Contexts;
using Microsoft.EntityFrameworkCore;

namespace auth_api.Extensions;

public static class DatabaseExtensions
{
    public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var dbProvider = configuration.GetSection("ConnectionStrings")["DbProvider"];

        services.AddDbContext<AppDbContext>(options =>
        {
            if (dbProvider?.Equals("MySql", StringComparison.OrdinalIgnoreCase) == true)
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
