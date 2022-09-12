using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CBProject.Areas.Forum.SignalIrHubs
{
    public class ChatHub : Hub
    {
        // Example
        public void send(string user, string message)
        {
            Clients.All.broadcastMessage("ReceiveMessage", user, message);
        }
    }
}