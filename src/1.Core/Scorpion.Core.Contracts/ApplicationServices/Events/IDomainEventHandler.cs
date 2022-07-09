using Scorpion.Core.Domain.Events;

namespace Scorpion.Core.Contracts.ApplicationServices.Events;
public interface IDomainEventHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
    Task Handle(TDomainEvent Event);
}

