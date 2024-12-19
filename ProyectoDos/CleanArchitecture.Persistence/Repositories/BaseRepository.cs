using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Commond;

using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Implements basic methods for handling entities in the database.
/// </summary>
/// <typeparam name="TEntity">The type of entity that extends from <see cref="BaseDbEntity"/>.</typeparam>
public class BaseRepository<TEntity> : IBaseDbRepository<TEntity> where TEntity : BaseDbEntity
{
    protected readonly DataContext Context;

    /// <summary>
    /// Initializes a new instance of <see cref="BaseRepository{TEntity}"/> with the database context.
    /// </summary>
    /// <param name="context">The database context used for operations.</param>
    public BaseRepository(DataContext context)
    {
        Context = context; // Initializes the database context.
    }

    /// <summary>
    /// Creates a new entity in the database.
    /// </summary>
    /// <param name="entity">The entity to be created in the database.</param>
    public void Create(TEntity entity)
    {
        // Adds the new entity to the context to be persisted in the database.
        Context.Add(entity);
    }

    /// <summary>
    /// Retrieves an entity by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token for the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with the requested entity.</returns>
    public Task<TEntity> Get(int id, CancellationToken cancellationToken)
    {
        // Retrieves the entity with the specified ID asynchronously from the database.
        return Context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    /// <summary>
    /// Retrieves all entities from the database asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token for the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation, with a list of all entities.</returns>
    public Task<List<TEntity>> GetAll(CancellationToken cancellationToken)
    {
        // Retrieves all entities from the database asynchronously.
        return Context.Set<TEntity>().ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Updates an existing entity in the database.
    /// </summary>
    /// <param name="id">The ID of the entity to update.</param>
    /// <param name="entity">The entity with the updated data.</param>
    /// <exception cref="NotImplementedException">This method is not implemented.</exception>
    public void Update(int id, TEntity entity)
    {
        // This method is not implemented, but its purpose would be to update an existing entity in the database.
        // It should find the entity by its ID and then update its values.
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deletes an entity from the database by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    public void Delete(int id)
    {
        // This method deletes an entity from the database by its ID using raw SQL.
        // In this case, a stored procedure is used to perform the deletion.
        Context.Database.ExecuteSqlRawAsync(
            "EXEC BaseDb.sp_DeleteEntity @Id = {0}",
            id);
    }
}
