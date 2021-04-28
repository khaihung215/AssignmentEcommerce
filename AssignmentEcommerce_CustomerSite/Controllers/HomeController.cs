using AssignmentEcommerce_CustomerSite.Models;
using AssignmentEcommerce_CustomerSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentEcommerce_CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryApiClient _categoryClient;
        private readonly IProductApiClient _productClient;

        public HomeController(ILogger<HomeController> logger, ICategoryApiClient categoryClient, IProductApiClient productClient)
        {
            _logger = logger;
            _categoryClient = categoryClient;
            _productClient = productClient;
        }

        public async Task<IActionResult> Index()
        {
            var categorys = await _categoryClient.GetCategory();
            ViewBag.Categorys = categorys;

            var hotProducts = await _productClient.GetHotProduct();
            ViewBag.HotProducts = hotProducts;

            var newProducts = await _productClient.GetNewProduct();
            ViewBag.NewProducts = newProducts;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
