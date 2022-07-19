using Microsoft.Extensions.DependencyInjection;
using Farjad.Extensions.Caching.Abstractions;
using Farjad.Extensions.Caching.InMemory.Services;

namespace Farjad.Extensions.Caching.InMemory.Extensions.DependencyInjection
{
    public static class InMemoryCachingServiceCollectionExtensions
    {
        public static IServiceCollection AddFarjadInMemoryCaching(this IServiceCollection services)
            => services.AddMemoryCache().AddTransient<ICacheAdapter, InMemoryCacheAdapter>();
    }
}
