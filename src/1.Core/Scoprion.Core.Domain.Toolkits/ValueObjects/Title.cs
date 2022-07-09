using Scorpion.Core.Domain.Exceptions;
using Scorpion.Core.Domain.ValueObjects;

namespace Scoprion.Core.Domain.Toolkits.ValueObjects;

public class Title : BaseValueObject<Title>
{
    #region Properties

    public string Value { get; private set; }

    #endregion Properties

    #region Constructors and Factories

    public static Title FromString(string value) => new Title(value);

    public Title(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidValueObjectStateException("ValidationErrorIsRequire", nameof(Title));
        }
        if (value.Length < 2 || value.Length > 250)
        {
            throw new InvalidValueObjectStateException("ValidationErrorStringLength", nameof(Title), "2", "250");
        }
        Value = value;
    }

    private Title()
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

    public static explicit operator string(Title title) => title.Value;

    public static implicit operator Title(string value) => new(value);

    #endregion Operator Overloading

    #region Methods

    public override string ToString() => Value;

    #endregion Methods
}