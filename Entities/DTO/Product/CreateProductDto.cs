using Microsoft.AspNetCore.Http;

namespace Entities.DTO.Product
{
    public class CreateProductDto
    {
        public int? ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }
        public int ColorId { get; set; }
        public int? DiscountRate { get; set; }
        public string Description { get; set; }
        public bool IsNew { get; set; }
        public bool IsStock { get; set; }
        public bool IsPopular { get; set; }
        public decimal Price { get; set; }
        public bool CanNotable { get; set; }
        public IFormFile[] Images { get; set; }
        public int[] DemandTypeIds { get; set; }
    }
}