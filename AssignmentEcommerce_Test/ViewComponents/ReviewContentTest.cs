using AssignmentEcommerce_CustomerSite.ViewComponents;
using AssignmentEcommerce_Shared;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Threading.Tasks;
using Xunit;

namespace AssignmentEcommerce_Test.ViewComponents
{
    public class ReviewContentTest : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public ReviewContentTest(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task ReviewContent_ShouldReturns_NotNullView()
        {
            //Arrange
            var review = TestData.ReviewVmTestData();

            var viewComponent = new ReviewContentViewComponent();

            //Act
            var result = await viewComponent.InvokeAsync(review) as ViewViewComponentResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ReviewContent_ShouldReturns_CorrectModelType()
        {
            //Arrange
            var review = TestData.ReviewVmTestData();

            var viewComponent = new ReviewContentViewComponent();

            //Act
            var result = await viewComponent.InvokeAsync(review) as ViewViewComponentResult;

            //Assert
            Assert.IsType<ReviewVm>(result?.ViewData.Model);
        }

        [Fact]
        public async Task ReviewContent_ShouldReturns_CorrectViewType()
        {
            //Arrange
            var review = TestData.ReviewVmTestData();

            var viewComponent = new ReviewContentViewComponent();

            //Act
            var result = await viewComponent.InvokeAsync(review) as ViewViewComponentResult;

            //Assert
            Assert.IsType<ViewViewComponentResult>(result);
        }

        [Fact]
        public async Task ReviewContent_ShouldReturns_CorrectViewName()
        {
            //Arrange
            var review = TestData.ReviewVmTestData();

            var viewComponent = new ReviewContentViewComponent();

            //Act
            var result = await viewComponent.InvokeAsync(review) as ViewViewComponentResult;

            //Assert
            Assert.Equal("Default", result?.ViewName);
        }
    }
}
