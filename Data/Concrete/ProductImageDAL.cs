using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;

namespace Data.Concrete
{
    public class ProductImageDAL : Repository<ProductImage>,IProductImageDAL
    {
        public ProductImageDAL(MatmazelContext context) : base(context)
        {

        }
    }
}