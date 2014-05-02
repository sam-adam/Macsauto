using System.Collections.Generic;

namespace Macsauto.Domain
{
    /// <summary>
    /// Repository main interface
    /// </summary>
    /// <typeparam name="TEntity">Entity this repository handles</typeparam>
    /// <typeparam name="TId">Entity's id this repository handles</typeparam>
    public interface IRepository<TEntity, in TId> where TEntity : Entity<TEntity, TId>, IAggregateRoot
    {
        /// <summary>
        /// Find an entity based on it's id
        /// </summary>
        /// <param name="id">Entity's id</param>
        /// <returns>Entity</returns>
        TEntity Find(TId id);

        /// <summary>
        /// Count all entity
        /// </summary>
        /// <returns>Total entity found</returns>
        long Count();

        /// <summary>
        /// Checks if an entity with given id exists
        /// </summary>
        /// <param name="id">Entity's id</param>
        /// <returns>True if found, otherwise false</returns>
        bool Exists(object id);

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>List of entities</returns>
        IList<TEntity> GetAll();

        /// <summary>
        /// Get last daily index
        /// </summary>
        /// <returns>Last daily index or 0 if none found</returns>
        long GetLastDailyIndex();

        /// <summary>
        /// Get last monthly index
        /// </summary>
        /// <returns>Last monthly index or 0 if none found</returns>
        long GetLastMonthlyIndex();

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// Delete all entities
        /// </summary>
        void DeleteAll();

        /// <summary>
        /// Save an entity
        /// </summary>
        /// <param name="entity">Entity to save</param>
        /// <returns>Saved entity</returns>
        TEntity Save(TEntity entity);

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>Updated entity</returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Save or update an entity
        /// </summary>
        /// <param name="entity">Entity to save or update</param>
        /// <returns>Saved or updated entity</returns>
        TEntity SaveOrUpdate(TEntity entity);
    }
}