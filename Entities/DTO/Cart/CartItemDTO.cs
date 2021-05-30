using System;
using System.Collections.Generic;

namespace Entities.DTO.Cart
{
    public class CartItemDTO
    {
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public string ImageName { get; set; }
        public List<DemandTypeDTO> DemandTypes { get; set; }

        public Entities.Concrete.Product Product { get; set; }
        public int? DiscountRate { get; set; }
        public decimal TotalItemPrice
        {
            get
            {
                if (DiscountRate.HasValue)
                {
                    decimal discountedPrice = UnitPrice * ((decimal)DiscountRate.Value / 100);
                    return Math.Round((UnitPrice - discountedPrice) * Quantity, 2);
                }
                return Math.Round(UnitPrice * Quantity, 2);
            }
        }

        public void ApplyDiscount(int rate) => DiscountRate = rate;
        public void CancelDiscount() => DiscountRate = null;
    }
}