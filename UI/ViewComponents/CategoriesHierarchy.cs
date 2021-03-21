using System.Collections.Generic;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{
    public class CategoriesHierarchy : ViewComponent
    {
        public IViewComponentResult Invoke(Category category)
        {
            return View(category);
        }
    }
}