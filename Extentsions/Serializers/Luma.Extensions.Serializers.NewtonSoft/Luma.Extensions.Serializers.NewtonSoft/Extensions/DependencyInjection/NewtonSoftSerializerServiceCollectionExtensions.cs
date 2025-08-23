using Luma.Extensions.Serializers.Abstractions;
using Luma.Extensions.Serializers.NewtonSoft.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Luma.Extensions.DependencyInjection;

public static class NewtonSoftSerializerServiceCollectionExtensions
{
    public static IServiceCollection AddLumaNewtonSoftSerializer(this IServiceCollection services) => services.AddSingleton<IJsonSerializer, NewtonSoftSerializer>();
}
