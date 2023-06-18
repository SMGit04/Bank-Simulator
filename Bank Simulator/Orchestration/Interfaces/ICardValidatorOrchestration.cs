using Bank_Simulator.Models;

namespace Bank_Simulator.Orchestration.Interfaces
{
    public interface ICardValidatorOrchestration
    {
        public CardResult CardNumberIsValid(string cardNumber);
    }
}
