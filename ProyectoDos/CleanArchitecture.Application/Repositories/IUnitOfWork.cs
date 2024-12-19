namespace CleanArchitecture.Application.Repositories
{
    /// <summary>
    /// Defines the contract for a unit of work that manages transactional operations.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commits all changes made in the unit of work to the database.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Save(CancellationToken cancellationToken);
    }
}
