using Domain.Contracts;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CacheService(ICacheReposity cacheReposity) : ICacheService
    {
        public async Task<string?> GetCacheValueAsync(string key)
        {
            var value = await cacheReposity.GetAsync(key);
            return value == null ? null : value;
        }

        public async Task SetCacheValueAsync(string key, object value, TimeSpan duration)
        {
            await cacheReposity.SetAsync(key, value, duration);
        }
    }
}
