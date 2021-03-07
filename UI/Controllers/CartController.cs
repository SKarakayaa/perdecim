using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Helpers;
using UI.Models.Cart;

namespace UI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        public CartController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<JsonResult> AddToCart(AddToCartModel model)
        {
            await SetCookie(model);
            return Json(true);
        }

        private async Task SetCookie(AddToCartModel model)
        {
            var cartString = Request.Cookies["basket"]?.ToString();
            List<CartModel> cart;
            if (!string.IsNullOrEmpty(cartString))
                cart = JsonSerializer.Deserialize<List<CartModel>>(cartString);
            else
                cart = new List<CartModel>();

            var existCartItem = cart.FirstOrDefault(x => x.ProductId == model.ProductId && model.DemandTypes.SequenceEqual(model.DemandTypes));
            if (existCartItem != null)
            {
                cart.Remove(existCartItem);
                existCartItem.Quantity += model.Quantity;
                cart.Add(existCartItem);
            }
            else
            {
                var product = (await _productService.GetByIdAsync(model.ProductId, new[] { "ProductDemands", "ProductDemands.DemandType", "ProductDemands.DemandType.Demands" })).Data;
                CartModel cartModel = CartHelper.NewCartItem(product, model);
                cart.Add(cartModel);
            }

            CookieOptions cookie = new CookieOptions()
            {
                Expires = DateTime.Now.AddHours(1),
                HttpOnly = false,
                SameSite = SameSiteMode.Lax,
                Secure = true
            };
            Response.Cookies.Append("basket", JsonSerializer.Serialize(cart), cookie);
        }
    }
}