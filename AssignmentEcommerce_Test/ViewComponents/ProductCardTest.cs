using AssignmentEcommerce_CustomerSite.ViewComponents;
using AssignmentEcommerce_Shared;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Threading.Tasks;
using Xunit;

namespace AssignmentEcommerce_Test.ViewComponents
{
    public class ProductCardTest : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public ProductCardTest(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task ProductCard_ShouldReturns_NotNullView()
        {
            //Arrange
            var product = TestData.ProductVmTestData();

            var viewComponent = new ProductCardViewComponent();

            //Act
            var result = await viewComponent.InvokeAsync(product) as ViewViewComponentResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ProductCard_ShouldReturns_CorrectModelType()
        {
            //Arrange
            var product = TestData.ProductVmTestData();

            var viewComponent = new ProductCardViewComponent();

            //Act
            var result = await viewComponent.InvokeAsync(product) as ViewViewComponentResult;

            //Assert
            Assert.IsType<ProductVm>(result?.ViewData.Model);
        }

        [Fact]
        public async Task ProductCard_ShouldReturns_CorrectViewType()
        {
            //Arrange
            var product = TestData.ProductVmTestData();

            var viewComponent = new ProductCardViewComponent();

            //Act
            var result = await viewComponent.InvokeAsync(product) as ViewViewComponentResult;

            //Assert
            Assert.IsType<ViewViewComponentResult>(result);
        }

        [Fact]
        public async Task ProductCard_ShouldReturns_CorrectViewName()
        {
            //Arrange
            var product = TestData.ProductVmTestData();

            var viewComponent = new ProductCardViewComponent();

            //Act
            var result = await viewComponent.InvokeAsync(product) as ViewViewComponentResult;

            //Assert
            Assert.Equal("Default", result?.ViewName);
        }
    }
}
