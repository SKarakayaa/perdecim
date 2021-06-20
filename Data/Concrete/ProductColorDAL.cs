using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;

namespace Data.Concrete
{
    public class ProductColorDAL : Repository<ProductColor>, IProductColorDAL
    {
        public ProductColorDAL(MatmazelContext context) : base(context)
        {
        }
    }
}