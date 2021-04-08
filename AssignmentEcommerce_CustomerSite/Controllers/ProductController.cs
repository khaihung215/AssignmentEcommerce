using AssignmentEcommerce_CustomerSite.Services;
using AssignmentEcommerce_Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentEcommerce_CustomerSite.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApiClient _productClient;
        private readonly ICategoryApiClient _categoryClient;

        public ProductController(IProductApiClient productClient, ICategoryApiClient categoryClient)
        {
            _productClient = productClient;
            _categoryClient = categoryClient;
        }

        public async Task<IActionResult> Index(string id)
        {
            if (id != null)
            {
                var productByCate = await _productClient.GetProductByCategory(id);
                ViewBag.Products = productByCate;
                ViewBag.SearchBy = productByCate[0].NameCategory;
            }
            else
            {
                var products = await _productClient.GetProduct();
                ViewBag.Products = products;
                ViewBag.SearchBy = "All products";
            }

            return View();
        }

        public async Task<IActionResult> Detail(string id)
        {
            var product = await _productClient.GetProductById(id);

            var reviews = await _productClient.GetReviews(id);
            ViewBag.ReviewsCount = reviews.Count();
            ViewBag.Reviews = reviews;

            var productsSameCate = await _productClient.GetProductSameCategory(id);
            ViewBag.ProductsSameCate = productsSameCate;

            return View(product);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostReview(string userName, int rating, string content, string productId)
        {
            var review = new ReviewFormRequest
            {
                UserName = userName,
                Content = content,
                Rating = rating,
                ProductId = productId,
            };

            await _productClient.PostReview(review);

            return RedirectToAction("Detail", new { id = productId });
        }
    }
}
