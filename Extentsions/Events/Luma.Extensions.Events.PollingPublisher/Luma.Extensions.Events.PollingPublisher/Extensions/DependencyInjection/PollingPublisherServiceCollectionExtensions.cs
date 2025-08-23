using Luma.Extensions.Events.PollingPublisher.Options;
using Luma.Extensions.Events.PollingPublisher;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Luma.Extensions.DependencyInjection;


public static class PollingPublisherServiceCollectionExtensions
{
    public static IServiceCollection AddLumaPollingPublisher(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PollingPublisherOptions>(configuration);
        AddServices(services);
        return services;
    }

    public static IServiceCollection AddLumaPollingPublisher(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddLumaPollingPublisher(configuration.GetSection(sectionName));
        return services;
    }

    public static IServiceCollection AddLumaPollingPublisher(this IServiceCollection services, Action<PollingPublisherOptions> setupAction)
    {
        services.Configure(setupAction);
        AddServices(services);
        return services;
    }



    private static void AddServices(IServiceCollection services)
    {
        services.AddHostedService<PoolingPublisherBackgroundService>();
    }

}
