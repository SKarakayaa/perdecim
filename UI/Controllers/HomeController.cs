using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using UI.Models.Home;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IColorService _colorService;
        private readonly IBrandService _brandService;

        public HomeController(ICategoryService categoryService, IProductService productService, IColorService colorService, IBrandService brandService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _colorService = colorService;
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            var categories = await _categoryService.GetListForBannerAsync();
            homeViewModel.Categories = categories.Data;
            return View(homeViewModel);
        }

        public async Task<IActionResult> Products(int categoryId)
        {
            ViewBag.CategoryId = categoryId;
            HomeViewModel homeViewModel = new HomeViewModel();
            var categories = await _categoryService.GetListAsync();

            homeViewModel.Categories = categories.Data;
            homeViewModel.Brands = (await _brandService.GetListAsync());
            homeViewModel.Colors = (await _colorService.GetListAsync());
            return View(homeViewModel);
        }
        public async Task<JsonResult> GetProductList(int categoryId)
        {
            List<Product> products;
            if (categoryId != 1)
                products = (await _productService.GetListAsync(x => x.CategoryId == categoryId, x => x.ProductImages)).Data;
            else
                products = (await _productService.GetListAsync(null, x => x.ProductImages)).Data;
            return Json(products);
        }
    }
}
