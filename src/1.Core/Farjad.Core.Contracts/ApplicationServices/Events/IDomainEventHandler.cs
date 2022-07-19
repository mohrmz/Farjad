using Farjad.Core.Domain.Events;

namespace Farjad.Core.Contracts.ApplicationServices.Events;

/// <summary>
/// Define structure to manage events.
/// This pattern is used to reduce the complexity of calling events.
/// </summary>
/// <typeparam name="TDomainEvent">Specifies the event type</typeparam>
public interface IDomainEventHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
    /// <summary>
    /// An TDomainEvent event is received and the appropriate implementation is found to manage this event.
    /// </summary>
    /// <param name="Event">Specifies the domain event type</param>
    /// <returns>Appropriate event result</returns>
    Task Handle(TDomainEvent Event);
}