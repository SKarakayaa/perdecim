using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Helpers;
using Business.UnitOfWork;
using Core.Utilities.Results;
using Data.Abstract;
using Entities.Concrete;
using Entities.DTO.Cart;
using Entities.Enums;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork _uow;
        private readonly IOrderDAL _orderDAL;
        private readonly IOrderDetailDAL _orderDetailDAL;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderManager(IUnitOfWork uow, IHttpContextAccessor httpContextAccessor, IOrderDAL orderDAL, IOrderDetailDAL orderDetailDAL)
        {
            _uow = uow;
            _orderDAL = orderDAL;
            _orderDetailDAL = orderDetailDAL;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Order> CreateOrder(CartDTO cart, CreateOrderDto createOrder)
        {
            Order order = new Order();
            order.OrderDetails = new List<OrderDetail>();

            order.OrderDate = DateTime.Now;
            order.TotalPrice = cart.CartTotal;
            order.UserId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.FindFirst("UserId").Value);
            order.AddressId = createOrder.AddressId;
            order.PaymentTypeId = createOrder.PaymentType;
            order.OrderStatus = (int)OrderStatusEnum.ORDERED;
            _orderDAL.Add(order);

            foreach (var cartItem in cart.CartItems)
            {
                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderDemands = new List<OrderDemand>();

                orderDetail.ProductId = cartItem.ProductId;
                orderDetail.Quantity = cartItem.Quantity;
                orderDetail.UnitPrice = cartItem.UnitPrice;
                orderDetail.OrderId = order.Id;
                orderDetail.Note = cartItem.Note;

                foreach (var demand in cartItem.DemandTypes)
                {
                    OrderDemand orderDemand = new OrderDemand()
                    {
                        DemandId = demand.DemandId,
                        DemandTypeId = demand.DemandTypeId,
                        OrderDetailId = orderDetail.Id
                    };
                    orderDetail.OrderDemands.Add(orderDemand);
                }
                order.OrderDetails.Add(orderDetail);
            }
            int result = await _uow.Complete();
            return order;
        }

        public async Task<IDataResult<List<Order>>> GetListAsync()
        {
            DateTime oneMonthAgo = DateTime.Now.AddMonths(-1);
            List<Order> orders = await _orderDAL.GetListAsync(x => x.OrderDate >= oneMonthAgo, x => x.User);
            return ResultHelper<List<Order>>.DataResultReturn(orders);
        }

        public async Task<Order> GetOrderAsync(int orderId) => await _orderDAL.GetAsync(x => x.Id == orderId, x => x.User);

        public async Task UpdateAsync(Order order)
        {
            _orderDAL.Update(order);
            await _uow.Complete();
        }

        public async Task<IDataResult<List<Order>>> GetListByUserId(int userId)
        {
            List<Order> orders = await _orderDAL.GetListAsync(x => x.UserId == userId, x => x.Address);
            orders = orders.OrderBy(o => o.OrderStatus).OrderByDescending(o => o.OrderDate).ToList();
            return ResultHelper<List<Order>>.DataResultReturn(orders);
        }

        public async Task<IDataResult<List<OrderDetail>>> GetOrderDetail(int orderId)
        {
            List<OrderDetail> orderDetails = await _orderDetailDAL.GetOrderDetailWithDemands(orderId);
            return ResultHelper<List<OrderDetail>>.DataResultReturn(orderDetails);
        }
        
    }
}