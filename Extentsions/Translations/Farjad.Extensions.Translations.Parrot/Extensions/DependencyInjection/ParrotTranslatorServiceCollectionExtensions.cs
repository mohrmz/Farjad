using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Farjad.Extensions.Translations.Abstractions;
using Farjad.Extensions.Translations.Parrot.Options;
using Farjad.Extensions.Translations.Parrot.Services;

namespace Farjad.Extensions.DependencyInjection;

public static class ParrotTranslatorServiceCollectionExtensions
{
    public static IServiceCollection AddFarjadParrotTranslator(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ITranslator, ParrotTranslator>();
        services.Configure<ParrotTranslatorOptions>(configuration);
        return services;
    }

    public static IServiceCollection AddFarjadParrotTranslator(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddFarjadParrotTranslator(configuration.GetSection(sectionName));
        return services;
    }

    public static IServiceCollection AddFarjadParrotTranslator(this IServiceCollection services, Action<ParrotTranslatorOptions> setupAction)
    {
        services.AddSingleton<ITranslator, ParrotTranslator>();
        services.Configure(setupAction);
        return services;
    }
}