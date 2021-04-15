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
    public class CategoryMenuTest : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public CategoryMenuTest(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task CategoryMenu_ShouldReturns_NotNullView()
        {
            //Arrange
            IList<CategoryVm> cateList = new List<CategoryVm>();

            var category = new CategoryVm
            {
                CategoryId = "IdCategory",
                NameCategory = "Name Category",
                Description = "Description Category",
                Images = "noimage.png"
            };

            cateList.Add(category);

            var _categoryApiClient = new Mock<ICategoryApiClient>();
            _categoryApiClient.Setup(x => x.GetCategory().Result).Returns((cateList));

            var viewComponent = new CategoryMenuViewComponent(_categoryApiClient.Object);

            //Act
            var result = await viewComponent.InvokeAsync() as ViewViewComponentResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CategoryMenu_ShouldReturns_CorrectViewType()
        {
            //Arrange
            IList<CategoryVm> cateList = new List<CategoryVm>();

            var category = new CategoryVm
            {
                CategoryId = "IdCategory",
                NameCategory = "Name Category",
                Description = "Description Category",
                Images = "noimage.png"
            };

            cateList.Add(category);

            var _categoryApiClient = new Mock<ICategoryApiClient>();
            _categoryApiClient.Setup(x => x.GetCategory().Result).Returns((cateList));

            var viewComponent = new CategoryMenuViewComponent(_categoryApiClient.Object);

            //Act
            var result = await viewComponent.InvokeAsync() as ViewViewComponentResult;

            //Assert
            Assert.IsType<ViewViewComponentResult>(result);
        }

        [Fact]
        public async Task CategoryMenu_ShouldReturns_CorrectModelType()
        {
            //Arrange
            IList<CategoryVm> cateList = new List<CategoryVm>();

            var category = new CategoryVm
            {
                CategoryId = "IdCategory",
                NameCategory = "Name Category",
                Description = "Description Category",
                Images = "noimage.png"
            };

            cateList.Add(category);

            var _categoryApiClient = new Mock<ICategoryApiClient>();
            _categoryApiClient.Setup(x => x.GetCategory().Result).Returns((cateList));

            var viewComponent = new CategoryMenuViewComponent(_categoryApiClient.Object);

            //Act
            var result = await viewComponent.InvokeAsync() as ViewViewComponentResult;

            //Assert
            Assert.IsAssignableFrom<IList<CategoryVm>>(result?.ViewData.Model);
        }

        [Fact]
        public async Task CategoryMenu_ShouldReturns_CorrectViewName()
        {
            //Arrange
            IList<CategoryVm> cateList = new List<CategoryVm>();

            var category = new CategoryVm
            {
                CategoryId = "IdCategory",
                NameCategory = "Name Category",
                Description = "Description Category",
                Images = "noimage.png"
            };

            cateList.Add(category);

            var _categoryApiClient = new Mock<ICategoryApiClient>();
            _categoryApiClient.Setup(x => x.GetCategory().Result).Returns((cateList));

            var viewComponent = new CategoryMenuViewComponent(_categoryApiClient.Object);

            //Act
            var result = await viewComponent.InvokeAsync() as ViewViewComponentResult;

            //Assert
            Assert.Equal("Default", result?.ViewName);
        }
    }
}
