using System.Collections.Generic;
using System.Text.Json;
using Entities.DTO.Cart;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
    public class LayoutCart:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cartString = Request.Cookies["basket"]?.ToString();
            List<CartDTO> cart = new List<CartDTO>(); 
            if(!string.IsNullOrEmpty(cartString))
                cart = JsonSerializer.Deserialize<List<CartDTO>>(cartString);
            
            return View(cart);
        }
    }
}