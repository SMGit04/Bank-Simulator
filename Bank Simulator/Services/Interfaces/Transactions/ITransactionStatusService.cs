using Bank_Simulator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Services.Interfaces.Transactions
{
    public interface ITransactionStatusService
    {
        public ApprovalResponseModel TransactionApproval([FromBody] EntityDetails user, bool isApproved);
    }
}
