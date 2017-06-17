using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace two_way_sockets.App_Code
{
    public class SessionsHub : Hub
    {
        public Task AddGroups()
        {
            return Groups.Add(Context.ConnectionId, "english");
        }

        public void SendMessage(string message)
        {
            Clients.Group("english").SendMessage("ENGLISH:" + message);
            // Call the JavaScript method sendSessionChanged on all the clients
            Clients.All.SendMessage(message);
        }

        ////automatically join groups when client first connects
        //public override Task OnConnected()
        //{
        //    return AddGroups();
        //}

        ////rejoin groups if client disconnects and then reconnects
        //public override Task OnReconnected()
        //{
        //    return AddGroups();
        //}
    }
}