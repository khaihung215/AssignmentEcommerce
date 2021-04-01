using AssignmentEcommerce_Backend.Data;
using AssignmentEcommerce_Backend.Models;
using AssignmentEcommerce_Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentEcommerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductVm>>> GetProduct()
        {
            return await _context.Products
                .Select(x => new ProductVm
                {
                    ProductId = x.ProductId,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Images = x.Images
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductVm>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var productVm = new ProductVm
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Images = product.Images
            };

            return productVm;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutProduct(int id, ProductCreateRequest productCreateRequest)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            product.Name = productCreateRequest.Name;
            product.Price = productCreateRequest.Price;
            product.Description = productCreateRequest.Description;
            product.Images = productCreateRequest.Images;
            product.UpdatedDate = DateTime.Now.Date;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ProductVm>> PostProduct(ProductCreateRequest productCreateRequest)
        {
            var product = new Product
            {
                Name = productCreateRequest.Name,
                Description = productCreateRequest.Description,
                Price = productCreateRequest.Price,
                Images = productCreateRequest.Images,
                CreatedDate = DateTime.Now.Date,
                UpdatedDate = DateTime.Now.Date,
                CategoryId = productCreateRequest.CategoryId
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, new ProductVm
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Images = product.Images
            });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
