using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Event> events = await _eventService.GetListAsync();
            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var _event = await _eventService.GetAsync(id);
            return View(_event);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EventDone(int id)
        {
            IResult result = await _eventService.EventDone(id);

            TempData["ToastMessage"] = result.IsSuccess
                ? JsonSerializer.Serialize<ToastModel>(ToastModel.Success("Etkinlik Sonlandırıldı !"))
                : JsonSerializer.Serialize<ToastModel>(ToastModel.Fail(result.Message));

            return RedirectToAction(nameof(Index));
        }
    }
}