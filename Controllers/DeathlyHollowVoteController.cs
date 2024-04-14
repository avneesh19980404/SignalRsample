using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRsample.Hubs;
using SignalRsample.Hubs.Store;

namespace SignalRsample.Controllers
{
    public class DeathlyHollowVoteController : Controller
    {
        private readonly IHubContext<DeathlyHollowHub> _deathlyHollowContext;
        public DeathlyHollowVoteController(IHubContext<DeathlyHollowHub> deathlyHollowContext)
        {
            _deathlyHollowContext = deathlyHollowContext;
        }
        // GET: DeathlyHollowVote/votes?type="cloak"
        public async Task<ActionResult> Votes(string type)
        {
            if(SD.Votes.ContainsKey(type)){
                SD.Votes[type]++;
            }
            await _deathlyHollowContext.Clients.All.SendAsync("onVotesRecieved", SD.Votes[SD.Cloak], SD.Votes[SD.Stone], SD.Votes[SD.Wand]);
            ViewBag.Type = type;
            return View("Votes");
        }
    }
}
