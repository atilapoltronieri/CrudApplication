using CrudApplication.Core.Entities.Persistence;
using CrudApplication.Core.Interfaces.IRepository;
using CrudApplication.Infrastructure.Data;

namespace CrudApplication.Infrastructure.Repositories
{
    public class ProductRepository(ApplicationDbContext dbContext) : BaseRepository<Product>(dbContext), IProductRepository
    {
    }
}
