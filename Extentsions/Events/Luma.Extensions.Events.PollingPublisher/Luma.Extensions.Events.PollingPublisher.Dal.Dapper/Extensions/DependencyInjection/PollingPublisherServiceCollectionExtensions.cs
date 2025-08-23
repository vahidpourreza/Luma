using Luma.Extensions.Events.Abstractions;
using Luma.Extensions.Events.PollingPublisher.Dal.Dapper.DataAccess;
using Luma.Extensions.Events.PollingPublisher.Dal.Dapper.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Luma.Extensions.DependencyInjection;
public static class PollingPublisherServiceCollectionExtensions
{


    public static IServiceCollection AddLumaPollingPublisherDalSql(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PollingPublisherDalRedisOptions>(configuration);
        AddServices(services);
        return services;
    }

    public static IServiceCollection AddLumaPollingPublisherDalSql(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddLumaPollingPublisherDalSql(configuration.GetSection(sectionName));
        return services;
    }

    public static IServiceCollection AddLumaPollingPublisherDalSql(this IServiceCollection services, Action<PollingPublisherDalRedisOptions> setupAction)
    {
        services.Configure(setupAction);
        AddServices(services);
        return services;
    }



    private static void AddServices(IServiceCollection services)
    {
        services.AddSingleton<IOutBoxEventItemRepository, SqlOutBoxEventItemRepository>();
    }

}
