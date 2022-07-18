using Scorpion.Core.Domain.ValueObjects;

namespace Scorpion.Core.Domain.Entities
{
    /// <summary>
    /// Base class for all entities in the system
    /// </summary>

    public abstract class Entity
    {
        /// <summary>
        /// Numerical ID of entities
        /// Be used only for saving in the database and simplicity of work.
        /// </summary>
        public long Id { get; protected set; }

        /// <summary>
        /// Entity ID
        /// The main Entity ID that should be used everywhere is BusinessId.
        /// All communications must be established with this ID.
        /// </summary>
        public BusinessId BusinessId { get; protected set; } = BusinessId.FromGuid(Guid.NewGuid());

        /// <summary>
        /// The default constructor is defined as Protected.
        /// Given that this requirement is created when constructing the basic Entity properties, no object should be created without filling these properties.
        /// To avoid this, all Entities must be defined with constructors that have an input value.
        /// In order to be able to use these entities for the process of storing and retrieving from the database with the help of ORMs, it is necessary to create a default constructor with a high access level such as Protected or Private.
        /// </summary>
        protected Entity()
        { }

        #region Equality Check

        public bool Equals(Entity? other) => this == other;

        public override bool Equals(object? obj) =>
             obj is Entity otherObject && Id == otherObject.Id;

        public override int GetHashCode() => Id.GetHashCode();

        public static bool operator ==(Entity left, Entity right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
            => !(right == left);

        #endregion Equality Check
    }
}