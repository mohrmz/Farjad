using Farjad.Extensions.Logger.Abstractions;
using Farjad.Utilities;


namespace Farjad.Endpoints.WebApi.Extentions.DependencyInjection;

public static class AddFarjadServicesExtentions
{
    public static IServiceCollection AddFarjadUntilityServices(
        this IServiceCollection services)
    {
        services.AddScoped<IScopeInformation, ScopeInformation>();
        services.AddTransient<FarjadServices>();
        return services;
    }
}