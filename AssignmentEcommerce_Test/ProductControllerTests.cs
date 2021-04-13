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
    public class ProductControllerTests : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public ProductControllerTests(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task GetProduct_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = ProductMapper.Get();

            var fileService = FileStorageService.IStorageService();

            var category = new Category
            {
                CategoryId = Guid.NewGuid().ToString(),
                NameCategory = "Name Category Test",
                Description = "Description Category Test",
                Images = "noimage.png"
            };
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                Name = "Name Product Test",
                Description = "Description Product Test",
                Images = "noimage.png",
                Price = 100000,
                CreatedDate = DateTime.Now.Date,
                UpdatedDate = DateTime.Now.Date,
                CategoryId = category.CategoryId,
                Rating = 5
            };
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var productController = new ProductController(dbContext, mapper, fileService);

            // Act
            var result = await productController.GetProduct();

            // Assert
            var postProductResult = Assert.IsAssignableFrom<IEnumerable<ProductVm>>(result);
            Assert.NotEmpty(postProductResult);
        }

        [Fact]
        public async Task GetProductById_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = ProductMapper.Get();

            var fileService = FileStorageService.IStorageService();

            var category = new Category
            {
                CategoryId = Guid.NewGuid().ToString(),
                NameCategory = "Name Category Test",
                Description = "Description Category Test",
                Images = "noimage.png"
            };
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                Name = "Name Product Test",
                Description = "Description Product Test",
                Images = "noimage.png",
                Price = 100000,
                CreatedDate = DateTime.Now.Date,
                UpdatedDate = DateTime.Now.Date,
                CategoryId = category.CategoryId,
                Rating = 5
            };
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var productController = new ProductController(dbContext, mapper, fileService);

            // Act
            var result = await productController.GetProductById(product.ProductId);

            // Assert
            var postProductResult = Assert.IsType<ActionResult<ProductVm>>(result);
            var resultValue = Assert.IsType<ProductVm>(postProductResult.Value);

            Assert.Equal("Name Product Test", resultValue.Name);
            Assert.Equal("Description Product Test", resultValue.Description);
            Assert.Equal(100000, resultValue.Price);
            Assert.Equal(5, resultValue.Rating);
            Assert.Equal(category.CategoryId, resultValue.CategoryId);
            Assert.Equal(category.NameCategory, resultValue.NameCategory);
        }

        [Fact]
        public async Task GetProductByCategory_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = ProductMapper.Get();

            var fileService = FileStorageService.IStorageService();

            var category = new Category
            {
                CategoryId = Guid.NewGuid().ToString(),
                NameCategory = "Name Category Test",
                Description = "Description Category Test",
                Images = "noimage.png"
            };
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                Name = "Name Product Test",
                Description = "Description Product Test",
                Images = "noimage.png",
                Price = 100000,
                CreatedDate = DateTime.Now.Date,
                UpdatedDate = DateTime.Now.Date,
                CategoryId = category.CategoryId,
                Rating = 5
            };
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var productController = new ProductController(dbContext, mapper, fileService);

            // Act
            var result = await productController.GetProductByCategory(category.CategoryId);

            // Assert
            var postProductResult = Assert.IsAssignableFrom<IEnumerable<ProductVm>>(result);
            Assert.NotEmpty(postProductResult);
        }

        [Fact]
        public async Task PostProduct_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = ProductMapper.Get();

            var fileService = FileStorageService.IStorageService();

            var category = new Category
            {
                CategoryId = Guid.NewGuid().ToString(),
                NameCategory = "Name Category Test",
                Description = "Description Category Test",
                Images = "noimage.png"
            };
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();

            var productCreateRequest = new ProductCreateRequest
            {
                Name = "Name Product Test",
                Description = "Description Product Test",
                Price = 100000,
                Images = null,
                CreatedDate = DateTime.Now.Date,
                CategoryId = category.CategoryId,
            };

            var productController = new ProductController(dbContext, mapper, fileService);

            // Act
            var result = await productController.PostProduct(productCreateRequest);

            // Assert
            var postProductResult = Assert.IsType<ActionResult<ProductVm>>(result);
            var resultValue = Assert.IsType<ProductVm>(postProductResult.Value);

            Assert.Equal("Name Product Test", resultValue.Name);
            Assert.Equal("Description Product Test", resultValue.Description);
            Assert.Equal(100000, resultValue.Price);
            Assert.Equal("noimage.png", resultValue.Images);
            Assert.Equal(category.CategoryId, resultValue.CategoryId);
            Assert.Equal("Name Category Test", resultValue.NameCategory);
            Assert.Equal(0, resultValue.Rating);
        }

        [Fact]
        public async Task PutProduct_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = ProductMapper.Get();

            var fileService = FileStorageService.IStorageService();

            var category = new Category
            {
                CategoryId = Guid.NewGuid().ToString(),
                NameCategory = "Name Category Test",
                Description = "Description Category Test",
                Images = "noimage.png"
            };
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                Name = "Name Product Test",
                Description = "Description Product Test",
                Images = "noimage.png",
                Price = 100000,
                CreatedDate = DateTime.Now.Date,
                UpdatedDate = DateTime.Now.Date,
                CategoryId = category.CategoryId,
                Rating = 5
            };
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var productUpdateRequest = new ProductUpdateRequest
            {
                Name = "Name Product Test Update",
                Description = "Description Product Test Update",
                Price = 2000000,
                UpdatedDate = DateTime.Now.Date,
                CategoryId = category.CategoryId,
            };

            var productController = new ProductController(dbContext, mapper, fileService);

            // Act
            var result = await productController.PutProduct(product.ProductId, productUpdateRequest);

            // Assert
            var postProductResult = Assert.IsType<ActionResult<ProductVm>>(result);
            var resultValue = Assert.IsType<ProductVm>(postProductResult.Value);

            Assert.Equal("Name Product Test Update", resultValue.Name);
            Assert.Equal("Description Product Test Update", resultValue.Description);
            Assert.Equal(2000000, resultValue.Price);
            Assert.Equal(category.CategoryId, resultValue.CategoryId);
            Assert.Equal("Name Category Test", resultValue.NameCategory);
            Assert.Equal(5, resultValue.Rating);
        }

        [Fact]
        public async Task DeleteProduct_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = ProductMapper.Get();

            var fileService = FileStorageService.IStorageService();

            var category = new Category
            {
                CategoryId = Guid.NewGuid().ToString(),
                NameCategory = "Name Category Test",
                Description = "Description Category Test",
                Images = "noimage.png"
            };
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();

            var product = new Product
            {
                ProductId = Guid.NewGuid().ToString(),
                Name = "Name Product Test",
                Description = "Description Product Test",
                Images = "noimage.png",
                Price = 100000,
                CreatedDate = DateTime.Now.Date,
                UpdatedDate = DateTime.Now.Date,
                CategoryId = category.CategoryId,
                Rating = 5
            };
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var productController = new ProductController(dbContext, mapper, fileService);

            // Act
            var result = await productController.DeleteProduct(product.ProductId);

            // Assert
            var postProductResult = Assert.IsType<ActionResult<ProductVm>>(result);
            var resultValue = Assert.IsType<ProductVm>(postProductResult.Value);

            Assert.Equal("Name Product Test", resultValue.Name);
            Assert.Equal("Description Product Test", resultValue.Description);
            Assert.Equal(100000, resultValue.Price);
        }
    }
}
