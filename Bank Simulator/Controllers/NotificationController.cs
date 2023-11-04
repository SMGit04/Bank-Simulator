
using Bank_Simulator.Models;
using Bank_Simulator.Orchestration.Interfaces;
using Bank_Simulator.Services.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Controllers
{
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly ITransactionStatusOrchestration _transactionStatusOrchestration;
        private TaskCompletionSource<ApprovalRequestResultModel> authorizationResponseTask = new();
        public NotificationController(INotificationService notificationService, ITransactionStatusOrchestration transactionStatusOrchestration)
        {
            _notificationService = notificationService;
            _transactionStatusOrchestration = transactionStatusOrchestration;
        }

        [Route("notification")]
        [HttpPost()]
        public IActionResult SendNotifications()
        {
            _ = _transactionStatusOrchestration.SendNotificationToUserMobile();
            return Ok(new { Status = "Notification Sent" });
        }
    }
}
