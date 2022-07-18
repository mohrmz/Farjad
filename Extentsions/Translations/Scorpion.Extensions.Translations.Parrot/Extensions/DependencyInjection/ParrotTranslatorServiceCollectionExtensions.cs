using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scorpion.Extensions.Translations.Abstractions;
using Scorpion.Extensions.Translations.Parrot.Options;
using Scorpion.Extensions.Translations.Parrot.Services;

namespace Scorpion.Extensions.DependencyInjection;

public static class ParrotTranslatorServiceCollectionExtensions
{
    public static IServiceCollection AddScorpionParrotTranslator(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<ITranslator, ParrotTranslator>();
        services.Configure<ParrotTranslatorOptions>(configuration);
        return services;
    }

    public static IServiceCollection AddScorpionParrotTranslator(this IServiceCollection services, IConfiguration configuration, string sectionName)
    {
        services.AddScorpionParrotTranslator(configuration.GetSection(sectionName));
        return services;
    }

    public static IServiceCollection AddScorpionParrotTranslator(this IServiceCollection services, Action<ParrotTranslatorOptions> setupAction)
    {
        services.AddSingleton<ITranslator, ParrotTranslator>();
        services.Configure(setupAction);
        return services;
    }
}