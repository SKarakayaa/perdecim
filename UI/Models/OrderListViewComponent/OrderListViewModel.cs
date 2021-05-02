using System.Collections.Generic;
using Entities.Concrete;
using Entities.Enums;

namespace UI.Models.OrderListViewComponent
{
    public class OrderListViewModel
    {
        public List<Order> Orders { get; set; }
        public OrderStatusEnum OrderStatus { get; set; }
        public int ListCount { get; set; }
    }
}