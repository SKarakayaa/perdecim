using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class ProductImage:IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageName { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
    }
}