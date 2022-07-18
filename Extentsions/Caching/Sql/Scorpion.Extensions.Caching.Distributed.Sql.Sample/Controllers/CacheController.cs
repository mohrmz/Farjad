﻿using Microsoft.AspNetCore.Mvc;
using Scorpion.Extensions.Caching.Abstractions;

namespace Scorpion.Extensions.Caching.Distributed.Sql.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly ICacheAdapter _cacheAdapter;
        public CacheController(ICacheAdapter cacheAdapter)
        {
            _cacheAdapter = cacheAdapter;
        }


        [HttpPost]
        public IActionResult Add(string Key, string Value)
        {
            _cacheAdapter.Add(Key, Value, DateTime.Now.AddDays(1), null);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get(string Key)
        {
            return Ok(_cacheAdapter.Get<string>(Key));
        }

        [HttpDelete]
        public IActionResult Delete(string Key)
        {
            _cacheAdapter.RemoveCache(Key);
            return Ok();
        }
    }
}
