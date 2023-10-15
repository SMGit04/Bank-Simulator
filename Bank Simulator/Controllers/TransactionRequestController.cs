using Bank_Simulator.Models;
using Bank_Simulator.Orchestration.Interfaces;
using Bank_Simulator.Services.Implementation.Transactions;
using Bank_Simulator.Services.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Bank_Simulator.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class TransactionRequestController : ControllerBase
    {
        private readonly ITransactionStatusOrchestration _transactionStatusOrchestration;
        private readonly NotificationController _notificationController;

        public TransactionRequestController(ITransactionStatusOrchestration transactionStatusOrchestration, NotificationController notificationController)
        {
            _transactionStatusOrchestration = transactionStatusOrchestration;
            _notificationController = notificationController;

        }

        [Route("ApproveOrDeclineTransaction")]
        [HttpPost()]
        public async Task<ActionResult> TransactionRequest([FromBody] TransactionDetailsModel transaction, [FromServices] TransactionRequestResultModel authorization)
        {
            // Task<ActionResult<TransactionRequestResultModel>>
            if (ModelState.IsValid)
            {
                try
                {
                    _ = _transactionStatusOrchestration.SendNotificationToUserMobile();

                    // Wait for the authorization response
                  //  var authorizationResponse = await _notificationController.WaitForAuthorizationResponseAsync();
                    var authorizationResponse = _notificationController.GetNotificationsAuthResponse(authorization);

                    if (authorizationResponse != null)
                    {
                        var orchestration = _transactionStatusOrchestration.ApproveOrDeclineTransaction(authorizationResponse);
                        return Ok(orchestration);
                    }
                    else
                    {
                        return BadRequest("Authorization response is null.");
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
            return BadRequest();
        }


    }
}
