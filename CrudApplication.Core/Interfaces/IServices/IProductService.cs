using CrudApplication.Core.Entities.Business;

namespace CrudApplication.Core.Interfaces.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<PaginationDto<ProductDto>> GetPaginatedProducts(int pageNumber, int pageSize);
        Task<ProductDto> GetProduct(int id);
        Task<bool> IsExists(string key, string value);
        Task<bool> IsExistsForUpdate(int id, string key, string value);
        Task<ProductDto> Create(ProductDto model);
        Task Update(ProductDto model);
        Task Delete(int id);
    }
}
