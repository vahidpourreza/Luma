using Asp.Versioning;

namespace Luma.EndPoints.Web.Extensions.DependencyInjection;
public static class ApiVersioningExtensions
{
    public static IServiceCollection AddLumaDefaultApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0); // Default API version
            options.AssumeDefaultVersionWhenUnspecified = true; // Use default if not specified
            options.ReportApiVersions = true; // Adds API version headers in responses
            options.ApiVersionReader = new UrlSegmentApiVersionReader(); // Only URL versioning
        }).AddMvc(); // Ensures correct routing behavior

        return services;
    }
}

