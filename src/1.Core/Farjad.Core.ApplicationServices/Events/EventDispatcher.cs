using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Farjad.Core.Contracts.ApplicationServices.Events;

namespace Farjad.Core.ApplicationServices.Events;

public class EventDispatcher : IEventDispatcher
{
    #region Fields

    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<EventDispatcher> _logger;

    #endregion Fields

    #region Constructors

    public EventDispatcher(IServiceProvider serviceProvider, ILogger<EventDispatcher> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    #endregion Constructors

    #region Event Dispatcher

    Task IEventDispatcher.PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event)
    {
        var handlers = _serviceProvider.GetServices<IDomainEventHandler<TDomainEvent>>();

        _logger.LogDebug("Routing event of type {EventType} With value {Event}  Start at {StartDateTime}", @event.GetType(), @event, DateTime.Now);
        int counter = 0;
        foreach (var handler in handlers)
        {
            counter++;
            handler.Handle(@event);
        }
        _logger.LogDebug("Total number of handler for {EventType} is {Count}", @event.GetType(), counter);
        return Task.CompletedTask;
    }

    #endregion Event Dispatcher
}