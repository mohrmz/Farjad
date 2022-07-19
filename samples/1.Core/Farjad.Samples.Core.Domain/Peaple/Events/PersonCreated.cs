using Farjad.Core.Domain.Events;

namespace Farjad.Samples.Core.Domain.Peaple.Events
{
    public class PersonCreated : IDomainEvent
    {
        public Guid BusinessId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PersonCreated(Guid businessId, string firstName, string lastName)
        {
            BusinessId = businessId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}