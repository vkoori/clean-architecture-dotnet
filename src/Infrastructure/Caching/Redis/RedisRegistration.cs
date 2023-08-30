namespace Infrastructure.Caching.Redis;

using Application.Caching.InterFaces;
using Microsoft.Extensions.DependencyInjection;

public static class RedisRegistration
{
    public static void AddRedis(this IServiceCollection services, string redisConnectionString)
    {
        services.AddSingleton<ICacheProvider>(sp => new RedisCacheProvider(redisConnectionString));
    }
}
