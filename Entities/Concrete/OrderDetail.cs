using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class OrderDetail : IEntity
    {
        public OrderDetail()
        {
            this.OrderDemands = new List<OrderDemand>();
        }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; private set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; private set; }

        public List<OrderDemand> OrderDemands { get; set; }
    }
}