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

        public HomeController(ILogger<HomeController> logger, ICategoryApiClient productClient)
        {
            _logger = logger;
            _categoryClient = productClient;
        }

        public async Task<IActionResult> Index()
        {
            var categorys = await _categoryClient.GetCategory();
            ViewBag.Category = categorys;

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
