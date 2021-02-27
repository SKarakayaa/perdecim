using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
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
        public async Task<IActionResult> Index(int id)
        {
            string[] navigation = { "Category","ProductDemands","ProductImages","ProductDemands.DemandType","ProductDemands.DemandType.Demands" };
            ViewBag.BaseUrl = "https://" + HttpContext.Request.Host.ToString();
            IDataResult<Product> product = await _productService.GetByIdAsync(id, navigation);
            return View(product.Data);
        }
    }
}