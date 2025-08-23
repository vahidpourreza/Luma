using Luma.Extensions.MessageBus.Abstractions;
using Luma.Extensions.MessageBus.MessageInbox.Options;
using Luma.Extensions.MessageBus.MessageInbox;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Luma.Extensions.DependencyInjection;

public static class MessageInboxServiceCollectionExtensions
{
    public static IServiceCollection AddLumaMessageInbox(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MessageInboxOptions>(configuration);
        AddServices(services);
        return services;
    }

    public static IServiceCollection AddLumaMessageInbox(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddLumaMessageInbox(configuration.GetSection(sectionName));
        return services;
    }

    public static IServiceCollection AddLumaMessageInbox(this IServiceCollection services, Action<MessageInboxOptions> setupAction)
    {
        services.Configure(setupAction);
        AddServices(services);
        return services;
    }



    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IMessageConsumer, InboxMessageConsumer>();
    }


}


