
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
        private TaskCompletionSource<TransactionRequestResultModel> authorizationResponseTask = new TaskCompletionSource<TransactionRequestResultModel>();
        public NotificationController(INotificationService notificationService, ITransactionStatusOrchestration transactionStatusOrchestration)
        {
            _notificationService = notificationService;
            _transactionStatusOrchestration = transactionStatusOrchestration;
        }

        [Route("notification")]
        [HttpPost()]
        public IActionResult SendNotifications()
        {
            _notificationService.SendNotification();
            return Ok(new { Status = "Notification Sent" });
        }

        [Route("authorizationResponse")]
        [HttpPost()]
        public ActionResult GetNotificationsAuthResponse([FromBody] TransactionRequestResultModel authorization)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    authorizationResponseTask.SetResult(authorization);
                //     var result = await authorizationResponseTask.Task.ConfigureAwait(false);
                    var result = WaitForAuthorizationResponseAsync().ConfigureAwait(false);

                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
            return BadRequest();
        }


        [Route("waitForAuthorizationResponse")]
        [HttpGet] // Use HTTP GET for waiting
        public  Task<TransactionRequestResultModel> WaitForAuthorizationResponseAsync()
        {

            var authorizationResponse =  authorizationResponseTask.Task;
            return authorizationResponse;

        }
    }
}
