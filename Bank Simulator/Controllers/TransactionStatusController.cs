using Bank_Simulator.Models;
using Bank_Simulator.Services.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionStatusController : ControllerBase
    {
     
        private readonly ITransactionStatusService transactionStatusService;
        public TransactionStatusController(ITransactionStatusService transactionStatus)
        {
            
            this.transactionStatusService = transactionStatus;
        }

        [Route("ApproveOrDeclineTransaction")]
        [HttpPost()]

        public ActionResult ApproveOrDeclineTransaction([FromBody] TransactionDetailsModel user,[FromServices] TransactionRequestResultModel authorization)
        {

            if (ModelState.IsValid)
            {
                var orchestrator = transactionStatusService.TransactionStatus(user, authorization);
                return Ok(orchestrator);
            }
            else
            {
                return BadRequest();
            }
        }
    }

}
