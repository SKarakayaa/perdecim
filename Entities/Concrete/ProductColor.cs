using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class ProductColor:IEntity
    {
        public ProductColor() {}
        public ProductColor(int productId, int colorId)
        {
            ProductId = productId;
            ColorId = colorId;
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
    
        [ForeignKey(nameof(ColorId))]
        public virtual Color Color { get; set; }
    }
}