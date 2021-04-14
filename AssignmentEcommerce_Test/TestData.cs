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
            Name = "Name Product Test Update",
            Description = "Description Product Test Update",
            Price = 2000000,
            UpdatedDate = DateTime.Now.Date,
            CategoryId = "IdCategory"
        };
    }
}
