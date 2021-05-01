using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;

namespace Data.Concrete
{
    public class OrderDAL : Repository<Order>, IOrderDAL
    {
        public OrderDAL(MatmazelContext context) : base(context)
        {
        }
    }
}