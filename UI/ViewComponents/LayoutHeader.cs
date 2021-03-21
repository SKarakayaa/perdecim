using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
    [ViewComponent]
    public class LayoutHeader:ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public LayoutHeader(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IViewComponentResult Invoke()
        {
            List<Category> categories = (_categoryService.GetListAsync().Result).Data.Where(x=>x.ParentId == 1).ToList();
            ViewBag.BaseUrl = "https://" + HttpContext.Request.Host.ToString();
            return View(categories);
        }
    }
}