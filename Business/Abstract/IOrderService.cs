using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO.Cart;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(CartDTO cart, CreateOrderDto createOrder);
        Task<IDataResult<List<Order>>> GetListAsync();
        Task UpdateAsync(Order order);
        Task<Order> GetOrderAsync(int orderId);
        Task<IDataResult<List<Order>>> GetListByUserId(int userId);
        Task<IDataResult<List<OrderDetail>>> GetOrderDetail(int orderId);
    }
}