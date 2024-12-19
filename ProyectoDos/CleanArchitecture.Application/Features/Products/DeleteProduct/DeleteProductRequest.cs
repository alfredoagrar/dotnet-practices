using MediatR;

namespace CleanArchitecture.Application.Features.Products.DeleteProduct
{
    /// <summary>
    /// Represents a request to delete an existing product.
    /// Implements <see cref="IRequest"/>.
    /// </summary>
    public sealed class DeleteProductRequest : IRequest
    {
        /// <summary>
        /// Gets or sets the ID of the product to be deleted.
        /// </summary>
        public int Id { get; set; }
    }
}
