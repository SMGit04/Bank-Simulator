using Bank_Simulator.Remote;
using Bank_Simulator.Services.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Bank_Simulator.Controllers
{
    public class NotificationHubController : ControllerBase
    {
        //private readonly IHubContext<NotificationHub, INotificationHub> _hubContext;
        //public NotificationHubController(IHubContext<NotificationHub, INotificationHub> hubContext)
        //{
        //    _hubContext = hubContext;
        //}


        //[HttpPost("api/notification")]
        //public IActionResult SendNotifications(string message)
        //{
        //    _hubContext.Clients.All.SendNotification(message);
        //    return Ok( new { Status = "Sent", Message = message});
        //}

        private readonly IHubContext<NotificationHub> _hubContext;
        public NotificationHubController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }


        [HttpPost("api/notification")]
        public IActionResult SendNotifications(string message)
        {
            _hubContext.Clients.All.SendAsync("broadcastmessage", message);
            return Ok(new { Status = "Sent", Message = message });
        }
    }
}
