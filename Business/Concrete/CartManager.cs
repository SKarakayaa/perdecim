using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Helpers;
using Core.Utilities.Results;
using Entities.DTO.Cart;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CartManager : ICartService
    {
        private readonly RedisManager _redisManager;
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartManager(RedisManager redisManager, IProductService productService, IHttpContextAccessor httpContextAccessor)
        {
            _redisManager = redisManager;
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IDataResult<CartDTO>> AddToCart(AddToCartDTO model)
        {
            var key = _httpContextAccessor.HttpContext.Request.Cookies["key"]?.ToString() ?? Guid.NewGuid().ToString();

            string existCart = await _redisManager.GetDb().StringGetAsync(key);
            CartDTO cart;
            if (!string.IsNullOrEmpty(existCart))
                cart = JsonSerializer.Deserialize<CartDTO>(existCart);
            else
                cart = new CartDTO();

            //! Sepette indirim etkinliğini bu satırda kontrol et ve cart'ta ki indirime apply et

            var existCartItem = cart.CartItems.FirstOrDefault(x => x.ProductId == model.ProductId && x.DemandTypes.SequenceEqual(model.DemandTypes));
            if (existCartItem != null)
            {
                cart.CartItems.Remove(existCartItem);
                existCartItem.Quantity += model.Quantity;
                cart.CartItems.Add(existCartItem);
            }
            else
            {
                var product = (await _productService.GetByIdAsync(model.ProductId)).Data;
                product.ProductDemands = null;
                CartItemDTO cartModel = CartHelper.NewCartItem(product, model);
                cart.CartItems.Add(cartModel);
            }

            TimeSpan expireCart = TimeSpan.FromMinutes(1);
            var status = await _redisManager.GetDb().StringSetAsync(key, JsonSerializer.Serialize(cart), expireCart);
            if (!status)
                cart = null;
            else
                _httpContextAccessor.HttpContext.Response.Cookies.Append("key", key, new CookieOptions
                {
                    Expires = DateTime.Now + expireCart,
                    HttpOnly = true,
                    SameSite = SameSiteMode.Lax,
                    Secure = true
                });
            return ResultHelper<CartDTO>.DataResultReturn(cart);
        }
        public async Task<IDataResult<CartDTO>> GetCart()
        {
            string key = _httpContextAccessor.HttpContext.Request.Cookies["key"]?.ToString() ?? "";
            string existCart = await _redisManager.GetDb().StringGetAsync(key);

            CartDTO cart = string.IsNullOrEmpty(existCart) ? null : JsonSerializer.Deserialize<CartDTO>(existCart);
            return ResultHelper<CartDTO>.DataResultReturn(cart);
        }
    }
}