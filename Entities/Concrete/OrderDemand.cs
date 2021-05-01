using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class OrderDemand : IEntity
    {
        public int Id { get; set; }
        public int OrderDetailId { get; set; }
        public int DemandTypeId { get; set; }
        public int DemandId { get; set; }

        [ForeignKey(nameof(OrderDetailId))]
        public virtual OrderDetail OrderDetail { get; private set; }

        [ForeignKey(nameof(DemandTypeId))]
        public virtual DemandType DemandType { get; private set; }

        [ForeignKey(nameof(DemandId))]
        public virtual Demand Demand { get; private set; }
    }
}