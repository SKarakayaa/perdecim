using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class ProductDemand:IEntity
    {
        public ProductDemand(){}
        public ProductDemand(int productId, int demandTypeId)
        {
            ProductId = productId;
            DemandTypeId = demandTypeId;
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int DemandTypeId{ get; set; }
    
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
    
        [ForeignKey(nameof(DemandTypeId))]
        public virtual DemandType DemandType { get; set; }
    }
}