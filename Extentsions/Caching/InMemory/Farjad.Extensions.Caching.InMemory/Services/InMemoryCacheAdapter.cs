﻿using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Farjad.Extensions.Caching.Abstractions;
using Farjad.Extensions.Serializers.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farjad.Extensions.Caching.InMemory.Services
{
    public class InMemoryCacheAdapter : ICacheAdapter
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly ILogger<InMemoryCacheAdapter> _logger;

        public InMemoryCacheAdapter(IMemoryCache memoryCache,
                                    IJsonSerializer jsonSerializer,
                                    ILogger<InMemoryCacheAdapter> logger)
        {
            _memoryCache = memoryCache;
            _jsonSerializer = jsonSerializer;
            _logger = logger;
            _logger.LogInformation("InMemoryCache Adapter Start working");
        }

        public void Add<TInput>(string key, TInput obj, DateTime? absoluteExpiration, TimeSpan? slidingExpiration)
        {
            _logger.LogTrace("InMemoryCache Adapter Cache {obj} with key : {key} " +
                             ", with data : {data} " +
                             ", with absoluteExpiration : {absoluteExpiration} " +
                             ", with slidingExpiration : {slidingExpiration}",
                             typeof(TInput),
                             key,
                             _jsonSerializer.Serialize(obj),
                             absoluteExpiration.ToString(),
                             slidingExpiration.ToString());

            _memoryCache.Set(key, obj);
        }

        public TOutput Get<TOutput>(string key)
        {
            _logger.LogTrace("InMemoryCache Adapter Try Get Cache with key : {key}", key);

            var result = _memoryCache.TryGetValue(key, out TOutput resultObject);

            if (result)
                _logger.LogTrace("InMemoryCache Adapter Successful Get Cache with key : {key} and data : {data}",
                                 key,
                                 _jsonSerializer.Serialize(resultObject));
            else
                _logger.LogTrace("InMemoryCache Adapter Failed Get Cache with key : {key}", key);

            return resultObject;
        }

        public void RemoveCache(string key)
        {
            _logger.LogTrace("InMemoryCache Adapter Remove Cache with key : {key}", key);

            _memoryCache.Remove(key);
        }
    }
}