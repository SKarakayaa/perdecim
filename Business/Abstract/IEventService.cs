using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IEventService
    {
        Task<List<Event>> GetListAsync();
        Task<IDataResult<List<Event>>> GetActiveEventsAsync();
        Task<Event> GetAsync(int id);
        Task<IResult> EventDone(int id);
    }
}