using AssignmentEcommerce_CustomerSite.ViewComponents;
using AssignmentEcommerce_Shared;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Threading.Tasks;
using Xunit;

namespace AssignmentEcommerce_Test.ViewComponents
{
    public class CartItemTest : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public CartItemTest(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task CartItem_ShouldReturns_NotNullView()
        {
            //Arrange
            var cartRespond = TestData.CartRespondTestData();

            var viewComponent = new CartItemViewComponent();

            //Act
            var result = await viewComponent.InvokeAsync(cartRespond) as ViewViewComponentResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CartItem_ShouldReturns_CorrectModelType()
        {
            //Arrange
            var cartRespond = TestData.CartRespondTestData();

            var viewComponent = new CartItemViewComponent();

            //Act
            var result = await viewComponent.InvokeAsync(cartRespond) as ViewViewComponentResult;

            //Assert
            Assert.IsType<CartRespond>(result?.ViewData.Model);
        }

        [Fact]
        public async Task CartItem_ShouldReturns_CorrectViewType()
        {
            //Arrange
            var cartRespond = TestData.CartRespondTestData();

            var viewComponent = new CartItemViewComponent();

            //Act
            var result = await viewComponent.InvokeAsync(cartRespond) as ViewViewComponentResult;

            //Assert
            Assert.IsType<ViewViewComponentResult>(result);
        }

        [Fact]
        public async Task CartItem_ShouldReturns_CorrectViewName()
        {
            //Arrange
            var cartRespond = TestData.CartRespondTestData();

            var viewComponent = new CartItemViewComponent();

            //Act
            var result = await viewComponent.InvokeAsync(cartRespond) as ViewViewComponentResult;

            //Assert
            Assert.Equal("Default", result?.ViewName);
        }
    }
}
