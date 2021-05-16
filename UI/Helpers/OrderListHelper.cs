using Entities.Enums;
using UI.Models.OrderListViewComponent;

namespace UI.Helpers
{
    public static class OrderListHelper
    {
        public static OrderListPanelInformation GetOrderListPanelInformation(OrderStatusEnum orderStatus)
        {
            OrderListPanelInformation orderListPanel = new OrderListPanelInformation();
            if (orderStatus == OrderStatusEnum.ORDERED)
            {
                orderListPanel.PanelClass = "panel panel-success";
                orderListPanel.TableId = $"table-{(int)OrderStatusEnum.ORDERED}";
                orderListPanel.PanelTitle = "Siparişler";
                orderListPanel.HtmlButton = "<button class='btn btn-success btn-sm' onclick='ChangeOrderStatus(this)'>Sipariş Onayla</button>";
            }
            else if (orderStatus == OrderStatusEnum.CONFIRMED)
            {
                orderListPanel.TableId = $"table-{(int)OrderStatusEnum.CONFIRMED}";
                orderListPanel.PanelTitle = "Onaylanan Siparişler";
                orderListPanel.PanelClass = "panel panel-warning";
                orderListPanel.HtmlButton = "<button class='btn btn-warning btn-sm' onclick='ChangeOrderStatus(this)'>Kargoya Gönder</button>";
            }
            else if (orderStatus == OrderStatusEnum.SENDED)
            {
                orderListPanel.TableId = $"table-{(int)OrderStatusEnum.SENDED}";
                orderListPanel.PanelTitle = "Yolda Olan Siparişler";
                orderListPanel.PanelClass = "panel panel-info";
                orderListPanel.HtmlButton = "<button class='btn btn-info btn-sm' onclick='ChangeOrderStatus(this)'>Tamamlandı</button>";
            }
            else if (orderStatus == OrderStatusEnum.COMPLETED)
            {
                orderListPanel.TableId = $"table-{(int)OrderStatusEnum.COMPLETED}";
                orderListPanel.PanelTitle = "Tamamlanan Siparişler";
                orderListPanel.PanelClass = "panel panel-primary";
                orderListPanel.HtmlButton = "<i class='fa fa-check text-success'></i> Sipariş Tamamlandı";
            }
            else if (orderStatus == OrderStatusEnum.CANCELED)
            {
                orderListPanel.TableId = $"table-{(int)OrderStatusEnum.CANCELED}";
                orderListPanel.PanelTitle = "İptal Edilen Siparişler";
                orderListPanel.PanelClass = "panel panel-danger";
                orderListPanel.HtmlButton = "<i class='fa fa-close text-danger'></i> Sipariş İptal Edildi";
            }
            return orderListPanel;
        }
    }
}