using Luma.Extensions.ChangeDataLog.Hamster.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Luma.Extensions.DependencyInjection;

public static class changeeDatalogServiceCollectionExtensions
{
    public static IServiceCollection AddLumaHamsterChangeDatalog(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ChangeDataLogHamsterOptions>(configuration);
        return services;
    }

    public static IServiceCollection AddLumaHamsterChangeDatalog(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddLumaHamsterChangeDatalog(configuration.GetSection(sectionName));
        return services;
    }

    public static IServiceCollection AddLumaHamsterChangeDatalog(this IServiceCollection services, Action<ChangeDataLogHamsterOptions> setupAction)
    {
        services.Configure(setupAction);
        return services;
    }
}
