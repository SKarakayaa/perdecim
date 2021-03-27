using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;

namespace Data.Concrete
{
    public class BrandDAL : Repository<Brand>, IBrandDAL
    {
        public BrandDAL(MatmazelContext context) : base(context)
        { }
    }
}