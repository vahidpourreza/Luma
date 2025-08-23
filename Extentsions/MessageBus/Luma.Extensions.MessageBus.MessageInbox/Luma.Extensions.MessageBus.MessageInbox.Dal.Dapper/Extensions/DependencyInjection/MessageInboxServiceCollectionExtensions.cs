using Luma.Extensions.MessageBus.Abstractions;
using Luma.Extensions.MessageBus.MessageInbox.Dal.Dapper.Options;
using Luma.Extensions.MessageBus.MessageInbox.Dal.Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Luma.Extensions.DependencyInjection;

public static class MessageInboxServiceCollectionExtensions
{

    public static IServiceCollection AddLumaMessageInboxDalSql(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MessageInboxDalDapperOptions>(configuration);
        AddServices(services);
        return services;
    }

    public static IServiceCollection AddLumaMessageInboxDalSql(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddLumaMessageInboxDalSql(configuration.GetSection(sectionName));
        return services;
    }

    public static IServiceCollection AddLumaMessageInboxDalSql(this IServiceCollection services, Action<MessageInboxDalDapperOptions> setupAction)
    {
        services.Configure(setupAction);
        AddServices(services);
        return services;
    }



    private static void AddServices(IServiceCollection services)
    {
        services.AddSingleton<IMessageInboxItemRepository, SqlMessageInboxItemRepository>();
    }


}
