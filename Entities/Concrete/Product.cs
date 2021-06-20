using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Product : IEntity
    {
        public Product()
        {
            this.ProductDemands = new HashSet<ProductDemand>();
            this.ProductImages = new HashSet<ProductImage>();
            this.ProductColors = new HashSet<ProductColor>();
        }
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public int DiscountRate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsNew { get; set; }
        public bool InStock { get; set; }
        public bool IsPopular { get; set; }
        public bool CanNotable { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        [ForeignKey(nameof(BrandId))]
        public virtual Brand Brand { get; set; }

        public ICollection<ProductColor> ProductColors { get; set; }
        public ICollection<ProductDemand> ProductDemands { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}