using Microsoft.AspNetCore.Http;

namespace Entities.DTO.Demand
{
    public class DemandCreateDto
    {
        public string Name { get; set; }
        public int DemandTypeId { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
    }
}