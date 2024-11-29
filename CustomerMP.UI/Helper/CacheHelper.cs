using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using System;

namespace CustomerMP.UI.Helper
{
    public class CacheHelper
    {
        private readonly IMemoryCache _cache;

        public CacheHelper(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<T> GetOrCreateAsync<T>(string cacheKey, Func<Task<T>> fetchFunction, TimeSpan? slidingExpiration = null)
        {
            if (!_cache.TryGetValue(cacheKey, out T cacheEntry))
            {
                cacheEntry = await fetchFunction();
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(slidingExpiration ?? TimeSpan.FromMinutes(10));
                _cache.Set(cacheKey, cacheEntry, cacheOptions);
            }
            return cacheEntry;
        }

        public void Remove(string cacheKey)
        {
            _cache.Remove(cacheKey);
        }
    }
}
