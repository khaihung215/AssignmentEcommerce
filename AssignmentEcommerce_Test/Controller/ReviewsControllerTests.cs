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
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Moq;

namespace AssignmentEcommerce_Test.Controller
{
    public class ReviewsControllerTests : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;

        public ReviewsControllerTests(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task GetReview_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = ReviewMapper.Get();

            var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            mockHttpContextAccessor.Setup(o => o.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());

            var product = new Product { ProductId = "IDPRODUCT" };
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var user = new User { Id = "IDUSER" };
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();

            var review = new Review
            {
                ReviewId = Guid.NewGuid().ToString(),
                Content = "Content Test",
                Rating = 5,
                ProductId = "IDPRODUCT",
                UserId = "IDUSER",
                UserName = "Khai Hung",
                DateReview = DateTime.Now.Date
            };
            await dbContext.AddAsync(review);
            await dbContext.SaveChangesAsync();

            var reviewController = new ReviewsController(dbContext, mapper, mockHttpContextAccessor.Object);

            // Act
            var result = await reviewController.GetReviews(review.ProductId);

            // Assert
            var postReviewResult = Assert.IsAssignableFrom<IEnumerable<ReviewVm>>(result);
            Assert.NotEmpty(postReviewResult);
        }

        [Fact]
        public async Task PostReview_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            var mapper = ReviewMapper.Get();

            var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            mockHttpContextAccessor.Setup(o => o.HttpContext.User.Identity.Name).Returns(It.IsAny<string>());

            var product = new Product { ProductId = "IDPRODUCT" };
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var reviewFormRequest = new ReviewFormRequest
            {
                Content = "Content Test",
                Rating = 5,
                ProductId = "IDPRODUCT",
                UserName = "Khai Hung",
            };

            var reviewController = new ReviewsController(dbContext, mapper, mockHttpContextAccessor.Object);

            // Act
            var result = await reviewController.PostReview(reviewFormRequest);

            // Assert
            var postReviewResult = Assert.IsType<ActionResult<ReviewVm>>(result);
            var resultValue = Assert.IsType<ReviewVm>(postReviewResult.Value);

            Assert.Equal("Content Test", resultValue.Content);
            Assert.Equal(5, resultValue.Rating);
            Assert.Equal("IDPRODUCT", resultValue.ProductId);
            Assert.Equal("Khai Hung", resultValue.UserName);
        }
    }
}
