using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Service.Financeiro.ConsolidadoDiario.Persistence.Cache
{
    public class RedisService : IRedisService
    {
        private readonly IDatabase _redisDb;

        public RedisService(IConfiguration configuration)
        {
            ConfigurationOptions conf = new ConfigurationOptions
            {
                EndPoints = { configuration["CacheConnection:Url"] },
                User = configuration["CacheConnection:User"],
                Password = configuration["CacheConnection:Password"]
            };

            _redisDb = ConnectionMultiplexer.Connect(conf).GetDatabase();
        }

        public async Task<bool> SetDataAsync<T>(string key, T model, TimeSpan time)
        {
            var obj = JsonConvert.SerializeObject(model);

            await _redisDb.KeyDeleteAsync(key);

            return await _redisDb.StringSetAsync(key, obj, time, When.NotExists);
        }

        public async Task<T> GetDataAsync<T>(string key)
        {
            var model = await _redisDb.StringGetAsync(key);

            try
            {
                return JsonConvert.DeserializeObject<T>(model);
            }

            catch
            {
                return default;
            }

            return default;
        }

        public async Task DeleteDataAsync(string key)
        {
            await _redisDb.KeyDeleteAsync(key);
        }
    }
}
