using Luma.Extensions.ChangeDataLog.Abstractions;
using Luma.Extensions.ChangeDataLog.Sql.Options;
using Luma.Extensions.ChangeDataLog.Sql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Luma.Extensions.DependencyInjection;

public static class ChangeDatalogServiceCollectionExtensions
{
    public static IServiceCollection AddLumaChangeDatalogDalSql(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IEntityChangeInterceptorItemRepository, DapperEntityChangeInterceptorItemRepository>();
        services.Configure<ChangeDataLogSqlOptions>(configuration);
        return services;
    }

    public static IServiceCollection AddLumaChangeDatalogDalSql(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddLumaChangeDatalogDalSql(configuration.GetSection(sectionName));
        return services;
    }

    public static IServiceCollection AddLumaChangeDatalogDalSql(this IServiceCollection services, Action<ChangeDataLogSqlOptions> setupAction)
    {
        services.AddScoped<IEntityChangeInterceptorItemRepository, DapperEntityChangeInterceptorItemRepository>();
        services.Configure(setupAction);
        return services;
    }
}
