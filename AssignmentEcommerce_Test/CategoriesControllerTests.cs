using AssignmentEcommerce_Backend.Models;
using AssignmentEcommerce_Test.Mapper;
using AssignmentEcommerce_Test.Services;
using System.Threading.Tasks;
using Xunit;
using AssignmentEcommerce_Shared;
using AssignmentEcommerce_Backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AssignmentEcommerce_Test
{
    public class CategoriesControllerTests : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public CategoriesControllerTests(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task PostCategory_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = CategoryMapper.Get();

            var fileService = FileStorageService.IStorageService();

            var categoryCreateRequest = new CategoryCreateRequest
            {
                NameCategory = "Name Category Test",
                Description = "Description Category Test",
                ThumbnailImages = null
            };

            var categoriesController = new CategoriesController(dbContext, mapper, fileService);

            // Act
            var result = await categoriesController.PostCategory(categoryCreateRequest);

            // Assert
            var postCategoryResult = Assert.IsType<ActionResult<CategoryVm>>(result);
            var resultValue = Assert.IsType<CategoryVm>(postCategoryResult.Value);

            Assert.Equal("Name Category Test", resultValue.NameCategory);
            Assert.Equal("Description Category Test", resultValue.Description);
            Assert.Equal("noimage.png", resultValue.Images);
        }

        [Fact]
        public async Task PutCategory_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = CategoryMapper.Get();

            var fileService = FileStorageService.IStorageService();

            var oldCategory = new Category
            {
                CategoryId = Guid.NewGuid().ToString(),
                NameCategory = "Name Category Test",
                Description = "Description Category Test",
                Images = "noimage.png"
            };
            await dbContext.AddAsync(oldCategory);
            await dbContext.SaveChangesAsync();

            var newCategory = new CategoryCreateRequest
            {
                NameCategory = "Name Category Test New",
                Description = "Description Category Test New",
                ThumbnailImages = null
            };

            var categoriesController = new CategoriesController(dbContext, mapper, fileService);

            // Act
            var result = await categoriesController.PutCategory(oldCategory.CategoryId, newCategory);

            // Assert
            var postCategoryResult = Assert.IsType<ActionResult<CategoryVm>>(result);
            var resultValue = Assert.IsType<CategoryVm>(postCategoryResult.Value);

            Assert.Equal("Name Category Test New", resultValue.NameCategory);
            Assert.Equal("Description Category Test New", resultValue.Description);
            Assert.Equal("noimage.png", resultValue.Images);
        }

        [Fact]
        public async Task GetCategory_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = CategoryMapper.Get();

            var fileService = FileStorageService.IStorageService();

            var newCategory = new Category
            {
                CategoryId = Guid.NewGuid().ToString(),
                NameCategory = "Name Category Test",
                Description = "Description Category Test",
                Images = "noimage.png"
            };
            await dbContext.AddAsync(newCategory);
            await dbContext.SaveChangesAsync();

            var categoriesController = new CategoriesController(dbContext, mapper, fileService);

            // Act
            var result = await categoriesController.GetCategory();

            // Assert
            var postCategoryResult = Assert.IsAssignableFrom<IEnumerable<CategoryVm>>(result);
            Assert.NotEmpty(postCategoryResult);
        }

        [Fact]
        public async Task GetCategoryById_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = CategoryMapper.Get();

            var fileService = FileStorageService.IStorageService();

            var newCategory = new Category
            {
                CategoryId = Guid.NewGuid().ToString(),
                NameCategory = "Name Category Test",
                Description = "Description Category Test",
                Images = "imageTest.png"
            };
            await dbContext.AddAsync(newCategory);
            await dbContext.SaveChangesAsync();

            var categoriesController = new CategoriesController(dbContext, mapper, fileService);

            // Act
            var result = await categoriesController.GetCategory(newCategory.CategoryId);

            // Assert
            var postCategoryResult = Assert.IsType<ActionResult<CategoryVm>>(result);
            var resultValue = Assert.IsType<CategoryVm>(postCategoryResult.Value);

            Assert.Equal("Name Category Test", resultValue.NameCategory);
            Assert.Equal("Description Category Test", resultValue.Description);
        }

        [Fact]
        public async Task DeleteCategory_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = CategoryMapper.Get();

            var fileService = FileStorageService.IStorageService();

            var newCategory = new Category
            {
                CategoryId = Guid.NewGuid().ToString(),
                NameCategory = "Name Category Test",
                Description = "Description Category Test",
                Images = "imageTest.png"
            };
            await dbContext.AddAsync(newCategory);
            await dbContext.SaveChangesAsync();

            var categoriesController = new CategoriesController(dbContext, mapper, fileService);

            // Act
            var result = await categoriesController.DeleteCategory(newCategory.CategoryId);

            // Assert
            var postCategoryResult = Assert.IsType<ActionResult<CategoryVm>>(result);
            var resultValue = Assert.IsType<CategoryVm>(postCategoryResult.Value);

            Assert.Equal("Name Category Test", resultValue.NameCategory);
            Assert.Equal("Description Category Test", resultValue.Description);
        }
    }
}
