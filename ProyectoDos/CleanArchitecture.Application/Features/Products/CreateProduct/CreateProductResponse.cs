namespace CleanArchitecture.Application.Features.Products.CreateProduct
{
    /// <summary>
    /// Represents the response for a successful product creation request.
    /// </summary>
    public sealed record CreateProductResponse
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
