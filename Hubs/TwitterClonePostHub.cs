using Microsoft.AspNet.SignalR;

namespace TwitterClone.Hubs
{
    public class TwitterClonePostHub : Hub
    {
        public void RefreshTwitterClones()
        {
            Clients.All.refreshTwitterClones();
        }
    }
}
