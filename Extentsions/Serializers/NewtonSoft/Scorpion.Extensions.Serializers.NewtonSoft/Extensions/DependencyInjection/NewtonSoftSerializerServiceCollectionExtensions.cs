using Microsoft.Extensions.DependencyInjection;
using Scorpion.Extensions.Serializers.Abstractions;
using Scorpion.Extensions.Serializers.NewtonSoft.Services;

namespace Scorpion.Extensions.DependencyInjection;

public static class NewtonSoftSerializerServiceCollectionExtensions
{
    public static IServiceCollection AddScorpionNewtonSoftSerializer(this IServiceCollection services)
        => services.AddSingleton<IJsonSerializer, NewtonSoftSerializer>();
}