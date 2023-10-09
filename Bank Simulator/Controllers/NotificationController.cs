
using Bank_Simulator.Models;
using Bank_Simulator.Orchestration.Interfaces;
using Bank_Simulator.Services.Interfaces.Transactions;
using FirebaseAdmin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bank_Simulator.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly ITransactionStatusOrchestration _transactionStatusOrchestration;
        public NotificationController(INotificationService notificationService,ITransactionStatusOrchestration transactionStatusOrchestration)
        {
            _notificationService = notificationService;
            _transactionStatusOrchestration = transactionStatusOrchestration;
        }

        [Route("notification")]
        [HttpPost()]
        public IActionResult SendNotifications()
        {
            _notificationService.SendNotification();
            return Ok(new { Status = "Notification Sent"});
        }

        [Route("authorizationResponse")]
        [HttpGet()]
        public IActionResult GetNotificationsAuthResponse([FromBody] TransactionDetailsModel user, [FromBody] TransactionRequestResultModel authorization)
        {

            if (ModelState.IsValid)
            {
                var orchestration = _transactionStatusOrchestration.ApproveOrDeclineTransaction(user, authorization);
                return Ok(orchestration);
            }
                return BadRequest();
        }
    }
}
