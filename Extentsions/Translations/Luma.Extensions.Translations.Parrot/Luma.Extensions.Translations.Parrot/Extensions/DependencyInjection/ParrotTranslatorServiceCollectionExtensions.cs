using Luma.Extensions.Translations.Abstractions;
using Luma.Extensions.Translations.Parrot.Options;
using Luma.Extensions.Translations.Parrot.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Luma.Extensions.DependencyInjection;

public static class ParrotTranslatorServiceCollectionExtensions
{
    public static IServiceCollection AddLumaParrotTranslator(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ITranslator, ParrotTranslator>();
        services.Configure<ParrotTranslatorOptions>(configuration);
        return services;
    }

    public static IServiceCollection AddLumaParrotTranslator(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddLumaParrotTranslator(configuration.GetSection(sectionName));
        return services;
    }

    public static IServiceCollection AddLumaParrotTranslator(this IServiceCollection services, Action<ParrotTranslatorOptions> setupAction)
    {
        services.AddSingleton<ITranslator, ParrotTranslator>();
        services.Configure(setupAction);
        return services;
    }
}
