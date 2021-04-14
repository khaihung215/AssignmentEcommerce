using AssignmentEcommerce_CustomerSite.Services;
using AssignmentEcommerce_CustomerSite.ViewComponents;
using AssignmentEcommerce_Shared;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AssignmentEcommerce_Test.ViewComponents
{
    public class CategoryMenu : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public CategoryMenu(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task CategoryMenu_ShouldReturns_NotNullView()
        {
            //Arrange
            var _categoryApiClient = Mock.Of<ICategoryApiClient>();

            var viewComponent = new CategoryMenuViewComponent(_categoryApiClient);

            //Act
            var result = await viewComponent.InvokeAsync() as ViewViewComponentResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CategoryMenu_ShouldReturns_CorrectViewType()
        {
            //Arrange
            var _categoryApiClient = Mock.Of<ICategoryApiClient>();

            var viewComponent = new CategoryMenuViewComponent(_categoryApiClient);

            //Act
            var result = await viewComponent.InvokeAsync() as ViewViewComponentResult;

            //Assert
            Assert.IsType<ViewViewComponentResult>(result);
        }
    }
}
