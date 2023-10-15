using Bank_Simulator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Orchestration.Interfaces
{
    public interface ITransactionStatusOrchestration
    {
        public ApprovalResponseModel ApproveOrDeclineTransaction([FromServices] TransactionRequestResultModel authorization);
        public Task SendNotificationToUserMobile();
    }
}
