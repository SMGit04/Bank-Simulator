
using Bank_Simulator.Services.Interfaces.Transactions;
using FirebaseAdmin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Bank_Simulator.Controllers
{
    public class NotificationController : ControllerBase
    {

        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        [HttpPost("api/notification")]
        public IActionResult SendNotifications()
        {
         
            _notificationService.SendNotification();
            return Ok(new { Status = "Sent"});
        }
    }
}
