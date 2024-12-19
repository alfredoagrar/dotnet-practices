using MediatR;

namespace CleanArchitecture.Application.Features.Products.GetAllProducts
{
    /// <summary>
    /// Represents a request to retrieve all products.
    /// Implements <see cref="IRequest{List{GetAllProductsResponse}}"/>.
    /// </summary>
    public sealed record class GetAllProductsRequest : IRequest<List<GetAllProductsResponse>>;
}
