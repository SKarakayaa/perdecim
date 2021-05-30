using System;
using System.Collections.Generic;
using System.Linq;

namespace Entities.DTO.Cart
{
    public class CartDTO
    {
        public CartDTO()
        {
            CartItems = new List<CartItemDTO>();
        }
        public int? CartDiscountRate { get; set; }
        public List<CartItemDTO> CartItems { get; set; }
        public decimal CartTotal
        {
            get
            {
                if (CartDiscountRate.HasValue)
                {
                    decimal totalAmount = CartItems.Sum(x => x.TotalItemPrice);
                    decimal discountPrice = Math.Round(totalAmount * ((decimal)CartDiscountRate.Value / 100), 2);
                    return totalAmount * discountPrice;
                }
                return CartItems.Sum(x => x.TotalItemPrice);
            }
        }
        public int CartItemsCount { get => CartItems.Sum(x => x.Quantity); }

        public void ApplyDiscount(int rate) => CartDiscountRate = rate;
        public void CancelDiscount() => CartDiscountRate = null;
    }
}