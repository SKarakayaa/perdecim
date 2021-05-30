using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Config;
using Entities.DTO.Cart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace UI.ViewComponents
{
    public class BasketView : ViewComponent
    {
        private readonly ICartService _cartService;
        public BasketView(ICartService cartService) => _cartService = cartService;
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IDataResult<CartDTO> cart = await _cartService.GetCart();
            return View(cart);
        }
    }
}