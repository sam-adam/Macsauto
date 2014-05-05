namespace Macsauto.Domain
{
    /// <summary>
    /// Interface for the code generator
    /// assigned for <typeparamref name="TEntity"/>
    /// </summary>
    /// <typeparam name="TEntity">Entity to generate code into</typeparam>
    public interface ICodeGenerator<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Generate a new human readable code
        /// </summary>
        /// <returns>Entity's new code</returns>
        string GenerateNewCode();
    }
}