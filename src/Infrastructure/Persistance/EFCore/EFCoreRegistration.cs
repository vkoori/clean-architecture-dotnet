namespace Infrastructure.Persistance.EFCore;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class EFCoreRegistration
{
    public static void AddEFCoreMarketingDbContext(this IServiceCollection services, string connectionString, int timeout = 30)
    {
        services.AddDbContext<MarketingDbContext>(options =>
        {
            options
                .UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    options =>
                    {
                        // options.EnableRetryOnFailure();
                        options.CommandTimeout(timeout);
                    }
                ).UseSnakeCaseNamingConvention();
        });
    }

    public static void AddEFCoreCoreDbContext(this IServiceCollection services, string connectionString, int timeout = 30)
    {
        services.AddDbContext<CoreDbContext>(options =>
        {
            options
                .UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    options =>
                    {
                        // options.EnableRetryOnFailure();
                        options.CommandTimeout(timeout);
                    }
                ).UseSnakeCaseNamingConvention();
        });
    }
}
