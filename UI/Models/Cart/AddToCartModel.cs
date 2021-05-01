using System.Collections.Generic;
using Entities.DTO.Cart;

namespace UI.Models.Cart
{
    public class AddToCartModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public List<DemandTypeDTO> DemandTypes { get; set; }
    }
}