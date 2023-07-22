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
        public TransactionChecksService(IEncrptionService rsaHelper, DataContext dataContext)
        {
            _rsaHelper = rsaHelper;
            _context = dataContext;
        }

        

        public bool UserHasEnoughMoney([FromBody] TransactionDetailsModel user)
        {
            DatabaseModels? databaseModel = _context.DatabaseModels.FirstOrDefault(id => id.IDNumber == user.IDNumber);

            if (databaseModel != null && databaseModel.AccountBalance >= user.Amount)
            {
                DeductAmountFromUserAccount(user);
                return true;
            }
            return false;

        }

        public int DeductAmountFromUserAccount([FromBody] TransactionDetailsModel user)
        {
            DatabaseModels? databaseModel = _context.DatabaseModels.FirstOrDefault(id => id.IDNumber == user.IDNumber);

            if (databaseModel != null)
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
                // string clearTextCvv = _rsaHelper.Decrypt(user.CVV);
                string clearTextCvv = user.CVV;
                DatabaseModels ? databaseModelId = _context.DatabaseModels.FirstOrDefault(id => id.IDNumber == user.IDNumber);

                return databaseModelId != null && clearTextCvv.Equals(databaseModelId.CVV, StringComparison.Ordinal);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
