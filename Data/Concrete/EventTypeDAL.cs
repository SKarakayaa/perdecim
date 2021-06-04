using Data.Abstract;
using Data.Context;
using Data.Repository;
using Entities.Concrete;

namespace Data.Concrete
{
    public class EventTypeDAL : Repository<EventType>, IEventTypeDAL
    {
        public EventTypeDAL(MatmazelContext context) : base(context)
        {
        }
    }
}