using AssignmentEcommerce_Backend.Data;
using AssignmentEcommerce_Backend.Models;
using AssignmentEcommerce_Backend.Services;
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
    public class CartsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartsController(ApplicationDbContext context, IMapper mapper, IStorageService storageService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _storageService = storageService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("GetCart")]
        public async Task<IEnumerable<CartRespond>> GetCart()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var cart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId.Equals(userId));

            if (cart == null)
            {
                cart = new Cart
                {
                    CartId = Guid.NewGuid().ToString(),
                    UserId = userId,
                };

                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();
            }

            var cartDetails = await _context.CartDetails
                .Include(p => p.Product)
                .Where(p => p.CartId.Equals(cart.CartId))
                .AsNoTracking()
                .ToListAsync();

            var cartResponds = _mapper.Map<IEnumerable<CartRespond>>(cartDetails);

            foreach (var item in cartResponds)
            {
                item.Image = _storageService.GetFileUrl(item.Image);
            }

            return cartResponds;
        }

        [HttpPost("PostCart")]
        public async Task<ActionResult<CartDetail>> PostCart(CartCreateRequest cartCreateRequest)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var check = CheckUserCart(userId);

            if (check.Result == true)
            {
                var cart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId.Equals(userId));

                var cartDetail = new CartDetail
                {
                    CartDetailId = Guid.NewGuid().ToString(),
                    Quantity = cartCreateRequest.Quantity,
                    CartId = cart.CartId,
                    ProductId = cartCreateRequest.ProductId
                };

                await _context.CartDetails.AddAsync(cartDetail);
                await _context.SaveChangesAsync();

                return cartDetail;
            }
            else
            {
                var cart = new Cart
                {
                    CartId = Guid.NewGuid().ToString(),
                    UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value
                };

                await _context.Carts.AddAsync(cart);
                await _context.SaveChangesAsync();

                var cartDetail = new CartDetail
                {
                    CartDetailId = Guid.NewGuid().ToString(),
                    Quantity = cartCreateRequest.Quantity,
                    CartId = cart.CartId,
                    ProductId = cartCreateRequest.ProductId
                };

                await _context.CartDetails.AddAsync(cartDetail);
                await _context.SaveChangesAsync();

                return cartDetail;
            }
        }

        [HttpPut("UpdateCart")]
        public async Task<ActionResult<CartRespond>> UpdateCart(CartUpdateRequest cartUpdateRequest)
        {
            var cart = await _context.CartDetails.FindAsync(cartUpdateRequest.CartDetailId);

            if (cart == null)
            {
                return NotFound();
            }

            if (cartUpdateRequest.Quantity > 0)
            {
                cart.Quantity++;
            }
            else
            {
                if (cart.Quantity > 1)
                {
                    cart.Quantity--;
                }
            }

            await _context.SaveChangesAsync();

            var cartRes = _mapper.Map<CartRespond>(cart);

            return cartRes;
        }

        [HttpDelete("RemoveCart/{id}")]
        public async Task<ActionResult<CartRespond>> RemoveCart(string id)
        {
            var cart = await _context.CartDetails.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            _context.CartDetails.Remove(cart);
            await _context.SaveChangesAsync();

            var cartRes = _mapper.Map<CartRespond>(cart);

            return cartRes;
        }

        private async Task<bool> CheckUserCart(string userId)
        {
            var check = await _context.Carts.Where(x => x.UserId.Equals(userId)).ToListAsync();

            if (check.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        [HttpGet("GetCartItems")]
        [AllowAnonymous]
        public async Task<CartResponseModel<CartRespond>> GetCartItems()
        {
            var cartDetails = await _context.CartDetails
                .Include(p => p.Product)
                .Where(p => p.CartId.Equals("cart1"))
                .AsNoTracking()
                .ToListAsync();

            return new CartResponseModel<CartRespond>
            {
                TotalPrice = cartDetails.Sum(x => x.Product.Price * x.Quantity),
                TotalItems = cartDetails.Count(),
                Items = cartDetails.Select(x =>
                    new CartRespond
                    {
                        CartDetailId = x.CartDetailId,
                        ProductId = x.ProductId,
                        ProductName = x.Product.Name,
                        Price = x.Product.Price,
                        Quantity = x.Quantity,
                        Image = _storageService.GetFileUrl(x.Product.Images)
                    }
               ).ToList()
            };
        }

        [HttpPost("PostCartItems")]
        [AllowAnonymous]
        public async Task<ActionResult<CartDetail>> PostCartItems(CartCreateRequest cartCreateRequest)
        {
            var cart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId.Equals("user1"));

            var checkItem = await _context.CartDetails.FirstOrDefaultAsync(x => x.ProductId.Equals(cartCreateRequest.ProductId));

            if (checkItem == null)
            {
                var cartDetail = new CartDetail
                {
                    CartDetailId = Guid.NewGuid().ToString(),
                    Quantity = cartCreateRequest.Quantity,
                    CartId = cart.CartId,
                    ProductId = cartCreateRequest.ProductId
                };

                await _context.CartDetails.AddAsync(cartDetail);
                await _context.SaveChangesAsync();
                
                return cartDetail;
            }
            else
            {
                checkItem.Quantity++;
                await _context.SaveChangesAsync();

                return Ok();
            }
        }

        [HttpPut("UpdateCartItems")]
        [AllowAnonymous]
        public async Task<CartResponseModel<CartRespond>> UpdateCartItems(CartUpdateRequest cartUpdateRequest)
        {
            var cart = await _context.CartDetails.FindAsync(cartUpdateRequest.CartDetailId);

            if (cart == null)
            {
                return null;
            }

            if (cartUpdateRequest.Quantity > 0)
            {
                cart.Quantity++;
            }
            else
            {
                if (cart.Quantity > 1)
                {
                    cart.Quantity--;
                }
            }

            await _context.SaveChangesAsync();

            var cartDetails = await _context.CartDetails
                .Include(p => p.Product)
                .Where(p => p.CartId.Equals("cart1"))
                .AsNoTracking()
                .ToListAsync();

            return new CartResponseModel<CartRespond>
            {
                TotalPrice = cartDetails.Sum(x => x.Product.Price * x.Quantity),
                TotalItems = cartDetails.Count(),
                Items = cartDetails.Select(x =>
                    new CartRespond
                    {
                        CartDetailId = x.CartDetailId,
                        ProductId = x.ProductId,
                        ProductName = x.Product.Name,
                        Price = x.Product.Price,
                        Quantity = x.Quantity,
                        Image = _storageService.GetFileUrl(x.Product.Images)
                    }
               ).ToList()
            };
        }

        [HttpPut("RemoveCartItems")]
        [AllowAnonymous]
        public async Task<CartResponseModel<CartRespond>> RemoveCartItems(string id)
        {
            var cart = await _context.CartDetails.FindAsync(id);

            if (cart == null)
            {
                return null;
            }

            _context.CartDetails.Remove(cart);
            await _context.SaveChangesAsync();

            var cartDetails = await _context.CartDetails
                .Include(p => p.Product)
                .Where(p => p.CartId.Equals("cart1"))
                .AsNoTracking()
                .ToListAsync();

            return new CartResponseModel<CartRespond>
            {
                TotalPrice = cartDetails.Sum(x => x.Product.Price * x.Quantity),
                TotalItems = cartDetails.Count(),
                Items = cartDetails.Select(x =>
                    new CartRespond
                    {
                        CartDetailId = x.CartDetailId,
                        ProductId = x.ProductId,
                        ProductName = x.Product.Name,
                        Price = x.Product.Price,
                        Quantity = x.Quantity,
                        Image = _storageService.GetFileUrl(x.Product.Images)
                    }
               ).ToList()
            };
        }
    }
}
