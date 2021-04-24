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
            List<CartModel> cart = await SetCookie(model);
            return Json(new { totalPrice = cart.Sum(x => x.Quantity * x.TotalUnitPrice), CartCount = cart.Sum(x => x.Quantity) });
        }

        private async Task<List<CartModel>> SetCookie(AddToCartModel model)
        {
            var cartString = Request.Cookies["basket"]?.ToString();
            List<CartModel> cart;
            if (!string.IsNullOrEmpty(cartString))
                cart = JsonSerializer.Deserialize<List<CartModel>>(cartString);
            else
                cart = new List<CartModel>();

            var existCartItem = cart.FirstOrDefault(x => x.ProductId == model.ProductId && x.DemandTypes.SequenceEqual(model.DemandTypes));
            if (existCartItem != null)
            {
                cart.Remove(existCartItem);
                existCartItem.Quantity += model.Quantity;
                cart.Add(existCartItem);
            }
            else
            {
                var product = (await _productService.GetByIdAsync(model.ProductId)).Data;
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
            return cart;
        }
    }
}