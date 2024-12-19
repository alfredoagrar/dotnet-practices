using CleanArchitecture.Domain.Commond;

namespace CleanArchitecture.Application.Repositories
{
    /// <summary>
    /// Generic repository interface for performing CRUD operations on entities derived from <see cref="BaseDbEntity"/>.
    /// </summary>
    /// <typeparam name="T">The type of the entity that inherits from <see cref="BaseDbEntity"/>.</typeparam>
    public interface IBaseDbRepository<T> where T : BaseDbEntity
    {
        /// <summary>
        /// Creates a new entity in the database.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        void Create(T entity);

        /// <summary>
        /// Updates an existing entity in the database.
        /// </summary>
        /// <param name="id">The ID of the entity to update.</param>
        /// <param name="entity">The entity with updated values.</param>
        void Update(int id, T entity);

        /// <summary>
        /// Deletes an entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        void Delete(int id);

        /// <summary>
        /// Retrieves an entity by its ID from the database.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <param name="cancellationToken">A token to observe while awaiting the result.</param>
        /// <returns>The entity with the specified ID.</returns>
        Task<T> Get(int id, CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves all entities from the database.
        /// </summary>
        /// <param name="cancellationToken">A token to observe while awaiting the result.</param>
        /// <returns>A list of all entities.</returns>
        Task<List<T>> GetAll(CancellationToken cancellationToken);
    }
}
