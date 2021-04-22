using AssignmentEcommerce_Backend.Models;
using AssignmentEcommerce_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentEcommerce_Test
{
    public static class TestData
    {
        public static Category CateTestData() => new Category
        {
            CategoryId = "IdCategory",
            NameCategory = "Name Category Test",
            Description = "Description Category Test",
            Images = "noimage.png"
        };

        public static CategoryCreateRequest CateCreateTestData() => new CategoryCreateRequest
        {
            NameCategory = "Name Category Test New",
            Description = "Description Category Test New",
            ThumbnailImages = null
        };

        public static Product ProductTestData() => new Product
        {
            ProductId = "IdProduct",
            Name = "Name Product Test",
            Description = "Description Product Test",
            Images = "noimage.png",
            Price = 100000,
            CreatedDate = DateTime.Now.Date,
            UpdatedDate = DateTime.Now.Date,
            CategoryId = "IdCategory",
            Rating = 5
        };

        public static ProductVm ProductVmTestData() => new ProductVm
        {
            ProductId = "IdProduct",
            Name = "Name Product Test",
            Description = "Description Product Test",
            Images = "noimage.png",
            Price = 100000,
            CategoryId = "IdCategory",
            NameCategory = "Name Category Test",
            Rating = 5
        };

        public static ProductCreateRequest ProductCreateTestData() => new ProductCreateRequest
        {
            Name = "Name Product Test",
            Description = "Description Product Test",
            Price = 100000,
            Images = null,
            CreatedDate = DateTime.Now.Date,
            CategoryId = "IdCategory"
        };

        public static ProductUpdateRequest ProductUpdateTestData() => new ProductUpdateRequest
        {
            ProductId = "IdProduct",
            Name = "Name Product Test Update",
            Description = "Description Product Test Update",
            Price = 2000000,
            UpdatedDate = DateTime.Now.Date,
            CategoryId = "IdCategory"
        };

        public static Review ReviewTestData() => new Review
        {
            ReviewId = "IdReview",
            Content = "Content Test",
            Rating = 5,
            ProductId = "IdProduct",
            UserId = "IdUser",
            UserName = "Khai Hung",
            DateReview = DateTime.Now.Date
        };

        public static ReviewVm ReviewVmTestData() => new ReviewVm
        {
            ReviewId = "IdReview",
            Content = "Content Test",
            Rating = 5,
            ProductId = "IdProduct",
            UserId = "IdUser",
            UserName = "Khai Hung",
            DateReview = DateTime.Now.Date
        };

        public static ReviewFormRequest ReviewFormTestData() => new ReviewFormRequest
        {
            Content = "Content Test",
            Rating = 5,
            ProductId = "IdProduct",
            UserName = "Khai Hung"
        };

        public static CartRespond CartRespondTestData() => new CartRespond
        {
            CartDetailId = "IdCartDetail",
            ProductId = "IdProduct",
            ProductName = "Name Product",
            Price = 100000,
            Quantity = 1,
            Image = "noimage.png"
        };
    }
}
