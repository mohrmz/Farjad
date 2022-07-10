using Scorpion.Core.Domain.Exceptions;
using Scorpion.Core.Domain.ValueObjects;
using Scorpion.Utilities.Extensions;

namespace Scorpion.Samples.Core.Domain.Peaple.ValueObjects
{
    public class FirstName : BaseValueObject<FirstName>
    {
        public string Value { get; set; }

        public FirstName(string value)
        {
            value = value.Trim();

            if (string.IsNullOrEmpty(value))
                throw new InvalidValueObjectStateException(Messages.InvalidNullValue, this.GetType().Name);

            if (!value.IsLengthBetween(2, 50))
                throw new InvalidValueObjectStateException(Messages.InvalidStringLength, this.GetType().Name, "2", "50");

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}