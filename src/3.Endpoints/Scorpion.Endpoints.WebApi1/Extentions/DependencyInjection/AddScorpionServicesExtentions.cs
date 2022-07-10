using Scorpion.Utilities;
using Zamin.Extensions.Logger.Abstractions;

namespace Scorpion.Endpoints.WebApi.Extentions.DependencyInjection;

public static class AddScorpionServicesExtentions
{
    public static IServiceCollection AddScorpionUntilityServices(
        this IServiceCollection services)
    {
        services.AddScoped<IScopeInformation, ScopeInformation>();
        services.AddTransient<ScorpionServices>();
        return services;
    }
}