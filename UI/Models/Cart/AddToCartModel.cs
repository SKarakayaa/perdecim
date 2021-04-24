using System.Collections.Generic;

namespace UI.Models.Cart
{
    public class AddToCartModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public List<DemandType> DemandTypes { get; set; } 
    }
}