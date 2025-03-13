using HealthSync.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HealthSync.API.Configurations;

public static class DatabaseConfig
{
    public static void AddCustomDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("HealthSyncDB");

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString, sqlServerOptions =>
            {
                var assembly = typeof(ApplicationDbContext).Assembly;
                var assemblyName = assembly.GetName();

                sqlServerOptions.MigrationsAssembly(assemblyName.Name);
                sqlServerOptions.EnableRetryOnFailure(
                                 maxRetryCount: 2,
                                 maxRetryDelay: TimeSpan.FromSeconds(30),
                                 errorNumbersToAdd: null);
            });
        });
    }
}
