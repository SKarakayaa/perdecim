using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;

namespace Data.Concrete
{
    public class DistrictDAL : Repository<District>, IDistrictDAL
    {
        public DistrictDAL(MatmazelContext context) : base(context)
        {
        }
    }
}