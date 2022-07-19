using Farjad.Core.Domain.Exceptions;
using Farjad.Core.Domain.ValueObjects;
using Farjad.Utilities.Extensions;

namespace Farjad.Core.Domain.Toolkits.ValueObjects;

public class LegalNationalId : BaseValueObject<LegalNationalId>
{
    #region Properties

    public string Value { get; private set; }

    #endregion Properties

    #region Constructors and Factories

    public static LegalNationalId FromString(string value) => new(value);

    public LegalNationalId(string value)
    {
        if (!value.IsLegalNationalIdValid())
        {
            throw new InvalidValueObjectStateException("ValidationErrorStringFormat", nameof(LegalNationalId));
        }

        Value = value;
    }

    private LegalNationalId()
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

    public static explicit operator string(LegalNationalId title) => title.Value;

    public static implicit operator LegalNationalId(string value) => new(value);

    #endregion Operator Overloading

    #region Methods

    public override string ToString() => Value;

    #endregion Methods
}