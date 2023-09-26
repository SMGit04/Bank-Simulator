using Bank_Simulator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Services.Interfaces.Transactions
{
    public interface ITransactionStatusService
    {
        public ResultModel TransactionStatus([FromBody] TransactionDetailsModel user, [FromBody] TransactionRequestResultModel authorization);
    }
}
