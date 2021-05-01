using System;
using System.Collections.Generic;
using System.Text.Json;
using Entities.DTO.Cart;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
    public class BasketView : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            string cartString = Request.Cookies["basket"]?.ToString();
            List<CartDTO> cartModel = new List<CartDTO>();

            if (!String.IsNullOrEmpty(cartString))
                cartModel = JsonSerializer.Deserialize<List<CartDTO>>(cartString);

            return View(cartModel);
        }
    }
}