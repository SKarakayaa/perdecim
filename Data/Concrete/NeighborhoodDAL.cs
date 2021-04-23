using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;

namespace Data.Concrete
{
    public class NeighborhoodDAL : Repository<Neighborhood>, INeighborhoodsDAL
    {
        public NeighborhoodDAL(MatmazelContext context) : base(context)
        {
        }
    }
}