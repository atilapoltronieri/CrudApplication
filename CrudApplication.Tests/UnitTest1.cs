using Xunit;

namespace CrudApplication.Tests
{
    public class UnitTest1 : IClassFixture<BaseFixture>
    {
        private readonly BaseFixture _fixture;

        public UnitTest1(BaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void TestMethod1()
        {

        }
    }
}