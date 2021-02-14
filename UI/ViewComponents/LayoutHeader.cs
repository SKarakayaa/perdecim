using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            List<Category> categories = _categoryService.GetListAsync().Result.Where(x=>x.ParentId == null).ToList();
            return View(categories);
        }
    }
}