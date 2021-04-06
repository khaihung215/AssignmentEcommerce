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
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private IMapper _mapper;

        public CategoriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<CategoryVm>> GetCategory()
        {
            var category = await _context.Categories.ToListAsync();

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

            var categoryVm = _mapper.Map<CategoryVm>(category);

            return categoryVm;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<CategoryCreateRequest>> PutCategory(string id, CategoryCreateRequest categoryCreateRequest)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Entry<Category>(category).CurrentValues.SetValues(categoryCreateRequest);

            await _context.SaveChangesAsync();

            var categoryRes = _mapper.Map<CategoryCreateRequest>(category);

            return categoryRes;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<CategoryVm>> PostCategory(CategoryCreateRequest categoryCreateRequest)
        {
            var category = _mapper.Map<Category>(categoryCreateRequest);
            category.CategoryId = Guid.NewGuid().ToString();

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
    }
}
