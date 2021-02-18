using Data.Repository;
using Data.Abstract;
using Data.Context;
using Entities.Concrete;

namespace Data.Concrete
{
    public class ProductDAL : Repository<Product>, IProductDAL
    {
        public ProductDAL(MatmazelContext context) : base(context)
        {
        }
    }
}