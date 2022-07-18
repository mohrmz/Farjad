using Scorpion.Core.Domain.Events;

namespace Scorpion.Core.Contracts.Data.Commands;

/// <summary>
/// base event store interface If you need to save and retrieve events for eventstore pattern, this interface is used.
/// </summary>
public interface IDomainEventStore
{
    /// <summary>
    /// save events to eventstore db sync
    /// </summary>
    /// <typeparam name="TEvent">Specifies the domain event type</typeparam>
    /// <param name="aggregateName">Specifies the aggregate name</param>
    /// <param name="aggregateId">Specifies the aggregate id</param>
    /// <param name="events">Specifies the domain events</param>
    void Save<TEvent>(string aggregateName, string aggregateId, IEnumerable<TEvent> events) where TEvent : IDomainEvent;

    /// <summary>
    /// save events to eventstore db async
    /// </summary>
    /// <typeparam name="TEvent">Specifies the domain event type</typeparam>
    /// <param name="aggregateName">Specifies the aggregate name</param>
    /// <param name="aggregateId">Specifies the aggregate id</param>
    /// <param name="events">Specifies the domain events</param>
    Task SaveAsync<TEvent>(string aggregateName, string aggregateId, IEnumerable<TEvent> events) where TEvent : IDomainEvent;
}