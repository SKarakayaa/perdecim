﻿using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using UI.Models.Home;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public HomeController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }
        
        public async Task<IActionResult> Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            var categories = await _categoryService.GetListAsync();
            homeViewModel.Categories = categories.Data.Take(4).ToList();
            return View(homeViewModel);
        }

        public async Task<IActionResult> Products(int categoryId)
        {
            ViewBag.CategoryId = categoryId;
            HomeViewModel homeViewModel = new HomeViewModel();
            var categories = await _categoryService.GetListAsync();

            homeViewModel.Categories = categories.Data;
            return View(homeViewModel);
        }
        public async Task<JsonResult> GetProductList(int categoryId)
        {
            var products = (await _productService.GetListAsync(x => x.CategoryId == categoryId)).Data;
            return Json(products);
        }
    }
}
