using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Concrete;
using Entities.DTO.Cart;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(List<CartDTO> basket, CreateOrderDto createOrder);
    }
}