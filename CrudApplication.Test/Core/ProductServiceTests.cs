using CrudApplication.Test.Base;
using Xunit;
using Assert = Xunit.Assert;

namespace CrudApplication.Test.Core
{
    public class ProductServiceTestss(BaseFixture fixture) : IClassFixture<BaseFixture>
    {
        private readonly BaseFixture _fixture = fixture;

        [Fact]
        public async Task CreateProductAsync_ValidProduct_ReturnsCreatedProductViewModel()
        {
            // Act
            var result = await _fixture.productService.Create(_fixture.newProductDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result.Code, _fixture.newProductDto.Code);
            // Additional assertions for other properties
        }
    }
}
