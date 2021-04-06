using AssignmentEcommerce_Backend.Data;
using AssignmentEcommerce_Backend.Models;
using AssignmentEcommerce_Shared;
using AutoMapper;
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
        private IMapper _mapper;

        public ProductController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ProductVm>> GetProduct()
        {
            var product = await _context.Products.ToListAsync();

            var productRes = _mapper.Map<IEnumerable<ProductVm>>(product);

            return productRes;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductVm>> GetProduct(string id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var productVm = _mapper.Map<ProductVm>(product);

            return productVm;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ProductCreateRequest>> PutProduct(string id,[FromForm] ProductUpdateRequest productUpdateRequest)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Entry<Product>(product).CurrentValues.SetValues(productUpdateRequest);
            product.UpdatedDate = DateTime.Now.Date;

            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductCreateRequest>(product);

            return productRes;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ProductVm>> PostProduct([FromForm] ProductCreateRequest productCreateRequest)
        {
            var product = _mapper.Map<Product>(productCreateRequest);
            product.ProductId = Guid.NewGuid().ToString();
            product.CreatedDate = DateTime.Now.Date;
            product.UpdatedDate = DateTime.Now.Date;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductVm>(product);
            return productRes;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteProduct(string id)
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
