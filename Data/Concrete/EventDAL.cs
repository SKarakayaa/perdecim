using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;

namespace Data.Concrete
{
    public class EventDAL : Repository<Event>, IEventDAL
    {
        public EventDAL(MatmazelContext context) : base(context)
        {
        }
    }
}