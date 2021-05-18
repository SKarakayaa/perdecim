using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.Config;
using Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace UI.ViewComponents
{

    [ViewComponent]
    public class HomeProducts : ViewComponent
    {
        private readonly IProductService _productService;
        private readonly FileUploadSettings _fileUploadSettings;
        public HomeProducts(IProductService productService, IOptions<FileUploadSettings> fileUploadSettings)
        {
            _productService = productService;
            _fileUploadSettings = fileUploadSettings.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync(int productType)
        {
            List<Product> products = new List<Product>();
            switch (productType)
            {
                case (int)ProductType.NEW_PRODUCT:
                    products = (await _productService.GetListAsync(x => x.IsNew, x => x.Category, x => x.Brand, x => x.ProductImages)).Data;
                    ViewBag.Title = "Yeni Ürünler";
                    break;
                case (int)ProductType.DISCOUNTED_PRODUCT:
                    products = (await _productService.GetListAsync(x => x.DiscountRate != 0, x => x.Category, x => x.Brand, x => x.ProductImages)).Data;
                    ViewBag.Title = "İndirimli Ürünler";
                    break;
                case (int)ProductType.POPULAR_PRODUCT:
                    products = (await _productService.GetListAsync(x => x.IsPopular, x => x.Category, x => x.Brand, x => x.ProductImages)).Data;
                    ViewBag.Title = "Popüler Ürünler";
                    break;
                default:
                    products = (await _productService.GetListAsync()).Data;
                    break;
            }
            ViewBag.ImageBaseUrl = $"{_fileUploadSettings.PhotoPath}";

            return View(products);
        }
    }
}