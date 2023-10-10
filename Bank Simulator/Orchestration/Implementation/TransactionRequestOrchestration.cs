﻿using Bank_Simulator.Models;
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

        public ResultModel ApproveOrDeclineTransaction([FromServices] TransactionRequestResultModel authorization)
        {
            TransactionDetailsModel user = new();
            if (authorization.responseMessage.Equals(false))
                return new ResultModel("Declined");
            else
                return transactionStatusService.TransactionStatus(user, authorization);
        }

        public async Task SendNotificationToUserMobile()
        {
             await _notificationService.SendNotification().ConfigureAwait(false);
        }
    }
}
