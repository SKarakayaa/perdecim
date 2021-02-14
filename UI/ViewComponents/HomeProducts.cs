using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.Enums;
using Microsoft.AspNetCore.Mvc;

namespace UI.ViewComponents
{

    [ViewComponent]
    public class HomeProducts : ViewComponent
    {
        private readonly IProductService _productService;
        public HomeProducts(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int productType)
        {
            List<Product> products = new List<Product>();
            string[] navigation = { "Category" };
            switch (productType)
            {
                case (int)ProductType.NEW_PRODUCT:
                    products = await _productService.GetListAsync(x => x.IsNew, navigation);
                    ViewBag.Title = "Yeni Ürünler";
                    break;
                case (int)ProductType.DISCOUNTED_PRODUCT:
                    products = await _productService.GetListAsync(x => x.DiscountRate != 0, navigation);
                    ViewBag.Title = "İndirimli Ürünler";
                    break;
                case (int)ProductType.POPULAR_PRODUCT:
                    products = await _productService.GetListAsync(x => x.IsPopular, navigation);
                    ViewBag.Title = "Popüler Ürünler";
                    break;
                default:
                    break;
            }

            return View(products);
        }
    }
}