using System;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Product:IEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int DiscountRate { get; set; }        
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsNew { get; set; }
        public bool InStock { get; set; }
        public bool IsPopular { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    
        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; set; }
    
        [ForeignKey(nameof(ColorId))]
        public virtual Color Color { get; set; }
    }
}