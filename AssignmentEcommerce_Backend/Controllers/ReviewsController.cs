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
using System.Security.Claims;
using System.Threading.Tasks;

namespace AssignmentEcommerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ReviewsController(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetReviews/{id}")]
        [AllowAnonymous]
        public async Task<IEnumerable<ReviewVm>> GetReviews(string id)
        {
            var reviews = await _context.Reviews
                .Include(review => review.Product)
                .Where(review => review.ProductId.Equals(id))
                .AsNoTracking()
                .ToListAsync();

            var reviewRes = _mapper.Map<IEnumerable<ReviewVm>>(reviews);
            return reviewRes;
        }

        [HttpPost("PostReview")]
        public async Task<ActionResult<ReviewVm>> PostReview(ReviewFormRequest reviewFormRequest)
        {
            var review = _mapper.Map<Review>(reviewFormRequest);
            review.ReviewId = Guid.NewGuid().ToString();
            review.DateReview = DateTime.Now.Date;

            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("sub");
            review.UserId = userId;

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            var sumRating = _context.Reviews.Where(x => x.ProductId.Equals(review.ProductId)).Average(p => p.Rating);

            var product = await _context.Products.FindAsync(review.ProductId);
            product.Rating = Convert.ToInt32(sumRating);
            await _context.SaveChangesAsync();

            var reviewRes = _mapper.Map<ReviewVm>(review);
            return reviewRes;
        }
    }
}
