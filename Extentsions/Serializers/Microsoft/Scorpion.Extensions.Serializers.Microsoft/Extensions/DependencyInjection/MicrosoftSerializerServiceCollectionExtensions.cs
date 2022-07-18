using Microsoft.Extensions.DependencyInjection;
using Scorpion.Extensions.Serializers.Abstractions;
using Scorpion.Extensions.Serializers.Microsoft.Services;

namespace Scorpion.Extensions.DependencyInjection;

public static class MicrosoftSerializerServiceCollectionExtensions
{
    public static IServiceCollection AddScorpionMicrosoftSerializer(this IServiceCollection services)
        => services.AddSingleton<IJsonSerializer, MicrosoftSerializer>();
}
