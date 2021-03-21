using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;

namespace Data.Concrete
{
    public class DemandDAL : Repository<Demand>, IDemandDAL
    {
        public DemandDAL(MatmazelContext context) : base(context)
        { }
    }
}