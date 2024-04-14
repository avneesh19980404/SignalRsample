using Microsoft.AspNetCore.SignalR;

namespace SignalRsample.Hubs
{
    public class DeathlyHollowHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
