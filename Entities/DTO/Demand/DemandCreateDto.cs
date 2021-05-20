using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Entities.DTO.Demand
{
    public class DemandCreateDto
    {
        public string Name { get; set; }
        public int DemandTypeId { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal Price { get; set; } = 0;
        public IFormFile Image { get; set; }
        public string FilePath { get; set; }
    }
}