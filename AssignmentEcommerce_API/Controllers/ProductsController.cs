using AssignmentEcommerce_API.Data;
using AssignmentEcommerce_API.Models;
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

        [HttpPost]
        public async Task<ActionResult> Create(ProductFormVm model)
        {
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Images = model.Images,
                CreatedDate = DateTime.Now.Date,
                UpdatedDate = DateTime.Now.Date,
                CategoryId = model.CategoryId
            };

            _shopDbContext.Products.Add(product);
            await _shopDbContext.SaveChangesAsync();

            return Accepted();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ProductFormVm model)
        {
            var product = await _shopDbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = model.Name;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Images = model.Images;
            product.UpdatedDate = DateTime.Now.Date;

            await _shopDbContext.SaveChangesAsync();
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _shopDbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            _shopDbContext.Products.Remove(product);

            await _shopDbContext.SaveChangesAsync();
            return Accepted();
        }
    }
}
