using Sirius.Core.Services.ReflectionService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sirius.Core.Cache
{
    public class MemoryCacheService : ICacheService
    {
        private const string _cacheKey = "ZaQwSx";
        private readonly IMemoryCache _memoryCache;
        private int _timeout;
        private readonly IAppLogger<MemoryCacheService> _logger;
        private readonly IReflectionService _reflecitonService;
        private Dictionary<string, string> _KeyList = new Dictionary<string, string>();
        private static object _lock = new object();


        public MemoryCacheService(IMemoryCache memoryCache
            , IAppLogger<MemoryCacheService> logger
            , IReflectionService reflecitonService)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
            _reflecitonService = reflecitonService; 
            _logger = logger;

        }

        public void Remove<T>()
        {
            var key = GetKey<T>();
            if (!_KeyList.ContainsKey(key))
                return;
            _memoryCache.Remove(key);
        }

        public string GetKey<T>()
        {
            var t = typeof(T);
            var key = string.Format("CI_{0}", t.Name);
            return key;
        }

        public List<T> GetOrAdd<T>(Func<List<T>> factory)
        {
            try
            {
                lock (_lock)
                {
                    var type = typeof(T);
                    var key = GetKey<T>();
                    var items = _memoryCache.Get<List<T>>(key);
                    if (items == null)
                    {

                        var cacheEntityAtt = _reflecitonService.GetCustomAttribute<CacheEntityAttribute>(type);
                        if (cacheEntityAtt == null)
                            throw new Exception($"This object not defined cache entity.Object type = {type.Name}");
                        if (cacheEntityAtt.TimeOut == 0)
                            _timeout = SiriusCore.Instance.AppConfig.GeneralSettings.MemoryCacheTimeout;
                        else
                            _timeout = cacheEntityAtt.TimeOut;
                        items = _memoryCache.Set(key, factory(), new DateTimeOffset(DateTime.Now.AddSeconds(_timeout)));
                    }
                    return _memoryCache.Get<List<T>>(key);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                throw new Exception(ex.GetaAllMessages());
            }
        }
    }
}
