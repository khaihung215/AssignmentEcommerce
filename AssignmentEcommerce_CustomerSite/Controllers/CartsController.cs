using AssignmentEcommerce_CustomerSite.Services;
using AssignmentEcommerce_Shared;
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
            ViewBag.Total = carts.Sum(x => x.Price * x.Quantity);
            ViewBag.TotalItem = carts.Count();

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddToCart(string productId, int quantity)
        {
            var cartItem = new CartCreateRequest
            {
                ProductId = productId,
                Quantity = quantity
            };

            await _cartApiClient.PostCart(cartItem);

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RemoveCart(string id)
        {
            await _cartApiClient.RemoveCart(id);

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateCart(string cartDetailId, int quantity)
        {
            var cartItem = new CartUpdateRequest
            {
                CartDetailId = cartDetailId,
                Quantity = quantity
            };

            await _cartApiClient.UpdateCart(cartItem);

            return RedirectToAction("Index");
        }
    }
}
