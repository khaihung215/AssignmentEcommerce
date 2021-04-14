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

            var product = new Product { ProductId = "IdProduct" };
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var user = new User { Id = "IdUser" };
            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();

            var review = TestData.ReviewTestData();
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
            mockHttpContextAccessor.Setup(x => x.HttpContext.User.FindFirst(It.IsAny<string>()))
            .Returns(new Claim("id", "IdUser"));

            var product = new Product { ProductId = "IdProduct" };
            await dbContext.AddAsync(product);
            await dbContext.SaveChangesAsync();

            var reviewFormRequest = TestData.ReviewFormTestData();

            var reviewController = new ReviewsController(dbContext, mapper, mockHttpContextAccessor.Object);

            // Act
            var result = await reviewController.PostReview(reviewFormRequest);

            // Assert
            var postReviewResult = Assert.IsType<ActionResult<ReviewVm>>(result);
            var resultValue = Assert.IsType<ReviewVm>(postReviewResult.Value);

            Assert.Equal("Content Test", resultValue.Content);
            Assert.Equal(5, resultValue.Rating);
            Assert.Equal("IdUser", resultValue.UserId);
            Assert.Equal("IdProduct", resultValue.ProductId);
            Assert.Equal("Khai Hung", resultValue.UserName);
        }
    }
}
