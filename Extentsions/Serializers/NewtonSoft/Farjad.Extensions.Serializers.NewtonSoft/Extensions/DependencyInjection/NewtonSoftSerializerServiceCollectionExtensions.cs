using Microsoft.Extensions.DependencyInjection;
using Farjad.Extensions.Serializers.Abstractions;
using Farjad.Extensions.Serializers.NewtonSoft.Services;

namespace Farjad.Extensions.DependencyInjection;

public static class NewtonSoftSerializerServiceCollectionExtensions
{
    public static IServiceCollection AddFarjadNewtonSoftSerializer(this IServiceCollection services)
        => services.AddSingleton<IJsonSerializer, NewtonSoftSerializer>();
}