using System;
using System.Runtime.Caching;

namespace RegisterUser.ClassLibrary
{
    public class CacheManager
    {
        public static void AddItem(string key, object item)
        {
            var expiration = 1;

            var policy = new CacheItemPolicy
            {
                Priority = CacheItemPriority.NotRemovable,
                AbsoluteExpiration = DateTimeOffset.Now.AddHours(expiration)
            };

            MemoryCache.Default.Set(key, item, policy);
        }

        public static object GetCachedItem(string key)
        {
            return MemoryCache.Default[key];
        }
    }

    public class CacheManager<TEntity> : CacheManager where TEntity : class
    {
        public static void AddItem(string key, TEntity item)
        {
            var expiration = 1;

            var policy = new CacheItemPolicy
            {
                Priority = CacheItemPriority.NotRemovable,
                AbsoluteExpiration = DateTimeOffset.Now.AddHours(expiration)
            };

            MemoryCache.Default.Set(key, item, policy);
        }

        public static TEntity GetCachedItem(string key)
        {
            return MemoryCache.Default[key] as TEntity;
        }
    }
}