using Bank_Simulator.Models;
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

        public ApprovalResponseModel TransactionApproval([FromBody] TransactionDetailsModel user, [FromServices] ApprovalRequestResultModel authorization)
        {

            switch (authorization.isApproved)
            {
                case true:
                    if (_transactionChecksService.UserHasEnoughMoney(user) && _transactionChecksService.ValidateCvvNumber(user))
                    {
                        return new ApprovalResponseModel(true); // "Approved";
                    }
                    else
                    {
                        return new ApprovalResponseModel(false); // "Declined";
                    }

                case false:
                    return new ApprovalResponseModel(false);
            }

        }
    }
}
