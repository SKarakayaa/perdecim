using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTO.Cart;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
    public class LayoutCart : ViewComponent
    {
        private readonly ICartService _cartService;
        public LayoutCart(ICartService cartService) => _cartService = cartService;
        public async Task<IViewComponentResult> InvokeAsync()
        {
            IDataResult<CartDTO> cart = await _cartService.GetCart();

            return View(cart);
        }
    }
}