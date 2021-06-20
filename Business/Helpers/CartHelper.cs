using System;
using System.Linq;
using Entities.Concrete;
using Entities.DTO.Cart;

namespace Business.Helpers
{
    public static class CartHelper
    {
        public static CartItemDTO NewCartItem(Product product, AddToCartDTO model)
        {
            decimal additionalPrices = 0;
            if (model.DemandTypes.Count != 0)
            {
                var productDemands = product.ProductDemands;
                foreach (var demandType in model.DemandTypes)
                    additionalPrices += demandType.ChoosedDemandPrice;
            }
            product.Price += additionalPrices;

            product.ProductDemands = null;
            CartItemDTO cartModel = new CartItemDTO
            {
                DemandTypes = model.DemandTypes,
                ProductId = product.Id,
                Product = product,
                Quantity = model.Quantity,
                UnitPrice = product.Price,
                Note = model.Note,
                ImageName = product.ProductImages.FirstOrDefault().ImageName
            };
            cartModel.ApplyDiscount(product.DiscountRate);
            return cartModel;
        }
    }
}