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
        public OrderListPanelInformation OrderListPanelInformation { get; set; }

    }

    public class OrderListPanelInformation
    {
        public string PanelClass { get; set; }
        public string PanelTitle { get; set; }
        public string TableId { get; set; }
        public string HtmlButton { get; set; }
    }
}