using Bank_Simulator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank_Simulator.Services.Interfaces.Transactions
{
    public interface ITransactionChecksService
    {
        public bool UserHasEnoughMoney([FromBody] EntityDetails user);
        public bool ValidateCvvNumber([FromBody] EntityDetails user);
    }
}
