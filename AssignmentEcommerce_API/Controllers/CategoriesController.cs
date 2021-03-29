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
    public class CategoriesController : ControllerBase
    {
        private readonly ShopDbContext _shopDbContext;

        public CategoriesController(ShopDbContext shopDbContext)
        {
            _shopDbContext = shopDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<CategoryVm>> Get()
        {
            var category = await _shopDbContext.Categories.Select(x => new CategoryVm
            {
                CategoryId = x.CategoryId,
                NameCategory = x.NameCategory,
                Description = x.Description
            }).ToListAsync();

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Create(CategoryFormVm model)
        {
            var category = new Category
            {
                NameCategory = model.NameCategory,
                Description = model.Description
            };

            _shopDbContext.Categories.Add(category);
            await _shopDbContext.SaveChangesAsync();

            return Accepted();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CategoryFormVm model)
        {
            var category = await _shopDbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            category.NameCategory = model.NameCategory;
            category.Description = model.Description;

            await _shopDbContext.SaveChangesAsync();
            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _shopDbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            _shopDbContext.Categories.Remove(category);

            await _shopDbContext.SaveChangesAsync();
            return Accepted();
        }
    }
}
