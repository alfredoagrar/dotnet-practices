using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Repositories
{
    public interface IProductRepository : IBaseDbRepository<Product>
    {
        // Add special methods if needed.
    }
}
