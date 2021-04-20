using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UI.Models.Cart;

namespace UI.ViewComponents
{
    public class BasketView : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string cartString = Request.Cookies["basket"]?.ToString();
            List<CartModel> cartModel = new List<CartModel>();

            if (!String.IsNullOrEmpty(cartString))
                cartModel = JsonSerializer.Deserialize<List<CartModel>>(cartString);

            return View(cartModel);
        }
    }
}