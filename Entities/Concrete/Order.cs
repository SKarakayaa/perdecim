using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Order : IEntity
    {
        public Order()
        {
            this.OrderDetails = new List<OrderDetail>();
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderStatus { get; set; }
        public int AddressId { get; set; }
        public int PaymentTypeId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual AppUser User { get; private set; }

        [ForeignKey(nameof(AddressId))]
        public virtual UserAddress Address { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}