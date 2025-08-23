using Luma.Extensions.UsersManagement.Abstractions;
using Luma.Extensions.UsersManagement.Options;
using Luma.Extensions.UsersManagement.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Luma.Extensions.DependencyInjection;

public static class UserInfoServiceCollectionExtensions
{
    public static IServiceCollection AddLumaWebUserInfoService(this IServiceCollection services, IConfiguration configuration, bool useFake = false)
    {
        if (useFake)
        {
            services.AddSingleton<IUserInfoService, FakeUserInfoService>();

        }
        else
        {
            services.Configure<UserManagementOptions>(configuration);
            services.AddSingleton<IUserInfoService, WebUserInfoService>();

        }
        return services;
    }


    public static IServiceCollection AddLumaWebUserInfoService(this IServiceCollection services, IConfiguration configuration, string sectionName, bool useFake = false)
    {
        services.AddLumaWebUserInfoService(configuration.GetSection(sectionName), useFake);
        return services;
    }

    public static IServiceCollection AddLumaWebUserInfoService(this IServiceCollection services, Action<UserManagementOptions> setupAction, bool useFake = false)
    {
        if (useFake)
        {
            services.AddSingleton<IUserInfoService, FakeUserInfoService>();

        }
        else
        {
            services.Configure(setupAction);
            services.AddSingleton<IUserInfoService, WebUserInfoService>();

        }
        return services;
    }
}


