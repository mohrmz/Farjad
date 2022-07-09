using Scorpion.Core.Domain.Exceptions;
using Scorpion.Core.Domain.ValueObjects;

namespace Scorpion.Samples.Core.Domain.Peaple.ValueObjects
{
    public class LastName : BaseValueObject<LastName>
    {
        public string Value { get; set; }

        public LastName(string value)
        {
            value = value.Trim();

            if (string.IsNullOrEmpty(value))
                throw new InvalidValueObjectStateException(Messages.InvalidNullValue, this.GetType().Name);

            if (value.Length < 2 || value.Length > 50)
                throw new InvalidValueObjectStateException(Messages.InvalidStringLength, this.GetType().Name, "2", "50");

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}