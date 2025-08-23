using Luma.Utilities.ScalarRegistration.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;

namespace Luma.Extensions.DependencyInjection;

public static class ScalarServiceCollectionExtensions
{
    public static IServiceCollection AddLumaScalar(this IServiceCollection services, IConfiguration configuration, string sectionName)
        => services.AddLumaScalar(configuration.GetSection(sectionName));

    public static IServiceCollection AddLumaScalar(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ScalarOption>(configuration);
        var option = configuration.Get<ScalarOption>() ?? new();

        return services.AddService(option);
    }

    public static IServiceCollection AddLumaScalar(this IServiceCollection services, Action<ScalarOption> action)
    {
        services.Configure(action);
        var option = new ScalarOption();
        action.Invoke(option);

        return services.AddService(option);
    }

    private static IServiceCollection AddService(this IServiceCollection services, ScalarOption option)
    {
        if (option.Enabled)
        {
            services.AddOpenApi();
        }

        return services;
    }


    public static void UseLumaScalar(this WebApplication app)
    {
        var option = app.Services.GetRequiredService<IOptions<ScalarOption>>().Value;
        if (option.Enabled)
        {
            app.MapOpenApi();

            app.MapScalarApiReference(endpointPrefix: option.EndpointPrefix, O =>
            {
                O.Layout = Enum.Parse<ScalarLayout>(option.Layout);
                O.Theme = Enum.Parse<ScalarTheme>(option.Theme);
                O.DarkMode = true;
                O.Title = option.Title;
                O.HiddenClients = true;

                if (option.ClientCredentials.Enabled)
                {
                    O.AddPreferredSecuritySchemes("OAuth2")
                     .AddClientCredentialsFlow("OAuth2", flow =>
                     {
                         flow.ClientId = option.ClientCredentials.ClientId;
                         flow.ClientSecret = option.ClientCredentials.ClientSecret;
                         flow.SelectedScopes = option.ClientCredentials.SelectedScopes;
                     }).WithPersistentAuthentication();
                }

                // O.DefaultHttpClient = new KeyValuePair<ScalarTarget, ScalarClient>(ScalarTarget.CSharp, ScalarClient.HttpClient);

            });
        }
    }

}
