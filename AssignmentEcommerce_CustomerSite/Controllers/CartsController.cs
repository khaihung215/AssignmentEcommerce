using AssignmentEcommerce_CustomerSite.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentEcommerce_CustomerSite.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartApiClient _cartApiClient;

        public CartsController(ICartApiClient cartApiClient)
        {
            _cartApiClient = cartApiClient;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var carts = await _cartApiClient.GetCart();
            ViewBag.Carts = carts;
            ViewBag.Total = carts.Sum(x => x.Price);
            ViewBag.TotalItem = carts.Count();

            return View();
        }
    }
}
