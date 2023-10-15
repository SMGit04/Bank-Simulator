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

        public ApprovalResponseModel TransactionApproval([FromBody] TransactionDetailsModel user, [FromServices] TransactionRequestResultModel authorization)
        {
            bool result = false;

            switch (authorization.responseMessage)
            {
                case true:

                    if (authorization.biometricAuthenticated.Equals(true))
                    {
                        if (_transactionChecksService.UserHasEnoughMoney(user) && _transactionChecksService.ValidateCvvNumber(user))
                        {
                            result = true; // "Approved";
                        }
                        else
                        {
                            result = false; // "Declined";
                        }
                    }
                    else
                    {
                        return new ApprovalResponseModel(result);
                    }
                    break;

                case false:
                    return new ApprovalResponseModel(result);
            }
            return new ApprovalResponseModel(result);

        }
    }
}
