﻿using AssignmentEcommerce_CustomerSite.Services;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> Index()
        {
            var products = await _productClient.GetProduct();
            ViewBag.Products = products;

            var categorys = await _categoryClient.GetCategory();
            ViewBag.Categorys = categorys;

            return View();
        }

        public async Task<IActionResult> Detail(string id)
        {
            var product = await _productClient.GetProductById(id);

            var productsSameCate = await _productClient.GetProductSameCategory(id);
            ViewBag.ProductsSameCate = productsSameCate;

            return View(product);
        }
    }
}
