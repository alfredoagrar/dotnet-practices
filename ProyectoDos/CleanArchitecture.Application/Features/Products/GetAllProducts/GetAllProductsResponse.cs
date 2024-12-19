namespace CleanArchitecture.Application.Features.Products.GetAllProducts
{
    /// <summary>
    /// Represents the response for retrieving a product.
    /// </summary>
    public sealed record GetAllProductsResponse
    {
        public int Id { get; init; }
        public string Type { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string Data { get; init; }
        public DateTime Created { get; init; }
        public string CreatedBy { get; init; }
        public DateTime? LastModified { get; init; }
        public string LastModifiedBy { get; init; }
    }
}
