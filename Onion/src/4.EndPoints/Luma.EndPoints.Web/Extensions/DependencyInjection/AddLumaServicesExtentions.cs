using Luma.Utilities;

namespace Luma.EndPoints.Web.Extensions.DependencyInjection;

public static class AddLumaServicesExtensions
{
    public static IServiceCollection AddLumaUntilityServices(this IServiceCollection services)
    {
        services.AddTransient<LumaServices>();
        return services;
    }
}
