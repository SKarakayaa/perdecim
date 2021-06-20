using Microsoft.AspNetCore.Http;

namespace Entities.DTO.Product
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int[] ColorIds { get; set; }
        public int DiscountRate { get; set; }
        public string Description { get; set; }
        public bool IsNew { get; set; }
        public bool InStock { get; set; }
        public bool IsPopular { get; set; }
        public decimal Price { get; set; }
        public bool CanNotable { get; set; }
        public IFormFile[] Images { get; set; }
        public int[] DemandTypeIds { get; set; }
        public string FilePath { get; set; }
    }
}