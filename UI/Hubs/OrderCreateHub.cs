using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace UI.Hubs
{
    public class OrderCreateHub : Hub
    {
        public async Task SendOrderMessage(string orderId)
        {
            await Clients.All.SendAsync("ReceiveOrderMessage", orderId);
        }
    }
}