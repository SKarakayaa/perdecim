using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            ViewBag.Brands = await _brandService.GetListAsync();
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBrand(Brand brand)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", brand);

            IResult result = await _brandService.AddOrEditAsync(brand);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("CreateError", result.Message);
                return View("Index", brand);
            }
            return RedirectToAction("Index", "Brand");
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> DeleteBrand(int id)
        {
            IResult result = await _brandService.DeleteAsync(id);
            return Json(result);
        }
    }
}