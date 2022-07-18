using Microsoft.Extensions.DependencyInjection;
using Scorpion.Extensions.Caching.Abstractions;
using Scorpion.Extensions.Caching.InMemory.Services;

namespace Scorpion.Extensions.Caching.InMemory.Extensions.DependencyInjection
{
    public static class InMemoryCachingServiceCollectionExtensions
    {
        public static IServiceCollection AddScorpionInMemoryCaching(this IServiceCollection services)
            => services.AddMemoryCache().AddTransient<ICacheAdapter, InMemoryCacheAdapter>();
    }
}
