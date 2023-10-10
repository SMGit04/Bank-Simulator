using Bank_Simulator.Models;
using Bank_Simulator.Orchestration.Interfaces;
using Bank_Simulator.Services.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]

    public class TransactionRequestController : ControllerBase
    {
        private readonly ITransactionStatusOrchestration _transactionStatusOrchestration;

        public TransactionRequestController(ITransactionStatusOrchestration transactionStatusOrchestration)
        {
            _transactionStatusOrchestration = transactionStatusOrchestration;
        }

        [Route("ApproveOrDeclineTransaction")]
        [HttpPost()]

        public ActionResult TransactionRequest([FromBody] TransactionDetailsModel _ )
        {
            if (ModelState.IsValid)
            {
                 _transactionStatusOrchestration.SendNotificationToUserMobile();
                return Ok();
            }
                return BadRequest();
        }

    }
}
