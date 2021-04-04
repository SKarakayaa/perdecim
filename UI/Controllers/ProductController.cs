using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Config;
using Entities.DTO.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly FileUploadSettings _fileUploadSettings;
        public ProductController(IProductService productService, IOptions<FileUploadSettings> fileUploadSettings)
        {
            _productService = productService;
            _fileUploadSettings = fileUploadSettings.Value;
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
            string[] navigation = { "Category", "Color", "Brand" };
            IDataResult<List<Product>> products = _productService.GetListAsync(null, navigation).Result;
            ViewBag.Products = products.Data;
            ViewBag.CreateProductElements = _productService.GetCreateProductElements().Result.Data;
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateOrEditProduct(int? id = null)
        {
            ViewBag.CreateProductElements = _productService.GetCreateProductElements().Result.Data;
            if (id.HasValue)
            {
                Product product = (await _productService.GetByIdAsync(id.Value, new[] { "ProductDemands", "ProductImages" })).Data;
                CreateProductDto createProductDto = new CreateProductDto
                {
                    ProductId = product.Id,
                    BrandId = product.BrandId,
                    CanNotable = product.CanNotable,
                    CategoryId = product.CategoryId,
                    ColorId = product.ColorId,
                    DemandTypeIds = product.ProductDemands.Select(s => s.DemandTypeId).ToArray(),
                    Description = product.Description,
                    DiscountRate = product.DiscountRate,
                    IsNew = product.IsNew,
                    IsPopular = product.IsPopular,
                    IsStock = product.InStock,
                    Name = product.Name,
                    Price = product.Price
                };
                ViewBag.ImagePaths = product.ProductImages.Select(s => $"https://{HttpContext.Request.Host.ToString()}{_fileUploadSettings.ProductImagePath}{s.ImageName}").ToList();
                return View(createProductDto);
            }
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrEditProduct(CreateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateProductElements = _productService.GetCreateProductElements().Result.Data;
                return View(productDto);
            }

            await _productService.CreateOrEditProductAsync(productDto);

            return RedirectToAction("Products", "Product");
        }
    }
}