using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Caching;
using System.Text;

namespace WebApiIncapacidades.Implementaciones
{
    public class CachePolicy
    {
        public static IMemoryCache InitMemoryCache(IMemoryCache cache)
        {

            string c = Directory.GetCurrentDirectory();
            IConfiguration _configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();

            CacheItemPolicy policy = new CacheItemPolicy
            {
                SlidingExpiration = TimeSpan.FromSeconds(Double.Parse(_configuration.GetSection("Settings:SetSlidingExpiration").Value)),
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(Double.Parse(_configuration.GetSection("Settings:SetAbsoluteExpiration").Value))
            };

            cache.Set(new CacheItem("item", new { }), policy);
            return cache;
        }
    }
}
