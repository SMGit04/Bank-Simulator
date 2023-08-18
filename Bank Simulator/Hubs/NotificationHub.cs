using Bank_Simulator.Services.Interfaces.Transactions;
using Microsoft.AspNetCore.SignalR;

namespace Bank_Simulator.Remote;

public class NotificationHub : Hub<INotificationHub>
{

    public async Task SendNotification(string message)
    {
        await Clients.All.SendNotification(message);
    }

    //public void sendnotification(string message)
    //{

    //    Clients.All.SendAsync("broadcastmessage", message);

    //}
}


