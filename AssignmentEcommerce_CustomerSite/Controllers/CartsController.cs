﻿using AssignmentEcommerce_CustomerSite.Services;
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
    }
}
