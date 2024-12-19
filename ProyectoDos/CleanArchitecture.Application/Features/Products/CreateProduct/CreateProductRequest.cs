using MediatR;

namespace CleanArchitecture.Application.Features.Products.CreateProduct
{
    /// <summary>
    /// Represents a request to create a new product.
    /// Implements <see cref="IRequest{CreateProductResponse}"/>.
    /// </summary>
    /// <param name="id">The unique identifier for the product to be created.</param>
    /// <param name="type">The type of the product to be created.</param>
    /// <param name="name">The name of the product to be created.</param>
    /// <param name="description">The description of the product to be created.</param>
    /// <param name="data">Additional data related to the product to be created.</param>
    public sealed record CreateProductRequest(int id, string type, string name, string description, string data) : IRequest<CreateProductResponse>;
}
