using Luma.Extensions.Serializers.Abstractions;
using Luma.Extensions.Serializers.EPPlus.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Luma.Extensions.DependencyInjection;

public static class EPPlusExcelSerializerServiceCollectionExtensions
{
    public static IServiceCollection AddEPPlusExcelSerializer(this IServiceCollection services) => services.AddSingleton<IExcelSerializer, EPPlusExcelSerializer>();
}
