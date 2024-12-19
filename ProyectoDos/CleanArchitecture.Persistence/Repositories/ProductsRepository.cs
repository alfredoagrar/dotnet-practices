using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Context;

namespace CleanArchitecture.Persistence.Repositories;
public class ProductsRepository : BaseRepository<Product>, IProductRepository
{
    public ProductsRepository(DataContext context) : base(context)
    {
    }

    // Add specifict methods for the tv repositorie
}

