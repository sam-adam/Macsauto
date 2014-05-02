using System;
using System.Linq;

namespace Macsauto.Domain.Core
{
    /// <summary>
    /// Value object base class
    /// 
    /// Value object represents an object that has no identity
    /// or life cycle, and only has meanings through it's properties
    /// </summary>
    /// <typeparam name="TValueObject">Type of value object</typeparam>
    public class ValueObject<TValueObject> : IEquatable<TValueObject>
        where TValueObject : ValueObject<TValueObject>
    {
        /// <summary>
        /// Indicates whether the current value object
        /// is equals to another value object based on properties comparison
        /// </summary>
        /// <param name="other">A value object to compare with the this value object</param>
        /// <returns>
        /// True if the current value object is equal
        /// to the <paramref name="other"/> parameter;
        /// otherwise, false.
        /// </returns>
        public virtual bool Equals(TValueObject other)
        {
            if ((object)other == null) return false;
            if (ReferenceEquals(this, other)) return true;

            var publicProperties = GetType().GetProperties();

            if (publicProperties.Any())
            {
                return publicProperties.All(p =>
                {
                    var left = p.GetValue(this, null);
                    var right = p.GetValue(other, null);

                    if (left is TValueObject)
                    {
                        return ReferenceEquals(left, right);
                    }

                    return left.Equals(right);
                });
            }

            return this == other;
        }

        /// <summary>
        /// Indicates whether the current value object
        /// is equals to another object
        /// </summary>
        /// <param name="obj">An object to compare with the this value object</param>
        /// <returns>
        /// True if the current value object is equal
        /// to the <paramref name="obj"/> parameter;
        /// otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;

            var item = obj as ValueObject<TValueObject>;

            if (item == null) return false;

            return Equals((TValueObject)obj);
        }

        /// <summary>
        /// Get value object's hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return GetType().GetHashCode();
            }
        }

        /// <summary>
        /// Equal operator
        /// </summary>
        /// <param name="left">Left side value object to compare</param>
        /// <param name="right">Right side value object to compare</param>
        /// <returns>True if the value objects are equal, otherwise false</returns>
        public static bool operator ==(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            return Equals(left, null) ? Equals(right, null) : left.Equals(right);
        }

        /// <summary>
        /// Not equal operator
        /// </summary>
        /// <param name="left">Left side value object to compare</param>
        /// <param name="right">Right side value object to compare</param>
        /// <returns>True if the value objects are unequal, otherwise false</returns>
        public static bool operator !=(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            return !(left == right);
        }
    }
}