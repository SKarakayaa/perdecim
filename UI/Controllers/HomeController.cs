using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UI.Models;
using UI.Models.Home;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;

        public HomeController(ILogger<HomeController> logger,ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            var categories = await _categoryService.GetListAsync();
            homeViewModel.Categories = categories.Take(4).ToList();
            return View(homeViewModel);
        }
    }
}
