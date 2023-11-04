using Bank_Simulator.Models;
using Bank_Simulator.Orchestration.Interfaces;
using Bank_Simulator.Services.Implementation.Transactions;
using Bank_Simulator.Services.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Orchestration.Implementation
{
    public class TransactionRequestOrchestration : ITransactionStatusOrchestration
    {
        private readonly ITransactionStatusService transactionStatusService;
        private readonly INotificationService _notificationService;
        public TransactionRequestOrchestration(ITransactionStatusService transactionStatus, INotificationService notificationService)
        {
            transactionStatusService = transactionStatus;
            _notificationService = notificationService;
        }
        public async Task SendNotificationToUserMobile()
        {
             await _notificationService.SendNotification().ConfigureAwait(false);
        }

        public ApprovalResponseModel ApproveOrDeclineTransaction(EntityDetails entityDetails, bool isApproved)
        {
           // EntityDetails user = new();
            if (isApproved.Equals(false))
                return new ApprovalResponseModel(false);
            else
                return transactionStatusService.TransactionApproval(entityDetails, isApproved);
        }
    }
}
