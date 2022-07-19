using Microsoft.Extensions.DependencyInjection;
using Farjad.Extensions.Serializers.Abstractions;
using Farjad.Extensions.Serializers.EPPlus.Services;

namespace Farjad.Extensions.DependencyInjection;

public static class EPPlusExcelSerializerServiceCollectionExtensions
{
    public static IServiceCollection AddEPPlusExcelSerializer(this IServiceCollection services)
        => services.AddSingleton<IExcelSerializer, EPPlusExcelSerializer>();
}