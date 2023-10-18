using Bank_Simulator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Orchestration.Interfaces
{
    public interface ITransactionStatusOrchestration
    {
        public ApprovalResponseModel ApproveOrDeclineTransaction(ApprovalRequestResultModel authorization);
        public Task SendNotificationToUserMobile();
    }
}
