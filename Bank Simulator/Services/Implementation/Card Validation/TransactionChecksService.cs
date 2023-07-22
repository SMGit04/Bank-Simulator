using Bank_Simulator.Database;
using Bank_Simulator.Models;
using Bank_Simulator.Services.Interfaces;
using Bank_Simulator.Services.Interfaces.Encryption;
using Bank_Simulator.Services.Interfaces.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Services.Implementation.Card_Validation
{
    public class TransactionChecksService : ITransactionChecksService
    {
        private readonly IEncrptionService _rsaHelper;
        private readonly DataContext _context;
        private readonly IErrorCodesServices _ErrorCodes;
        public TransactionChecksService(IEncrptionService rsaHelper, DataContext dataContext, IErrorCodesServices errorCodesServices)
        {
            _rsaHelper = rsaHelper;
            _context = dataContext;
            _ErrorCodes = errorCodesServices;
        }


        public bool UserHasEnoughMoney([FromBody] TransactionDetailsModel user)
        {
            DatabaseModels? databaseModel = _context.DatabaseModels.FirstOrDefault(id => id.IDNumber == user.IDNumber);
            return databaseModel != null && databaseModel.AccountBalance >= user.Amount;

            //if (databaseModel != null && databaseModel.AccountBalance >= user.Amount)
            //{
            //    return new TransactionResultModel("Approved");
            //}
            //else
            //    return new TransactionResultModel("Declined", _ErrorCodes.GetErrorCode(Enums.ErrorCodes.InsufficientAmount));
        }

        public int DeductAmountFromUserAccount([FromBody] TransactionDetailsModel user)
        {
            DatabaseModels? databaseModel = _context.DatabaseModels.FirstOrDefault(id => id.IDNumber == user.IDNumber);

            if (databaseModel != null && UserHasEnoughMoney(user))
            {
                databaseModel.AccountBalance -= user.Amount;
                _context.SaveChanges();
                return databaseModel.AccountBalance;
            }
            return -1;
        }

        public bool ValidateCvvNumber([FromBody] TransactionDetailsModel user)
        {
            try
            {
                string clearTextCvv = _rsaHelper.Decrypt(user.CVV);     // The user.CVV is encrypted, so we need to decrypt it first
                DatabaseModels? databaseModelId = _context.DatabaseModels.FirstOrDefault(id => id.IDNumber == user.IDNumber);

                return databaseModelId != null && clearTextCvv.Equals(databaseModelId.CVV, StringComparison.Ordinal);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
