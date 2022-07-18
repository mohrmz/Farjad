using Microsoft.Extensions.DependencyInjection;
using Scorpion.Extensions.Serializers.Abstractions;
using Scorpion.Extensions.Serializers.EPPlus.Services;

namespace Scorpion.Extensions.DependencyInjection;

public static class EPPlusExcelSerializerServiceCollectionExtensions
{
    public static IServiceCollection AddEPPlusExcelSerializer(this IServiceCollection services)
        => services.AddSingleton<IExcelSerializer, EPPlusExcelSerializer>();
}