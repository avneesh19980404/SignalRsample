using Microsoft.AspNetCore.SignalR;
using SignalRsample.Hubs.Store;

namespace SignalRsample.Hubs
{
    public class UserHub : Hub
    {
        public static int UserCounter { get; set; }
        public async Task OnNewUserConnected()
        {
            UserCounter++;
            await Clients.All.SendAsync("onNewUserRecieved", UserCounter);
            await Clients.All.SendAsync("onVotesRecieved", SD.Votes[SD.Cloak], SD.Votes[SD.Stone], SD.Votes[SD.Wand]);
        }
    }
}
