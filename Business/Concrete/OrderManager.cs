using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Helpers;
using Business.UnitOfWork;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO.Cart;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork _uow;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderManager(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Order> CreateOrder(List<CartDTO> basket, CreateOrderDto createOrder)
        {
            Order order = new Order();
            order.OrderDetails = new List<OrderDetail>();

            order.OrderDate = DateTime.Now;
            order.TotalPrice = basket.Sum(x => x.TotalUnitPrice * x.Quantity);
            order.UserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst("UserId").Value);
            order.AddressId = createOrder.AddressId;
            order.PaymentTypeId = createOrder.PaymentType;
            order.OrderStatus = 1;
            _uow.Orders.Add(order);

            foreach (var basketItem in basket)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderDemands = new List<OrderDemand>();

                orderDetail.ProductId = basketItem.ProductId;
                orderDetail.Quantity = basketItem.Quantity;
                orderDetail.UnitPrice = basketItem.TotalUnitPrice;
                orderDetail.OrderId = order.Id;

                // _uow.OrderDetails.Add(orderDetail);
                foreach (var demand in basketItem.DemandTypes)
                {
                    OrderDemand orderDemand = new OrderDemand()
                    {
                        DemandId = demand.DemandId,
                        DemandTypeId = demand.DemandTypeId,
                        OrderDetailId = orderDetail.Id
                    };
                    orderDetail.OrderDemands.Add(orderDemand);
                    // _uow.OrderDemands.Add(orderDemand);
                }
                order.OrderDetails.Add(orderDetail);
            }
            int result = await _uow.Complete();
            return order;
        }

        public async Task<IDataResult<List<Order>>> GetListAsync()
        {
            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);
            List<Order> orders = await _uow.Orders.GetListAsync(x => x.OrderDate >= oneMonthAgo, x => x.User);
            return ResultHelper<List<Order>>.DataResultReturn(orders);
        }

        public async Task<Order> GetOrderAsync(int orderId) => await _uow.Orders.GetAsync(x => x.Id == orderId, x => x.User);

        public async Task UpdateAsync(Order order)
        {
            _uow.Orders.Update(order);
            await _uow.Complete();
        }
    }
}