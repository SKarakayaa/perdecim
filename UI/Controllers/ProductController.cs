using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Config;
using Entities.DTO.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly FileUploadSettings _fileUploadSettings;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService productService, IOptions<FileUploadSettings> fileUploadSettings, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _fileUploadSettings = fileUploadSettings.Value;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            //string[] navigation = { "Category", "ProductDemands", "ProductImages", "ProductDemands.DemandType", "ProductDemands.DemandType.Demands" };
            //x => x.ProductDemands.AsQueryable().Include(x => x.DemandType), x => x.ProductDemands.AsQueryable().Include(x => x.DemandType).Include(x => x.DemandType.Demands)
            ViewBag.BaseUrl = "https://" + HttpContext.Request.Host.ToString();
            IDataResult<Product> product = await _productService.GetProductWithDemandAsync(id);
            return View(product.Data);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Products()
        {
            IDataResult<List<Product>> products = _productService.GetListAsync(null, x => x.Category, x => x.Brand).Result;
            ViewBag.Products = products.Data;
            ViewBag.CreateProductElements = _productService.GetCreateProductElements().Result.Data;
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.CreateProductElements = (await _productService.GetCreateProductElements()).Data;
            return View();

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateProductElements = (await _productService.GetCreateProductElements()).Data;
                return View(productDto);
            }

            productDto.FilePath = Path.Combine(_webHostEnvironment.WebRootPath, _fileUploadSettings.PhotoPath);
            await _productService.CreateProduct(productDto);

            return RedirectToAction("Products", "Product");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.CreateProductElements = (await _productService.GetCreateProductElements()).Data;
            Product product = (await _productService.GetByIdAsync(id)).Data;
            UpdateProductDto updateProductDto = new UpdateProductDto
            {
                Id = product.Id,
                BrandId = product.BrandId,
                CanNotable = product.CanNotable,
                CategoryId = product.CategoryId,
                DemandTypeIds = product.ProductDemands.Select(s => s.DemandTypeId).ToArray(),
                Description = product.Description,
                DiscountRate = product.DiscountRate,
                ColorIds = product.ProductColors.Select(x => x.ColorId).ToArray(),
                IsNew = product.IsNew,
                IsPopular = product.IsPopular,
                InStock = product.InStock,
                Name = product.Name,
                Price = product.Price
            };
            ViewBag.ImagePaths = product.ProductImages.Select(s => $"https://{HttpContext.Request.Host.ToString()}/images/{s.ImageName}").ToList();
            return View(updateProductDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CreateProductElements = (await _productService.GetCreateProductElements()).Data;
                return View(productDto);
            }
            IResult result = await _productService.UpdateProduct(productDto);

            return RedirectToAction(nameof(Products), "Product");
        }
    }
}