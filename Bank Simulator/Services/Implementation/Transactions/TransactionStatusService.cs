﻿using Bank_Simulator.Models;
using Bank_Simulator.Services.Interfaces;
using Bank_Simulator.Services.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Services.Implementation.Card_Validation
{
    public class TransactionStatusService : ITransactionStatusService
    {
        private readonly ITransactionChecksService _transactionChecksService;
        public TransactionStatusService(ITransactionChecksService transactionChecksService)
        {
            _transactionChecksService = transactionChecksService;
        }

        public TransactionResultModel TransactionStatus([FromBody] TransactionDetailsModel user)
        {
            if (_transactionChecksService.UserHasEnoughMoney(user) && _transactionChecksService.ValidateCvvNumber(user))
            {
                return new TransactionResultModel("Approved");
            }
            else
            {
                return new TransactionResultModel("Declined");
            }

        }
    }
}