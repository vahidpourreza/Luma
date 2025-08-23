using Luma.Extensions.Serializers.Abstractions;
using Luma.Extensions.Serializers.Microsoft.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Luma.Extensions.DependencyInjection;

public static class MicrosoftSerializerServiceCollectionExtensions
{
    public static IServiceCollection AddLumaMicrosoftSerializer(this IServiceCollection services) => services.AddSingleton<IJsonSerializer, MicrosoftSerializer>();
}

