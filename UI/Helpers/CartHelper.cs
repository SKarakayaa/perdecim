using System;
using Entities.Concrete;
using Entities.DTO.Cart;
using UI.Models.Cart;

namespace UI.Helpers
{
    public static class CartHelper
    {
        public static CartDTO NewCartItem(Product product, AddToCartModel model)
        {
            var unitPrice = product.DiscountRate == 0 ? product.Price : (product.Price - (product.Price * (Convert.ToDecimal(product.DiscountRate) / 100)));
            decimal additionalPrices = 0;
            if (model.DemandTypes.Count != 0)
            {
                var productDemands = product.ProductDemands;
                foreach (var demandType in model.DemandTypes)
                    additionalPrices += demandType.ChoosedDemandPrice;
            }
            unitPrice += additionalPrices;

            product.ProductDemands = null;
            CartDTO cartModel = new CartDTO
            {
                DemandTypes = model.DemandTypes,
                ProductId = product.Id,
                Product = product,
                Quantity = model.Quantity,
                TotalUnitPrice = unitPrice,
                Note = model.Note
            };
            return cartModel;
        }
    }
}