using CrudApplication.Core.Entities.Business;
using CrudApplication.Core.Entities.Persistence;
using CrudApplication.Core.Interfaces.IRepository;
using CrudApplication.Core.Interfaces.IServices;
using CrudApplication.Core.Interfaces.Mapper;

namespace CrudApplication.Core.Services
{
    public class ProductService(
        IBaseMapper<Product, ProductDto> ProductDTOMapper,
        IBaseMapper<ProductDto, Product> productMapper,
        IProductRepository productRepository) : IProductService
    {
        private readonly IBaseMapper<Product, ProductDto> _ProductDTOMapper = ProductDTOMapper;
        private readonly IBaseMapper<ProductDto, Product> _productMapper = productMapper;
        private readonly IProductRepository _productRepository = productRepository;

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            return _ProductDTOMapper.MapList(await _productRepository.GetAll());
        }

        public async Task<PaginationDto<ProductDto>> GetPaginatedProducts(int pageNumber, int pageSize)
        {
            //Get peginated data
            var paginatedData = await _productRepository.GetPaginatedData(pageNumber, pageSize);

            //Map data with ViewModel
            var mappedData = _ProductDTOMapper.MapList(paginatedData.Data);

            var paginationDTO = new PaginationDto<ProductDto>(mappedData.ToList(), paginatedData.TotalCount);

            return paginationDTO;
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            return _ProductDTOMapper.MapModel(await _productRepository.GetById(id));
        }

        public async Task<bool> IsExists(string key, string value)
        {
            return await _productRepository.IsExists(key, value);
        }

        public async Task<bool> IsExistsForUpdate(int id, string key, string value)
        {
            return await _productRepository.IsExistsForUpdate(id, key, value);
        }

        public async Task<ProductDto> Create(ProductDto model)
        {
            //Mapping through AutoMapper
            var entity = _productMapper.MapModel(model);
            entity.EntryDate = DateTime.Now;
            return _ProductDTOMapper.MapModel(await _productRepository.Create(entity));
        }

        public async Task Update(ProductDto model)
        {
            var existingData = await _productRepository.GetById(model.Id);

            //Manual mapping
            existingData.Code = model.Code;
            existingData.Name = model.Name;
            existingData.Description = model.Description;
            existingData.IsActive = model.IsActive;
            existingData.UpdateDate = DateTime.Now;

            await _productRepository.Update(existingData);
        }

        public async Task Delete(int id)
        {
            var entity = await _productRepository.GetById(id);
            await _productRepository.Delete(entity);
        }
    }
}
