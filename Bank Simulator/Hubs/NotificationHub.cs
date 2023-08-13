using Microsoft.AspNetCore.SignalR;

namespace Bank_Simulator.Remote;

public class NotificationHub : Hub
{
    public void SendNotification(string message)
    {
        
        Clients.All.SendAsync("broadcastMessage", message);

    }

    // TODO: Add notification trigger:

    /*var context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
    context.Clients.All.broadcastMessage("Your message here");
    */
}


