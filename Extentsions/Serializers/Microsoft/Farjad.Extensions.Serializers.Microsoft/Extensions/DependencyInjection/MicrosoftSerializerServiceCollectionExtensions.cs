using Microsoft.Extensions.DependencyInjection;
using Farjad.Extensions.Serializers.Abstractions;
using Farjad.Extensions.Serializers.Microsoft.Services;

namespace Farjad.Extensions.DependencyInjection;

public static class MicrosoftSerializerServiceCollectionExtensions
{
    public static IServiceCollection AddFarjadMicrosoftSerializer(this IServiceCollection services)
        => services.AddSingleton<IJsonSerializer, MicrosoftSerializer>();
}
