using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using UI.Models.Cart;

namespace UI.ViewComponents
{
    public class LayoutCart:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cartString = Request.Cookies["basket"]?.ToString();
            List<CartModel> cart = new List<CartModel>(); 
            if(!string.IsNullOrEmpty(cartString))
                cart = JsonSerializer.Deserialize<List<CartModel>>(cartString);
            
            return View(cart);
        }
    }
}