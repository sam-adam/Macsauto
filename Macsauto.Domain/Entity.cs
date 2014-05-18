using System;

namespace Macsauto.Domain
{
    /// <summary>
    /// Entity base class
    /// 
    /// Entity represents an object with concerns on
    /// the domain model that has a life cycle
    /// </summary>
    public abstract class Entity
    {
        private DateTime _updatedOn;
        private DateTime _createdOn;
        private string _code;

        protected Entity()
        {
            _createdOn = DateTime.Now;
            _updatedOn = DateTime.Now;
        }

        protected Entity(string code)
        {
            _code = code;
            _createdOn = DateTime.Now;
            _updatedOn = DateTime.Now;
        }

        /// <summary>
        /// Entity's identity
        /// </summary>
        public virtual Guid Id { get; protected set; }

        /// <summary>
        /// Entity's human readable code
        /// </summary>
        public virtual string Code
        {
            get { return _code; }
            protected set { _code = value; }
        }

        /// <summary>
        /// Entity's creation timestamp
        /// </summary>
        public virtual DateTime CreatedOn
        {
            get { return _createdOn; }
            private set { _createdOn = value; }
        }

        /// <summary>
        /// Entity's update timestamp
        /// </summary>
        public virtual DateTime UpdatedOn
        {
            get { return _updatedOn; }
            set { _updatedOn = value; }
        }

        /// <summary>
        /// Generate a new human readable code for this entity
        /// </summary>
        /// <param name="codeGenerator">
        /// Code generator based on this entity type
        /// </param>
        /// <exception cref="ApplicationException">
        /// If the entity's code has been pre-assigned
        /// </exception>
        public void GenerateNewCode<TEntity>(ICodeGenerator<TEntity> codeGenerator) where TEntity : Entity
        {
            if (!String.IsNullOrEmpty(Code))
                throw new ApplicationException(@"Code is already manually defined");

            _code = codeGenerator.GenerateNewCode();
        }

        /// <summary>
        /// Check if the entity is in transient state, 
        /// which can means the entity is not yet persisted 
        /// or have no id
        /// </summary>
        /// <returns>
        /// True if this entity's id is equals to 
        /// the id's type default
        /// </returns>
        public bool IsTransient()
        {
            return Equals(Id, default(Guid));
        }

        /// <summary>
        /// Indicates whether the current entity
        /// is equals to another entity
        /// </summary>
        /// <param name="other">An entity to compare with the this entity</param>
        /// <returns>
        /// True if the current object is equal
        /// to the <paramref name="other"/> parameter;
        /// otherwise, false.
        /// </returns>
        public override bool Equals(object other)
        {
            var entity = other as Entity;

            if (entity == null)
                return false;

            if (IsTransient() && entity.IsTransient())
                return ReferenceEquals(this, other);

            return Id.Equals(entity.Id);
        }

        /// <summary>
        /// Get entity's hash code
        /// </summary>
        /// <returns>
        /// Type's hash code if this entity is transient,
        /// otherwise returns the id's hashcode
        /// </returns>
        public override int GetHashCode()
        {
            return IsTransient() ? GetType().GetHashCode() : Id.GetHashCode();
        }

        /// <summary>
        /// Equal operator
        /// </summary>
        /// <param name="left">Left side entity to compare</param>
        /// <param name="right">Right side entity to compare</param>
        /// <returns>True if the entities are equal, otherwise false</returns>
        public static bool operator ==(Entity left, Entity right)
        {
            return Equals(left, null) ? Equals(right, null) : left.Equals(right);
        }

        /// <summary>
        /// Not equal operator
        /// </summary>
        /// <param name="left">Left side entity to compare</param>
        /// <param name="right">Right side entity to compare</param>
        /// <returns>True if the entities are unequal, otherwise false</returns>
        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }
    }
}