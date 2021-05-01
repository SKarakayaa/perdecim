using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;

namespace Data.Concrete
{
    public class OrderDetailDAL : Repository<OrderDetail>, IOrderDetailDAL
    {
        public OrderDetailDAL(MatmazelContext context) : base(context)
        {
        }
    }
}