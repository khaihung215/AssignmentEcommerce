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
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStorageService _storageService;
        private IMapper _mapper;

        public CategoriesController(ApplicationDbContext context, IMapper mapper, IStorageService storageService)
        {
            _context = context;
            _mapper = mapper;
            _storageService = storageService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<CategoryVm>> GetCategory()
        {
            var category = await _context.Categories.ToListAsync();

            foreach (var item in category)
            {
                item.Images = _storageService.GetFileUrl(item.Images);
            }

            var categoryRes = _mapper.Map<IEnumerable<CategoryVm>>(category);

            return categoryRes;
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryVm>> GetCategory(string id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            category.Images = _storageService.GetFileUrl(category.Images);

            var categoryVm = _mapper.Map<CategoryVm>(category);

            return categoryVm;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<CategoryVm>> PutCategory(string id,[FromForm] CategoryCreateRequest categoryCreateRequest)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            if (categoryCreateRequest.ThumbnailImages != null)
            {
                category.Images = await SaveFile(categoryCreateRequest.ThumbnailImages);
            }

            _context.Entry<Category>(category).CurrentValues.SetValues(categoryCreateRequest);

            await _context.SaveChangesAsync();

            var categoryRes = _mapper.Map<CategoryVm>(category);

            return categoryRes;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<CategoryVm>> PostCategory([FromForm] CategoryCreateRequest categoryCreateRequest)
        {
            var category = _mapper.Map<Category>(categoryCreateRequest);
            category.CategoryId = Guid.NewGuid().ToString();

            if (categoryCreateRequest.ThumbnailImages != null)
            {
                category.Images = await SaveFile(categoryCreateRequest.ThumbnailImages);
            }
            else
            {
                category.Images = "noimage.png";
            }

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            var categoryRes = _mapper.Map<CategoryVm>(category);
            return categoryRes;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
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
