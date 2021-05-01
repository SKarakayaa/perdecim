using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;

namespace Data.Concrete
{
    public class OrderDemandDAL : Repository<OrderDemand>, IOrderDemandDAL
    {
        public OrderDemandDAL(MatmazelContext context) : base(context)
        {
        }
    }
}