using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO.Cart;
using Entities.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Helpers;
using UI.Models;
using UI.Models.Cart;
using UI.Models.OrderListViewComponent;

namespace UI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserAddressService _userAddressService;
        private readonly IOrderService _orderService;
        public CartController(IProductService productService, IUserAddressService userAddressService, IOrderService orderService)
        {
            _productService = productService;
            _userAddressService = userAddressService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Basket()
        {
            var cartString = Request.Cookies["basket"]?.ToString();
            if (String.IsNullOrEmpty(cartString))
            {
                TempData["ToastMessage"] = ToastModel<bool>.Fail("Sepetinizde Ürün Bulunmuyor !");
                return RedirectToAction(nameof(Index), "Home");
            }
            int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
            CreateOrderDto createOrderDto = new CreateOrderDto();
            createOrderDto.UserAddresses = await _userAddressService.GetListAsync(userId);
            return View(createOrderDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Basket(CreateOrderDto createOrderDto)
        {
            if (!ModelState.IsValid)
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                createOrderDto.UserAddresses = await _userAddressService.GetListAsync(userId);
                return View(createOrderDto);
            }
            var cartString = Request.Cookies["basket"]?.ToString();
            List<CartDTO> cart = JsonSerializer.Deserialize<List<CartDTO>>(cartString);
            Order result = await _orderService.CreateOrder(cart, createOrderDto);

            if (result.Id != 0)
                TempData["ToastModel"] = result.Id.ToString();
            else
                TempData["ToastModel"] = "Bir Hata ile karşılaşıldı !";
            return RedirectToAction(nameof(PaymentResult), "Cart");
        }

        [HttpGet]
        public IActionResult PaymentResult()
        {
            // if (TempData["ToastModel"] == null)
            //     return RedirectToAction("MyOrders", "Profil");
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> AddToCart(AddToCartModel model)
        {
            List<CartDTO> cart = await SetCookie(model);
            return Json(new { totalPrice = cart.Sum(x => x.Quantity * x.TotalUnitPrice), CartCount = cart.Sum(x => x.Quantity) });
        }

        private async Task<List<CartDTO>> SetCookie(AddToCartModel model)
        {
            var cartString = Request.Cookies["basket"]?.ToString();
            List<CartDTO> cart;
            if (!string.IsNullOrEmpty(cartString))
                cart = JsonSerializer.Deserialize<List<CartDTO>>(cartString);
            else
                cart = new List<CartDTO>();

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
                product.ProductImages = null;
                product.ProductDemands = null;
                CartDTO cartModel = CartHelper.NewCartItem(product, model);
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

        public async Task<JsonResult> ChangeOrderStatus(int orderId)
        {
            Order order = await _orderService.GetOrderAsync(orderId);
            order.OrderStatus++;
            await _orderService.UpdateAsync(order);
            ChangeOrderStatusResponseModel responseModel = new ChangeOrderStatusResponseModel
            {
                Order = order,
                OrderListPanelInformation = OrderListHelper.GetOrderListPanelInformation((OrderStatusEnum)order.OrderStatus)
            };
            return Json(responseModel);
        }
    }
}