using CrudApplication.Test.Base;
using Xunit;
using Assert = Xunit.Assert;

namespace CrudApplication.Test.Infrastructure
{
    public class ProductRepositoryTests(BaseFixture fixture) : IClassFixture<BaseFixture>
    {
        private readonly BaseFixture _fixture = fixture;

        [Fact]
        public async Task AddAsync_ValidProduct_ReturnsAddedProduct()
        {
            // Act
            var result = await _fixture.productRepository.Create(_fixture.newProduct);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(result, _fixture.newProduct);
        }
    }
}
