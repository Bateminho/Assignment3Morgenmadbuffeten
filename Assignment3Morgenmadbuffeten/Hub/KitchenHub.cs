using Microsoft.AspNetCore.SignalR;
namespace Assignment3Morgenmadsbuffeten.Hub
{
    public class KitchenHub : Hub<IKitchenHub>
    {
        public async Task KitchenUpdate()
        {
            await Clients.All.KitchenUpdate();
        }
    }
}
