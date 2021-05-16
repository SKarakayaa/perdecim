using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Repository;
using Entities.Concrete;

namespace Data.Abstract
{
    public interface IOrderDetailDAL : IRepositoryBase<OrderDetail>
    {
        Task<List<OrderDetail>> GetOrderDetailWithDemands(int orderId);
    }
}