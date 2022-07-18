using Scorpion.Core.Domain.Events;
using System.Reflection;

namespace Scorpion.Core.Domain.Entities
{
    /// <summary>
    /// Implementing the Aggregate Root pattern
    /// You can see the full description of this pattern at the address below
    /// https://martinfowler.com/bliki/DDD_Aggregate.html
    ///
    /// </summary>
    public abstract class AggregateRoot : Entity
    {
        /// <summary>
        /// It maintains a list of related Evants
        /// </summary>
        private readonly List<IDomainEvent>? _events;

        protected AggregateRoot() => _events = new();

        /// <summary>
        /// Aggregate Builder to create Aggregate from Events
        /// </summary>
        /// <param name="events">If the Event already exists, it will be sent to the Aggregate by this parameter</param>
        public AggregateRoot(IEnumerable<IDomainEvent> events)
        {
            if (events == null || !events.Any()) return;
            foreach (var @event in events)
            {
                Mutate(@event);
            }
        }

        /// <summary>
        /// Adds a new event to the set of events in this aggregate.
        /// Invoke event on method if exists.
        /// </summary>
        /// <param name="event">Domain related event</param>
        protected void Apply(IDomainEvent @event)
        {
            Mutate(@event);
            AddEvent(@event);
        }

        /// <summary>
        /// Invoke event on method if exists.
        /// </summary>
        /// <param name="event">Domain related event</param>
        private void Mutate(IDomainEvent @event)
        {
            var onMethod = this.GetType().GetMethod("On", BindingFlags.Instance | BindingFlags.NonPublic, new Type[] { @event.GetType() });
            onMethod?.Invoke(this, new[] { @event });
        }

        /// <summary>
        /// Adds a new event to the set of events in this aggregate.
        /// Aggregates themselves are responsible for creating and sending the event.
        /// </summary>
        /// <param name="event"></param>
        protected void AddEvent(IDomainEvent @event) => _events?.Add(@event);

        /// <summary>
        /// Returns a list of events that have occurred for the Aggregate in a read-only and immutable form.
        /// </summary>
        /// <returns>List of events</returns>
        public IEnumerable<IDomainEvent> GetEvents() => _events?.AsEnumerable() ?? Enumerable.Empty<IDomainEvent>();

        /// <summary>
        /// Deletes the events in this Aggregate
        /// </summary>
        public void ClearEvents() => _events?.Clear();
    }
}