using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.Concrete
{
    public class OrderDetailDAL : Repository<OrderDetail>, IOrderDetailDAL
    {
        public OrderDetailDAL(MatmazelContext context) : base(context)
        {
        }

        public async Task<List<OrderDetail>> GetOrderDetailWithDemands(int orderId)
        {
            List<OrderDetail> orderDetails = await base._context.OrderDetails
                .Where(x => x.OrderId == orderId)
                .Include(x => x.Order)
                .Include(x => x.OrderDemands).ThenInclude(y => y.Demand)
                .Include(x => x.Product).ToListAsync();
            return orderDetails;
        }
    }
}