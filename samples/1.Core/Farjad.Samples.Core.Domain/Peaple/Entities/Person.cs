using Farjad.Core.Domain.Entities;
using Farjad.Samples.Core.Domain.Peaple.Events;
using Farjad.Samples.Core.Domain.Peaple.ValueObjects;

namespace Farjad.Samples.Core.Domain.Peaple.Entities
{
    public class Person : AggregateRoot
    {
        #region Properties

        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }

        #endregion Properties

        public Person(FirstName firstName, LastName lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            AddEvent(new PersonCreated(this.BusinessId.Value, firstName.Value, lastName.Value));
        }
    }
}