using Bank_Simulator.Models;

namespace Bank_Simulator.Orchestration.Interfaces
{
    public interface ICardValidatorOrchestration
    {
        public CardResultModel CardNumberIsValid(string cardNumber);
    }
}
