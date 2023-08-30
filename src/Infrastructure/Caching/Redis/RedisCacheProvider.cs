namespace Infrastructure.Caching.Redis;

using Application.Caching.InterFaces;
using Newtonsoft.Json;
using StackExchange.Redis;

public class RedisCacheProvider : ICacheProvider
{
    private readonly IDatabase _database;

    public RedisCacheProvider(string connectionString)
    {
        var connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
        _database = connectionMultiplexer.GetDatabase();
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var serializedValue = await _database.StringGetAsync(key);
        return Deserialize<T>(serializedValue);
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
    {
        var serializedValue = Serialize(value);
        await _database.StringSetAsync(key, serializedValue, expiration);
    }

    public async Task<bool> RemoveAsync(string key)
    {
        return await _database.KeyDeleteAsync(key);
    }

    public async Task<bool> ExistsAsync(string key)
    {
        return await _database.KeyExistsAsync(key);
    }

    private static T? Deserialize<T>(RedisValue serializedValue)
    {
        if (!serializedValue.IsNull)
        {
            return JsonConvert.DeserializeObject<T>(serializedValue!);
        }
        return default;
    }

    private static RedisValue Serialize<T>(T value)
    {
        return JsonConvert.SerializeObject(value);
    }

}
