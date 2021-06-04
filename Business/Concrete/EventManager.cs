using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Helpers;
using Business.UnitOfWork;
using Core.Utilities.Results;
using Data.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class EventManager : IEventService
    {
        private readonly IEventDAL _eventDAL;
        private readonly IUnitOfWork _uow;

        public EventManager(IEventDAL eventDAL, IUnitOfWork uow)
        {
            _eventDAL = eventDAL;
            _uow = uow;
        }

        public async Task<List<Event>> GetListAsync() => await _eventDAL.GetListAsync(null, x => x.EventType);

        public async Task<Event> GetAsync(int id) => await _eventDAL.GetAsync(x => x.Id == id, x => x.EventType);

        public async Task<IDataResult<List<Event>>> GetActiveEventsAsync()
        {
            List<Event> events = await _eventDAL.GetListAsync(x => x.EndDate >= DateTime.Now);
            return ResultHelper<List<Event>>.DataResultReturn(events);
        }

        public async Task<IResult> EventDone(int id)
        {
            Event _event = await _eventDAL.GetAsync(x => x.Id == id);
            _event.EndDate = DateTime.Now.AddDays(-1);
            _eventDAL.Update(_event);
            int result = await _uow.Complete();
            return ResultHelper<int>.ResultReturn(result);
        }
    }
}