using System.Collections.Generic;

namespace Entities.DTO.Cart
{
    public class AddToCartDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public List<DemandTypeDTO> DemandTypes { get; set; }
    }
}