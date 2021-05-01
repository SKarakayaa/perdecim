using System.Collections.Generic;

namespace Entities.DTO.Cart
{
    public class CartDTO
    {
        public int ProductId { get; set; }
        public decimal TotalUnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }
        public List<DemandTypeDTO> DemandTypes { get; set; }

        public Entities.Concrete.Product Product { get; set; }
    }
}