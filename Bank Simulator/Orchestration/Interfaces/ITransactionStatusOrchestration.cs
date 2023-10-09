using Bank_Simulator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Orchestration.Interfaces
{
    public interface ITransactionStatusOrchestration
    {
        public ResultModel ApproveOrDeclineTransaction([FromBody] TransactionDetailsModel user,
            [FromServices] TransactionRequestResultModel authorization);
    }
}
