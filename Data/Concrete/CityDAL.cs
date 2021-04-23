using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;

namespace Data.Concrete
{
    public class CityDAL : Repository<City>, ICityDAL
    {
        public CityDAL(MatmazelContext context) : base(context)
        {
        }
    }
}