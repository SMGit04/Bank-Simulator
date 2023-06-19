using Bank_Simulator.Models;

namespace Bank_Simulator.Services.Interfaces
{
    public interface ICardValidatorService
    {
        public CardResult CardNumberIsValid(string cardNumber);
    }
}
