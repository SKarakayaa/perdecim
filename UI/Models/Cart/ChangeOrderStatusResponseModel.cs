using Entities.Concrete;
using UI.Models.OrderListViewComponent;

namespace UI.Models.Cart
{
    public class ChangeOrderStatusResponseModel
    {
        public Order Order { get; set; }
        public OrderListPanelInformation OrderListPanelInformation { get; set; }
    }
}