﻿using AssignmentEcommerce_Backend.Models;
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
    public class CartsControllerTests : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public CartsControllerTests(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task UpdateCart_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = CartMapper.Get();

            var fileService = FileStorageService.IStorageService();

            var user = new User { Id = "IDUSER" };
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();

            var product = new Product { ProductId = "IDPRODUCT" };
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var cart = new Cart
            {
                CartId = Guid.NewGuid().ToString(),
                UserId = user.Id,
            };
            await dbContext.AddAsync(cart);
            await dbContext.SaveChangesAsync();

            var cartDetail = new CartDetail
            {
                CartDetailId = Guid.NewGuid().ToString(),
                CartId = cart.CartId,
                ProductId = product.ProductId,
                Quantity = 1,
            };
            await dbContext.AddAsync(cartDetail);
            await dbContext.SaveChangesAsync();

            var cartUpdateRequest = new CartUpdateRequest
            {
                CartDetailId = cartDetail.CartDetailId,
                Quantity = 2
            };

            var cartController = new CartsController(dbContext, mapper, fileService);

            // Act
            var result = await cartController.UpdateCart(cartUpdateRequest);

            // Assert
            var postCartResult = Assert.IsType<ActionResult<CartRespond>>(result);
            var resultValue = Assert.IsType<CartRespond>(postCartResult.Value);

            Assert.Equal(cartUpdateRequest.CartDetailId, resultValue.CartDetailId);
            Assert.Equal(cartUpdateRequest.Quantity, resultValue.Quantity);
        }

        [Fact]
        public async Task RemoveCart_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = CartMapper.Get();

            var fileService = FileStorageService.IStorageService();

            var user = new User { Id = "IDUSER" };
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();

            var product = new Product { ProductId = "IDPRODUCT" };
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var cart = new Cart
            {
                CartId = Guid.NewGuid().ToString(),
                UserId = user.Id,
            };
            await dbContext.AddAsync(cart);
            await dbContext.SaveChangesAsync();

            var cartDetail = new CartDetail
            {
                CartDetailId = Guid.NewGuid().ToString(),
                CartId = cart.CartId,
                ProductId = product.ProductId,
                Quantity = 1,
            };
            await dbContext.AddAsync(cartDetail);
            await dbContext.SaveChangesAsync();

            var cartController = new CartsController(dbContext, mapper, fileService);

            // Act
            var result = await cartController.RemoveCart(cartDetail.CartDetailId);

            // Assert
            var postCartResult = Assert.IsType<ActionResult<CartRespond>>(result);
            var resultValue = Assert.IsType<CartRespond>(postCartResult.Value);

            Assert.Equal(cartDetail.CartDetailId, resultValue.CartDetailId);
            Assert.Equal(cartDetail.Quantity, resultValue.Quantity);
        }
    }
}
