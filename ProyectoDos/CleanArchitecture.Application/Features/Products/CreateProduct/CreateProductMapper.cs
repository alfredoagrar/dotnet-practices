using AutoMapper;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Features.Products.CreateProduct
{
    /// <summary>
    /// Defines the AutoMapper profile for mapping between <see cref="CreateProductRequest"/>, <see cref="Product"/>, and <see cref="CreateProductResponse"/>.
    /// </summary>
    public sealed class CreateProductMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProductMapper"/> class and configures the mappings.
        /// </summary>
        public CreateProductMapper()
        {
            // Maps from CreateProductRequest to Product
            CreateMap<CreateProductRequest, Product>();
            // Maps from Product to CreateProductResponse
            CreateMap<Product, CreateProductResponse>();
        }
    }
}
