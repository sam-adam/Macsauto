namespace Macsauto.Domain
{
    /// <summary>
    /// Interface for the code generator
    /// assigned for <typeparamref name="TEntity"/>
    /// </summary>
    /// <typeparam name="TEntity">Entity to generate code into</typeparam>
    /// <typeparam name="TId">Entity's Id</typeparam>
    public interface ICodeGenerator<TEntity, TId> where TEntity : Entity<TEntity, TId>
    {
        /// <summary>
        /// Generate a new human readable code
        /// </summary>
        /// <returns>Entity's new code</returns>
        string GenerateNewCode();
    }
}