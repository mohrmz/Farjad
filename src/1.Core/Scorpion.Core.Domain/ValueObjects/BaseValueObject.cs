namespace Scorpion.Core.Domain.ValueObjects
{
    /// <summary>
    /// Base class for all Value Objects
    /// A full explanation of the reasons for the existence of Value Objects can be found in the link below
    /// https://martinfowler.com/bliki/ValueObject.html
    /// </summary>
    /// <typeparam name="TValueObject">Entity related base value object</typeparam>
    
    public abstract class BaseValueObject<TValueObject> : IEquatable<TValueObject>
        where TValueObject : BaseValueObject<TValueObject>
    {
        /// <summary>
        /// Checks equality status
        /// </summary>
        /// <param name="other">Another value object for equlity check</param>
        /// <returns>Equality status</returns>
        public bool Equals(TValueObject? other) => this == other;

        /// <summary>
        /// Checks equality status
        /// </summary>
        /// <param name="obj">Another value object for equlity check</param>
        /// <returns>Equality status</returns>
        public override bool Equals(object? obj)
        {
            if (obj is TValueObject otherObject)
            {
                if (this is null && otherObject is null)
                    return true;
                if (this is null || otherObject is null)
                    return false;
                return GetEqualityComponents().SequenceEqual(otherObject.GetEqualityComponents());
            }
            return false;
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }

        /// <summary>
        /// Gets value object components.
        /// </summary>
        /// <returns>IEnumerable<object> Components</returns>
        protected abstract IEnumerable<object> GetEqualityComponents();

        public static bool operator ==(BaseValueObject<TValueObject> right, BaseValueObject<TValueObject> left)
        {
            return right.Equals(left);
        }

        public static bool operator !=(BaseValueObject<TValueObject> right, BaseValueObject<TValueObject> left) => !(right == left);
    }
}