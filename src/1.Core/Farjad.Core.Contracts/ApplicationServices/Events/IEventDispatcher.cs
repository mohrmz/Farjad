using Farjad.Core.Domain.Events;

namespace Farjad.Core.Contracts.ApplicationServices.Events;

/// <summary>
/// Define structure to manage events. Implementation of the Mediator pattern.
/// This pattern is used to reduce the complexity of calling events.
/// </summary>
public interface IEventDispatcher
{
    /// <summary>
    /// An TDomainEvent event is received and the appropriate implementation is found to manage this event and the work is handed over to that implementation to continue processing.
    /// </summary>
    /// <typeparam name="TDomainEvent">Specifies the domain event type</typeparam>
    /// <param name="event">The name of the event</param>
    /// <returns>Appropriate event  result</returns>
    Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent;
}