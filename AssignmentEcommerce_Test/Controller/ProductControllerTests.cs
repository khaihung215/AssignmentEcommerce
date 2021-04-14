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

namespace AssignmentEcommerce_Test.Controller
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

            var category = TestData.CateTestData();
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();

            var product = TestData.ProductTestData();
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

            var category = TestData.CateTestData();
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();

            var product = TestData.ProductTestData();
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

            var category = TestData.CateTestData();
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();

            var product = TestData.ProductTestData();
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
        public async Task GetProductSameCategory_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = ProductMapper.Get();

            var fileService = FileStorageService.IStorageService();

            var category = TestData.CateTestData();
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();

            var product1 = TestData.ProductTestData();
            await dbContext.AddAsync(product1);
            await dbContext.SaveChangesAsync();

            var product2 = TestData.ProductTestData();
            product2.ProductId = "IdProduct2";
            await dbContext.AddAsync(product2);
            await dbContext.SaveChangesAsync();

            var productController = new ProductController(dbContext, mapper, fileService);

            // Act
            var result = await productController.GetProductSameCategory(product1.ProductId);

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

            var category = TestData.CateTestData();
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();

            var productCreateRequest = TestData.ProductCreateTestData();

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

            var category = TestData.CateTestData();
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();

            var product = TestData.ProductTestData();
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var productUpdateRequest = TestData.ProductUpdateTestData();

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

            var category = TestData.CateTestData();
            await dbContext.AddAsync(category);
            await dbContext.SaveChangesAsync();

            var product = TestData.ProductTestData();
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
