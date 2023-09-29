
using Bank_Simulator.Models;
using Bank_Simulator.Services.Interfaces.Transactions;
using FirebaseAdmin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Bank_Simulator.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [Route("notification")]
        [HttpPost()]
        public IActionResult SendNotifications()
        {
         
            _notificationService.SendNotification();
            return Ok(new { Status = "Sent"});
        }

        [Route("authorizationResponse")]
        [HttpGet()]
        public IActionResult GetNotificationsAuthResponse([FromBody] TransactionRequestResultModel authorization) { 
        
                return Ok(new {StatusCode = 200});
        }
    }
}
