﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace GridMvcPOC.Util
{
    public sealed class CacheProvider
    {
        private ObjectCache Cache { get { return MemoryCache.Default; } }

        private static CacheProvider instance = null;

        private CacheProvider()
        {
        }

        public static CacheProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CacheProvider();
                }
                return instance;
            }
        }

        public object Get(string key)
        {
            return Cache[key];
        }

        public void Set(string key, object data, int cacheTime)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);

            Cache.Add(new CacheItem(key, data), policy);
        }

        public bool IsSet(string key)
        {
            return (Cache[key] != null);
        }

        public void Invalidate(string key)
        {
            Cache.Remove(key);
        }
    }
}