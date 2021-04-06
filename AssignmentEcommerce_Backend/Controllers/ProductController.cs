using AssignmentEcommerce_Backend.Data;
using AssignmentEcommerce_Backend.Models;
using AssignmentEcommerce_Backend.Services;
using AssignmentEcommerce_Shared;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AssignmentEcommerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStorageService _storageService;
        private IMapper _mapper;

        public ProductController(ApplicationDbContext context, IMapper mapper, IStorageService storageService)
        {
            _context = context;
            _mapper = mapper;
            _storageService = storageService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<ProductVm>> GetProduct()
        {
            var product = await _context.Products.ToListAsync();

            foreach(var item in product)
            {
                item.Images = _storageService.GetFileUrl(item.Images);
            }

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
        public async Task<ActionResult<ProductVm>> PutProduct(string id,[FromForm] ProductUpdateRequest productUpdateRequest)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }   

            if (productUpdateRequest.ThumbnailImages != null)
            {
                product.Images = await SaveFile(productUpdateRequest.ThumbnailImages);
            }

            _context.Entry(product).CurrentValues.SetValues(productUpdateRequest);
            product.UpdatedDate = DateTime.Now.Date;
            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductVm>(product);

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

            if (productCreateRequest.Images != null)
            {
                product.Images = await SaveFile(productCreateRequest.Images);
            }
            else
            {
                product.Images = "noimage.png";
            }

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

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }
    }
}
