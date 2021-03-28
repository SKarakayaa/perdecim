using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;

namespace Data.Concrete
{
    public class ProductDemandDAL : Repository<ProductDemand>,IProductDemandDAL
    {
        public ProductDemandDAL(MatmazelContext context) : base(context)
        {

        }
    }
}