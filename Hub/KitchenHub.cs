using Microsoft.AspNetCore.SignalR;
namespace Assignment3Morgenmadbuffeten.Hub
{
    public class KitchenHub : Hub<IKitchenHub>
    {
     public async Task KitchenUpdate()
     {
        await Clients.All.KitchenUpdate();
     }   
    }
}