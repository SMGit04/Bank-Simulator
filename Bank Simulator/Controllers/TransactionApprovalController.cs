using Bank_Simulator.Models;
using Bank_Simulator.Orchestration.Interfaces;
using Bank_Simulator.Services.Implementation.Transactions;
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
        private readonly ITransactionStatusOrchestration _transactionStatusOrchestration;
        private readonly TransactionService _transactionService;

        public TransactionRequestController(ITransactionStatusOrchestration transactionStatusOrchestration, TransactionService transactionService)
        {
            _transactionStatusOrchestration = transactionStatusOrchestration;
            _transactionService = transactionService;
        }

        [Route("entityTransactionData")]
        [HttpPost()]
        public async Task<IActionResult> DataFromUserEndpoint(EntityDetails entityDetails)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();
            _transactionService.PendingAuths.TryAdd(entityDetails.IDNumber, taskCompletionSource);

            if (ModelState.IsValid)
            {
                // Wait for the user authentication or timeout after 30 seconds
                if (await Task.WhenAny(taskCompletionSource.Task, Task.Delay(30000)) == taskCompletionSource.Task && taskCompletionSource.Task.Result)
                {
                    _transactionService.PendingAuths.TryRemove(entityDetails.IDNumber, out _);
                    var orchestration = _transactionStatusOrchestration.ApproveOrDeclineTransaction(entityDetails, taskCompletionSource.Task.Result);

                    return Ok(orchestration);
                }
            }
            _transactionService.PendingAuths.TryRemove(entityDetails.IDNumber, out _);
            return BadRequest("Transaction declined or timeout");

        }
        [Route("ApproveOrDeclineTransaction")] 
        [HttpPost()]
        public IActionResult TransactionRequest([FromBody] ApprovalRequestResultModel authorization)
        {
            if (_transactionService.PendingAuths.TryGetValue(authorization.userID, out var taskCompletionSource))
            {
                taskCompletionSource.SetResult(authorization.isApproved);
                return Ok();
            }

            return BadRequest();
            
        }
    }
}