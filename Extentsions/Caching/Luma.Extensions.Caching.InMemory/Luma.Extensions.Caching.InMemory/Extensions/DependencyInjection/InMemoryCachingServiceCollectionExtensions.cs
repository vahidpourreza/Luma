using Luma.Extensions.Caching.Abstractions;
using Luma.Extensions.Caching.InMemory.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Luma.Extensions.DependencyInjection;

public static class InMemoryCachingServiceCollectionExtensions
{
    public static IServiceCollection AddLumaInMemoryCaching(this IServiceCollection services)
                     => services
                      .AddMemoryCache()
                      .AddTransient<ICacheAdapter, InMemoryCacheAdapter>();
}
