using Microsoft.AspNet.SignalR;

namespace CBProject.Areas.Forum
{
    public class ForumHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void Send(string name, string message)
        {
            Clients.All.broadcastMessage(name, message);
        }
    }
}