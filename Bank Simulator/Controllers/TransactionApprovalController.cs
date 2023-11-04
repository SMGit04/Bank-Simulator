using Bank_Simulator.Models;
using Bank_Simulator.Orchestration.Interfaces;
using Bank_Simulator.Services.Implementation.Transactions;
using Bank_Simulator.Services.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Bank_Simulator.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionRequestController : ControllerBase
    {
        //private readonly ConcurrentDictionary<string, TaskCompletionSource<bool>> _pendingAuths = new ConcurrentDictionary<string, TaskCompletionSource<bool>>();
        private readonly ITransactionStatusOrchestration _transactionStatusOrchestration;
        private readonly NotificationController _notificationController;
        private readonly TransactionService _transactionService;

        public TransactionRequestController(ITransactionStatusOrchestration transactionStatusOrchestration, NotificationController notificationController, TransactionService transactionService)
        {
            _transactionStatusOrchestration = transactionStatusOrchestration;
            _notificationController = notificationController;
            _transactionService = transactionService;
        }

        [Route("dataFromUser")]
        [HttpPost()]
        public async Task<IActionResult> DataFromUserEndpoint(EntityDetails entityDetails)
        {
            var tcs = new TaskCompletionSource<bool>();
            _transactionService.PendingAuths.TryAdd(entityDetails.IDNumber, tcs);

            // Wait for the user authentication or timeout (30 seconds)
            if (await Task.WhenAny(tcs.Task, Task.Delay(60000)) == tcs.Task && tcs.Task.Result)
            {
                _transactionService.PendingAuths.TryRemove(entityDetails.IDNumber, out _);
                var orchestration = _transactionStatusOrchestration.ApproveOrDeclineTransaction(entityDetails, tcs.Task.Result);

                return Ok(orchestration);
            }
            else
            {
                // Timeout or declined
                _transactionService.PendingAuths.TryRemove(entityDetails.IDNumber, out _);
                return BadRequest("Transaction declined or timeout");
            }
        }
        [Route("ApproveOrDeclineTransaction")]  //  userResponseAuth
        [HttpPost()]
        public IActionResult TransactionRequest([FromBody] ApprovalRequestResultModel authorization)
        {
            if (_transactionService.PendingAuths.TryGetValue(authorization.userID, out var tcs))
            {
                tcs.SetResult(authorization.isApproved);
            }

            return Ok();
            
        }
    }
}


/*
             if (ModelState.IsValid)
            {
                try
                {
                    if (_pendingAuths.TryGetValue(tempId, out var taskCompletionSource))
                    {
                        taskCompletionSource.SetResult(authorization.isApproved);
                    }

                    var orchestration = _transactionStatusOrchestration.ApproveOrDeclineTransaction(authorization);

                    return Ok(orchestration);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"An error occurred: {ex.Message}");
                }
            }
            return BadRequest();
*/