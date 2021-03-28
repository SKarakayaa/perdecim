using System;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = (await _categoryService.GetListAsync()).Data;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEdit(Category category)
        {
            category.CreatedAt = DateTime.Now;
            await _categoryService.CreateOrEditCategoryAsync(category);
            return RedirectToAction("Index", "Category");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> DeleteCategory(int id)
        {
            IResult result = await _categoryService.DeleteAsync(id);
            if (!result.IsSuccess)
                return Json(new { IsSucces = false, Message = result.Message });
            return Json(new { IsSuccess = true });
        }
    }
}