using System;
using System.Linq;
using Entities.Concrete;
using UI.Models.Cart;

namespace UI.Helpers
{
    public static class CartHelper
    {
        public static CartModel NewCartItem(Product product, AddToCartModel model)
        {
            var unitPrice = product.DiscountRate == 0 ? product.Price : (product.Price - (product.Price * (Convert.ToDecimal(product.DiscountRate) / 100)));
            decimal additionalPrices = 0;
            if (model.DemandTypes.Count != 0)
            {
                var productDemands = product.ProductDemands;
                foreach (var demandType in model.DemandTypes)
                {
                    var demands = productDemands.FirstOrDefault(x => x.DemandTypeId == demandType.Id).DemandType.Demands;
                    var demandPrice = demands.FirstOrDefault(x => x.Id == demandType.Value).Price;
                    additionalPrices += demandPrice;
                }
            }
            unitPrice += additionalPrices;

            product.ProductDemands = null;
            CartModel cartModel = new CartModel
            {
                DemandTypes = model.DemandTypes,
                ProductId = product.Id,
                Product = product,
                Quantity = model.Quantity,
                TotalUnitPrice = unitPrice
            };
            return cartModel;
        }
    }
}