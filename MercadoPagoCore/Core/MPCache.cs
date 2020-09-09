using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Cache;

namespace MercadoPago
{
    /// <summary>
    /// Class for managing cached resources.
    /// </summary>
    public class MPCache
    {
        public static void AddToCache(string key, MPAPIResponse response)
        {
            try
            {
                // HttpRuntime.Cache.Add(key, (object) response, (CacheDependency) null, DateTime.MaxValue, new TimeSpan(0, 1, 0), CacheItemPriority.Normal, (CacheItemRemovedCallback) null);
                CacheItemDictionary<string, object> cache = new CacheItemDictionary<string, object>();
                cache.Add(key, (object)response);
            }
            catch (Exception ex)
            {
                throw new MPException("An error has occured in the cache structure (ADD): " + ex.Message);
            }
        }

        public static MPAPIResponse GetFromCache(string key)
        {
            object value;
            try
            {
                //return (MPAPIResponse) HttpRuntime.Cache.Get(key);
                CacheItemDictionary<string, object> cache = new CacheItemDictionary<string, object>();
                if (cache.TryGetValue(key, out value))
                {
                    return (MPAPIResponse)value;
                }
                else
                {
                    throw new MPException("An error has occured in the cache structure (GET)");
                }

            }
            catch (Exception ex)
            {
                throw new MPException("An error has occured in the cache structure (GET): " + ex.Message);
            }
        }

        public static void RemoveFromCache(string key)
        {
            try
            {
                CacheItemDictionary<string, object> cache = new CacheItemDictionary<string, object>();
                cache.Remove(key);
            }
            catch (Exception ex)
            {
                throw new MPException("An error has occured in the cache structure (REMOVE): " + ex.Message);
            }
        }
    }
}
