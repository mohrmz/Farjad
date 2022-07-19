using Farjad.Core.Domain.Exceptions;
using Farjad.Core.Domain.ValueObjects;
using Farjad.Utilities.Extensions;

namespace Farjad.Core.Domain.Toolkits.ValueObjects;

public class NationalCode : BaseValueObject<NationalCode>
{
    #region Properties

    public string Value { get; private set; }

    #endregion Properties

    #region Constructors and Factories

    public static NationalCode FromString(string value) => new(value);

    public NationalCode(string value)
    {
        if (!value.IsNationalCode())
        {
            throw new InvalidValueObjectStateException("ValidationErrorStringFormat", nameof(NationalCode));
        }

        Value = value;
    }

    private NationalCode()
    {
    }

    #endregion Constructors and Factories

    #region Equality Check

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    #endregion Equality Check

    #region Operator Overloading

    public static explicit operator string(NationalCode title) => title.Value;

    public static implicit operator NationalCode(string value) => new(value);

    #endregion Operator Overloading

    #region Methods

    public override string ToString() => Value;

    #endregion Methods
}