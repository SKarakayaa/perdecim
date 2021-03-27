using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;

namespace Data.Concrete
{
    public class ColorDAL : Repository<Color>, IColorDAL
    {
        public ColorDAL(MatmazelContext context) : base(context)
        { }
    }
}