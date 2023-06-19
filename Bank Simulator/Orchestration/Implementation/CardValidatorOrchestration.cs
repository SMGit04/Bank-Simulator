using Bank_Simulator.Models;
using Bank_Simulator.Orchestration.Interfaces;
using Bank_Simulator.Services.Interfaces;

namespace Bank_Simulator.Orchestration.Implementation
{
    public class CardValidatorOrchestration : ICardValidatorOrchestration
    {
        private readonly ICardValidatorService cardValidatorService;

        public CardValidatorOrchestration(ICardValidatorService cardValidatorService)
        {
            this.cardValidatorService = cardValidatorService;
        }

        public CardResultModel CardNumberIsValid(string cardNumber)
        {
            return cardValidatorService.CardNumberIsValid(cardNumber);
        }

    }
}
