using Bank_Simulator.Models;
using Bank_Simulator.Orchestration.Interfaces;
using Bank_Simulator.Services.Implementation.Transactions;
using Bank_Simulator.Services.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

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
        public async Task<ActionResult> TransactionRequest([FromBody] ApprovalRequestResultModel authorization)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cancellationTokenSource = new CancellationTokenSource();
                    var cancellationToken = cancellationTokenSource.Token;

                    Task.Run(() =>
                    {
                        var blocker = authorization.isBlocked;
                        while (blocker)
                        {
                            if (cancellationToken.IsCancellationRequested)
                            {
                                break; // Exit the loop if cancellation is requested.
                            }
                        }
                    });

                    // Now that isBlocked is false, execute the code inside the loop.
                    cancellationTokenSource.Cancel(); // Cancel the loop

                    var orchestration = _transactionStatusOrchestration.ApproveOrDeclineTransaction(authorization);

                    return Ok(orchestration);
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
