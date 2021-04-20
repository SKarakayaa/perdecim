using System.Collections.Generic;
using Entities.Concrete;

namespace UI.Models.Cart
{
    public class CartModel
    {
        public int ProductId { get; set; }
        public decimal TotalUnitPrice { get; set; }
        public int Quantity{ get; set; }
        public string Note { get; set; }
        public List<DemandType> DemandTypes { get; set; }

        public Product Product { get; set; }
    }
}