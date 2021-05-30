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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Helpers;
using UI.Models;
using UI.Models.Cart;

namespace UI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUserAddressService _userAddressService;
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        public CartController(IProductService productService, ICartService cartService, IUserAddressService userAddressService, IOrderService orderService)
        {
            _productService = productService;
            _userAddressService = userAddressService;
            _orderService = orderService;
            _cartService = cartService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Basket()
        {
            IDataResult<CartDTO> cart = await _cartService.GetCart();
            if (!cart.IsSuccess)
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
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Basket(CreateOrderDto createOrderDto)
        {
            if (!ModelState.IsValid)
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                createOrderDto.UserAddresses = await _userAddressService.GetListAsync(userId);
                return View(createOrderDto);
            }
            IDataResult<CartDTO> cart = await _cartService.GetCart();

            if (cart.IsSuccess)
            {
                Order result = await _orderService.CreateOrder(cart.Data, createOrderDto);

                if (result.Id != 0)
                    TempData["ToastModel"] = result.Id.ToString();
                else
                    TempData["ToastModel"] = "Bir Hata ile karşılaşıldı !";
            }
            else
            {
                TempData["ToastModel"] = "Sepette Ürün Bulunamadı !";
            }
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
        public async Task<JsonResult> AddToCart(AddToCartDTO model)
        {
            IDataResult<CartDTO> cart = await _cartService.AddToCart(model);

            //todo cart IsSuccess Kontrolü Yap
            return Json(new { totalPrice = cart.Data.CartTotal, CartCount = cart.Data.CartItemsCount });
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