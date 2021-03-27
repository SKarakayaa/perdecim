using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            string[] navigation = { "Category", "ProductDemands", "ProductImages", "ProductDemands.DemandType", "ProductDemands.DemandType.Demands" };
            ViewBag.BaseUrl = "https://" + HttpContext.Request.Host.ToString();
            IDataResult<Product> product = await _productService.GetByIdAsync(id, navigation);
            return View(product.Data);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Products()
        {
            string[] navigation = { "Category" };
            IDataResult<List<Product>> products = _productService.GetListAsync(null, navigation).Result;
            ViewBag.Products = products.Data;
            ViewBag.CreateProductElements = _productService.GetCreateProductElements().Result;
            return View();
        }
    }
}