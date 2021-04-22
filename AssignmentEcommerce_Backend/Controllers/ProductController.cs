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
        private readonly IMapper _mapper;

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
            var products = await _context.Products
                .Include(product => product.Category)
                .AsNoTracking()
                .ToListAsync();

            foreach (var item in products)
            {
                item.Images = _storageService.GetFileUrl(item.Images);
            }

            var productRes = _mapper.Map<IEnumerable<ProductVm>>(products);

            return productRes;
        }

        [HttpGet("GetProductById/{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductVm>> GetProductById(string id)
        {
            var product = await _context.Products
                .Include(products => products.Category)
                .Where(product => product.ProductId.Equals(id))
                .AsNoTracking()
                .SingleAsync();

            if (product == null)
            {
                return NotFound();
            }

            product.Images = _storageService.GetFileUrl(product.Images);

            var productVm = _mapper.Map<ProductVm>(product);
            productVm.NameCategory = product.Category.NameCategory;

            return productVm;
        }

        [HttpGet("GetProductSameCategory/{productId}")]
        [AllowAnonymous]
        public async Task<IEnumerable<ProductVm>> GetProductSameCategory(string productId)
        {
            var product = await _context.Products.FindAsync(productId);

            var productsSame = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId.Equals(product.CategoryId) && p.ProductId != product.ProductId)
                .AsNoTracking()
                .ToListAsync();

            foreach (var item in productsSame)
            {
                item.Images = _storageService.GetFileUrl(item.Images);
            }

            var productVm = _mapper.Map<IEnumerable<ProductVm>>(productsSame);

            return productVm;
        }

        [HttpGet("GetProductByCategory/{categoryId}")]
        [AllowAnonymous]
        public async Task<IEnumerable<ProductVm>> GetProductByCategory(string categoryId)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId.Equals(categoryId))
                .AsNoTracking()
                .ToListAsync();

            foreach (var item in products)
            {
                item.Images = _storageService.GetFileUrl(item.Images);
            }

            var productVm = _mapper.Map<IEnumerable<ProductVm>>(products);

            return productVm;
        }

        [HttpPut("{id}")]
        [AllowAnonymous]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<ProductVm>> PutProduct(string id, [FromForm] ProductUpdateRequest productUpdateRequest)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            if (productUpdateRequest.Images != null)
            {
                product.Images = await SaveFile(productUpdateRequest.Images);
            }

            product.Name = productUpdateRequest.Name;
            product.Description = productUpdateRequest.Description;
            product.Price = productUpdateRequest.Price;
            product.CategoryId = productUpdateRequest.CategoryId;
            product.UpdatedDate = DateTime.Now.Date;

            await _context.SaveChangesAsync();

            var productRes = _mapper.Map<ProductVm>(product);

            return productRes;
        }

        [HttpPost]
        [AllowAnonymous]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<ProductVm>> PostProduct([FromForm] ProductCreateRequest productCreateRequest)
        {
            var product = _mapper.Map<Product>(productCreateRequest);

            product.ProductId = Guid.NewGuid().ToString();
            product.CreatedDate = DateTime.Now.Date;
            product.UpdatedDate = DateTime.Now.Date;
            product.Rating = 0;

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
        [AllowAnonymous]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<ProductVm>> DeleteProduct(string id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var productRes = _mapper.Map<ProductVm>(product);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return productRes;
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
