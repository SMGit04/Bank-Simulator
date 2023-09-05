using Bank_Simulator.Remote;
using Bank_Simulator.Services.Interfaces.Transactions;
using FirebaseAdmin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Bank_Simulator.Controllers
{
    public class NotificationController : ControllerBase
    {

        private readonly INotificationService _hubContext;
        public NotificationController(INotificationService hubContext)
        {
            _hubContext = hubContext;
        }


        [HttpPost("api/notification")]
        public IActionResult SendNotifications(string message)
        {
            // TODO: Implement message send logic
            _hubContext.SendNotification();
            return Ok(new { Status = "Sent", Message = message });
        }
    }
}
