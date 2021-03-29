using AssignmentEcommerce_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace AssignmentEcommerce_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ShopDbContext _shopDbContext;

        public ProductsController(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<ProductVm>> Get()
        {
            var products = await _shopDbContext.Products.Select(x => new ProductVm
            {
                ProductId = x.ProductId,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Images = x.Images
            }).ToListAsync();

            return Ok(products);
        }
    }
}
