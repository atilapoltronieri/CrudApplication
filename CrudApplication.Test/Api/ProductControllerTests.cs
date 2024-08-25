using CrudApplication.Core.Entities.Business;
using CrudApplication.Test.Base;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Assert = Xunit.Assert;

namespace CrudApplication.Test.Api
{
    public class ProductControllerTests(BaseFixture fixture) : IClassFixture<BaseFixture>
    {
        private readonly BaseFixture _fixture = fixture;

        [Fact]
        public async Task Get_ReturnsDtoListOfProducts()
        {
            // Act
            var result = await _fixture.productController.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okObjectResult = (OkObjectResult)result;
            Assert.NotNull(okObjectResult);

            var model = (IEnumerable<ProductDto>)okObjectResult.Value;
            Assert.NotNull(model);
            Assert.Equal(model?.Count(), _fixture.listProduct.Count);

        }

        [Fact]
        public async Task Get_ReturnsProductDtoById()
        {
            // Act
            var result = await _fixture.productController.Get(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okObjectResult = (OkObjectResult)result;
            Assert.NotNull(okObjectResult);

            var model = (ProductDto)okObjectResult.Value;
            Assert.NotNull(model);
            Assert.Equal(model.Code, _fixture.newProduct.Code);
        }

        [Fact]
        public async Task Get_ReturnsPaginatedDtoListOfProducts()
        {
            // Act
            var result = await _fixture.productController.Get(1, 1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okObjectResult = (OkObjectResult)result;
            Assert.NotNull(okObjectResult);

            var model = (PaginationDto<ProductDto>)okObjectResult.Value;
            Assert.NotNull(model);
            Assert.Equal(model.TotalCount, _fixture.paginationDto.TotalCount);
        }

        [Fact]
        public async Task Create_ReturnsProductDto()
        {
            // Act
            var result = await _fixture.productController.Create(_fixture.newProductDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okObjectResult = (OkObjectResult)result;
            Assert.NotNull(okObjectResult);

            var model = (ProductDto)okObjectResult.Value;
            Assert.NotNull(model);
            Assert.Equal(model.Code, _fixture.newProduct.Code);
        }

        [Fact]
        public async Task Edit_ReturnsOkResult()
        {
            // Act
            var result = await _fixture.productController.Edit(_fixture.newProductDto);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult()
        {
            // Act
            var result = await _fixture.productController.Delete(1);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
