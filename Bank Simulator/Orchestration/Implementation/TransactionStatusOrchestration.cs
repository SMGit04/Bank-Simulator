using Bank_Simulator.Models;
using Bank_Simulator.Orchestration.Interfaces;
using Bank_Simulator.Services.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Orchestration.Implementation
{
    public class TransactionStatusOrchestration : ITransactionStatusOrchestration
    {
        private readonly ITransactionStatusService transactionStatusService;
        public TransactionStatusOrchestration(ITransactionStatusService transactionStatus)
        {

            transactionStatusService = transactionStatus;
        }

        public ResultModel ApproveOrDeclineTransaction([FromBody] TransactionDetailsModel user, [FromServices] TransactionRequestResultModel authorization)
        {
            if (authorization.responseMessage.Equals(true))
                return new ResultModel("Declined");
            else
                return transactionStatusService.TransactionStatus(user, authorization);
        }
    }
}
