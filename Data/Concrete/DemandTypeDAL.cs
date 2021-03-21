using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;

namespace Data.Concrete
{
    public class DemandTypeDAL : Repository<DemandType>, IDemandTypeDAL
    {
        public DemandTypeDAL(MatmazelContext context) : base(context)
        { }
    }
}