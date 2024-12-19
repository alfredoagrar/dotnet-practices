using AutoMapper;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Products.GetAllProducts
{
    /// <summary>
    /// Defines the AutoMapper profile for mapping between <see cref="Product"/> and <see cref="GetAllProductsResponse"/>.
    /// </summary>
    public sealed class GetAllProductsMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllProductsMapper"/> class and configures the mapping rules.
        /// </summary>
        public GetAllProductsMapper()
        {
            // Maps from Product to GetAllProductsResponse
            CreateMap<Product, GetAllProductsResponse>();
        }
    }
}
