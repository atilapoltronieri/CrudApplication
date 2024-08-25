using CrudApplication.API.Controllers;
using CrudApplication.Core.Entities.Business;
using CrudApplication.Core.Entities.Persistence;
using CrudApplication.Core.Interfaces.IRepository;
using CrudApplication.Core.Interfaces.IServices;
using CrudApplication.Core.Interfaces.Mapper;
using CrudApplication.Core.Services;
using CrudApplication.Infrastructure.Data;
using CrudApplication.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Moq;

namespace CrudApplication.Test.Base
{
    // Fixture to reuse configurations through tests classes
    public class BaseFixture
    {
        private Mock<ApplicationDbContext> _dbContextMock;
        private Mock<IProductService> _productServiceMock;
        private Mock<ILogger<ProductController>> _loggerMock;
        private Mock<IBaseMapper<Product, ProductDto>> _productViewModelMapperMock;
        private Mock<IBaseMapper<ProductDto, Product>> _productMapperMock;
        private Mock<IProductRepository> _productRepositoryMock;

        public Product newProduct;
        public ProductDto newProductDto;
        public List<ProductDto> listProduct;
        public PaginationDto<ProductDto> paginationDto;
        public ProductService productService;
        public ProductRepository productRepository;
        public ProductController productController;

        public BaseFixture() : base()
        {
            CreateBaseObjects();

            SetupMock();

            ConfigureServices();
        }

        private void CreateBaseObjects()
        {
            newProduct = new Product
            {
                Code = "P001",
                Name = "Sample Product",
                IsActive = true
            };

            listProduct =
            [
                new() { Id = 1, Code = "P001", Name = "Product A", IsActive = true },
                new() { Id = 2, Code = "P002", Name = "Product B", IsActive = true }
            ];

            newProductDto = new ProductDto
            {
                Code = "P001",
                Name = "Sample Product",
                Description = "Sample description",
                IsActive = true
            };

            paginationDto = new PaginationDto<ProductDto>(listProduct, listProduct.Count);
        }

        private void SetupMock()
        {
            var productDbSetMock = new Mock<DbSet<Product>>();
            _dbContextMock = new Mock<ApplicationDbContext>(new DbContextOptions<ApplicationDbContext>());

            _dbContextMock.Setup(db => db.Set<Product>())
                          .Returns(productDbSetMock.Object);

            productDbSetMock.Setup(dbSet => dbSet.AddAsync(newProduct, default))
                            .ReturnsAsync((EntityEntry<Product>)null);

            _loggerMock = new Mock<ILogger<ProductController>>();
            
            _productServiceMock = new Mock<IProductService>();
            _productServiceMock.Setup(service => service.GetProducts())
                               .ReturnsAsync(listProduct);
            _productServiceMock.Setup(service => service.GetPaginatedProducts(It.IsAny<int>(), It.IsAny<int>()))
                               .ReturnsAsync(paginationDto);
            _productServiceMock.Setup(service => service.GetProduct(It.IsAny<int>()))
                               .ReturnsAsync(newProductDto);
            _productServiceMock.Setup(service => service.Create(It.IsAny<ProductDto>()))
                               .ReturnsAsync(newProductDto);
            _productServiceMock.Setup(service => service.Update(It.IsAny<ProductDto>()));
            _productServiceMock.Setup(service => service.Delete(It.IsAny<int>()));

            _productMapperMock = new Mock<IBaseMapper<ProductDto, Product>>();
            _productMapperMock.Setup(mapper => mapper.MapModel(newProductDto))
                              .Returns(newProduct);

            _productRepositoryMock = new Mock<IProductRepository>();
            _productRepositoryMock.Setup(repo => repo.Create(newProduct))
                                  .ReturnsAsync(newProduct);

            _productViewModelMapperMock = new Mock<IBaseMapper<Product, ProductDto>>();
            _productViewModelMapperMock.Setup(mapper => mapper.MapModel(newProduct))
                                       .Returns(newProductDto);
        }

        private void ConfigureServices()
        {
            productRepository = new ProductRepository(_dbContextMock.Object);

            productController = new ProductController(_loggerMock.Object, _productServiceMock.Object);

            productService = new ProductService(
                _productViewModelMapperMock.Object,
                _productMapperMock.Object,
                _productRepositoryMock.Object);
        }
    }
}
