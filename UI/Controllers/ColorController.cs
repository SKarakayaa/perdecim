using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;
        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Colors = await _colorService.GetListAsync();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateColor(Color color)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Index), color);

            IResult result = await _colorService.AddOrEditAsync(color);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("CreateError", result.Message);
                return RedirectToAction(nameof(Index), color);
            }

            return RedirectToAction("Index", "Color");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> DeleteColor(int id)
        {
            IResult result = await _colorService.DeleteAsync(id);
            return Json(result);
        }
    }
}