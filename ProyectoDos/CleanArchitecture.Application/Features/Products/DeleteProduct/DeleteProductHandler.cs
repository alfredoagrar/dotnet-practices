using CleanArchitecture.Application.Repositories;
using MediatR;

namespace CleanArchitecture.Application.Features.Products.DeleteProduct
{
    /// <summary>
    /// Handler for processing the deletion of a product.
    /// Implements <see cref="IRequestHandler{DeleteProductRequest}"/>.
    /// </summary>
    public sealed class DeleteProductHandler : IRequestHandler<DeleteProductRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productsRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteProductHandler"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used to commit changes to the database.</param>
        /// <param name="productsRepository">The repository used to manage product entities.</param>
        public DeleteProductHandler(IUnitOfWork unitOfWork, IProductRepository productsRepository)
        {
            _unitOfWork = unitOfWork;
            _productsRepository = productsRepository;
        }

        /// <summary>
        /// Handles the deletion of a product.
        /// </summary>
        /// <param name="request">The request containing the ID of the product to delete.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            // Deletes the product using the repository
            _productsRepository.Delete(request.Id);

            // Saves changes in the unit of work
            await _unitOfWork.Save(cancellationToken);
        }
    }
}
