using Core.Repository;
using Data.Abstract;
using Data.Context;
using Entities.Concrete;

namespace Data.Concrete
{
    public class ProductDAL : Repository<Product, MatmazelContext>, IProductDAL
    {

    }
}