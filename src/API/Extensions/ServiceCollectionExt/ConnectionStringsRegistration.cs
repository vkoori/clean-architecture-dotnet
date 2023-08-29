namespace API.Extensions.ServiceCollectionExt;

using Microsoft.EntityFrameworkCore;
using Application.Exceptions.RuntimeExceptions;
using Infrastructure.Persistance.EFCore;
using Infrastructure.Caching.Redis;

public static class ConnectionStringsRegistration
{
    public static void AddConnectionStrings(this IServiceCollection services, IConfigurationRoot config)
    {
        string? mySqlConnectionString = config.GetConnectionString("MySql");
        string? redisConnectionString = config.GetConnectionString("Redis");

        if (mySqlConnectionString == null || redisConnectionString == null)
        {
            throw new ConnectionStringException();
        }

        // Mysql
        services.AddEFCoreMarketingDbContext(mySqlConnectionString);
        services.AddEFCoreCoreDbContext(mySqlConnectionString);
        // Redis
        services.AddRedis(redisConnectionString);
    }
}
