using FluentValidation;
using Farjad.Core.ApplicationServices.Commands;
using Farjad.Core.Contracts.ApplicationServices.Commands;
using Farjad.Core.Contracts.ApplicationServices.Events;
using Farjad.Core.Contracts.ApplicationServices.Queries;
using System.Reflection;

namespace Farjad.Endpoints.WebApi.Extentions.DependencyInjection;

public static class AddApplicationServicesExtentions
{
    public static IServiceCollection AddFarjadApplicationServices(
        this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch) =>
        services
            .AddCommandHandlers(assembliesForSearch)
            .AddCommandDispatcherDecorators()
            .AddQueryHandlers(assembliesForSearch)
            .AddEventHandlers(assembliesForSearch)
            .AddFluentValidators(assembliesForSearch);

    private static IServiceCollection AddCommandHandlers(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch) =>
        services.AddWithTransientLifetime(assembliesForSearch, typeof(ICommandHandler<>), typeof(ICommandHandler<,>));

    private static IServiceCollection AddCommandDispatcherDecorators(this IServiceCollection services)
    {
        services.AddTransient<CommandDispatcher, CommandDispatcher>();
        services.AddTransient<CommandDispatcherDomainExceptionHandlerDecorator, CommandDispatcherDomainExceptionHandlerDecorator>();
        services.AddTransient<CommandDispatcherValidationDecorator, CommandDispatcherValidationDecorator>();
        services.AddTransient<ICommandDispatcher, CommandDispatcherValidationDecorator>();
        return services;
    }

    private static IServiceCollection AddQueryHandlers(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch) =>
        services.AddWithTransientLifetime(assembliesForSearch, typeof(IQueryHandler<,>), typeof(IQueryDispatcher));

    private static IServiceCollection AddEventHandlers(this IServiceCollection services,
       IEnumerable<Assembly> assembliesForSearch) =>
       services.AddWithTransientLifetime(assembliesForSearch, typeof(IDomainEventHandler<>), typeof(IEventDispatcher));

    private static IServiceCollection AddFluentValidators(this IServiceCollection services,
    IEnumerable<Assembly> assembliesForSearch) =>
    services.AddValidatorsFromAssemblies(assembliesForSearch);
}