using Bank_Simulator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Services.Interfaces.Card_Validation
{
    public interface ITransactionChecksService
    {
        public bool UserHasEnoughMoney([FromBody] TransactionDetailsModel user);

        public int DeductAmountFromUserAccount([FromBody] TransactionDetailsModel user);

        public bool DecryptCvvNumber([FromBody] TransactionDetailsModel user);
    }
}
