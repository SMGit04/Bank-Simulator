using Bank_Simulator.Models;
using Bank_Simulator.Services.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class TransactionStatusController : ControllerBase
    {
     
        private readonly ITransactionStatusService transactionStatusService;
        public TransactionStatusController(ITransactionStatusService transactionStatus)
        {
            
            this.transactionStatusService = transactionStatus;
        }

        [HttpPost("api/ApproveOrDeclineTransaction")]

        public ActionResult ApproveOrDeclineTransaction([FromBody] TransactionDetailsModel user)
        {

            if (ModelState.IsValid)
            {
                var orchestrator = transactionStatusService.TransactionStatus(user);
                return Ok(orchestrator);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
