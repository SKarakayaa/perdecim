using System.Collections.Generic;
using Entities.Concrete;
using Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using UI.Helpers;
using UI.Models.OrderListViewComponent;

namespace UI.ViewComponents
{
    public class OrderList : ViewComponent
    {
        public IViewComponentResult Invoke(List<Order> orderList, OrderStatusEnum orderStatus)
        {
            OrderListViewModel orderListViewModel = new OrderListViewModel
            {
                ListCount = orderList.Count,
                Orders = orderList,
                OrderStatus = orderStatus,
                OrderListPanelInformation = OrderListHelper.GetOrderListPanelInformation(orderStatus)
            };
            return View(orderListViewModel);
        }
    }
}