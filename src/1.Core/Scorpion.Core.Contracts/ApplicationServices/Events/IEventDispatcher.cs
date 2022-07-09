using Scorpion.Core.Domain.Events;

namespace Scorpion.Core.Contracts.ApplicationServices.Events;
public interface IEventDispatcher
{
    Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event) where TDomainEvent : class, IDomainEvent;

}

