using FluentValidation.AspNetCore;
using Luma.EndPoints.Web.Middlewares.ApiExceptionHandler;

namespace Luma.EndPoints.Web.Extensions.DependencyInjection;

public static class AddApiConfigurationExtensions
{
    public static IServiceCollection AddLumaApiCore(this IServiceCollection services, params string[] assemblyNamesForLoad)
    {

        services.AddControllers().AddFluentValidation();
        services.AddLumaDependencies(assemblyNamesForLoad);

        return services;
    }

    public static void UseLumaApiExceptionHandler(this IApplicationBuilder app)
    {

        app.UseApiExceptionHandler(options =>
        {
            options.AddResponseDetails = (context, ex, error) =>
            {
                if (ex.GetType().Name == typeof(Microsoft.Data.SqlClient.SqlException).Name)
                {
                    error.Detail = "Exception was a database exception!";
                }
            };
            options.DetermineLogLevel = ex =>
            {
                if (ex.Message.StartsWith("cannot open database", StringComparison.InvariantCultureIgnoreCase) ||
                    ex.Message.StartsWith("a network-related", StringComparison.InvariantCultureIgnoreCase))
                {
                    return LogLevel.Critical;
                }
                return LogLevel.Error;
            };
        });

    }
}
