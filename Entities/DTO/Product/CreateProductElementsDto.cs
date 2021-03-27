using System.Collections.Generic;
using Entities.Concrete;

namespace Entities.DTO.Product
{
    public class CreateProductElementsDto
    {
        public List<Color> Colors { get; set; }
        public List<Category> Categories { get; set; }
        public List<Brand> Brands { get; set; }
        public List<DemandType> DemandTypes { get; set; }
    }
}