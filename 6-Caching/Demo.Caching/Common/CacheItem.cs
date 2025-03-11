using Microsoft.Extensions.Caching.Memory;
using Demo.Core.Utilities.Extensions;

namespace Demo.Caching.Common
{
    internal class CacheItem
    {
        public static MemoryCacheEntryOptions CacheOption()
        {
            MemoryCacheEntryOptions options = new()
            {
                AbsoluteExpiration = DateTime.UtcNow.GetDateTimeNow().AddDays(1)
            };
            return options;
        }
    }
}
