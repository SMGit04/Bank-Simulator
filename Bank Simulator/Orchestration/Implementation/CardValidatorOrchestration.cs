//using Bank_Simulator.Models;
//using Bank_Simulator.Orchestration.Interfaces;
//using Bank_Simulator.Services.Interfaces;
//using Bank_Simulator.Services.Interfaces.Transactions;
//using Microsoft.AspNetCore.Mvc;

//namespace Bank_Simulator.Orchestration.Implementation
//{
//    public class CardValidatorOrchestration : ICardValidatorOrchestration
//    {
//        private readonly ICardValidatorService cardValidatorService;
//        private readonly ITransactionStatusService transactionStatusService;

//        public CardValidatorOrchestration(ICardValidatorService cardValidatorService, ITransactionStatusService transactionStatus)
//        {
//            this.cardValidatorService = cardValidatorService;
//            this.transactionStatusService = transactionStatus;
//        }

//        public CardResultModel CardNumberIsValid(string cardNumber)
//        {
//            return cardValidatorService.CardNumberIsValid(cardNumber);
//        }

//        public ResultModel TransactionIsValid([FromBody] TransactionDetailsModel user)
//        {
//            return transactionStatusService.TransactionStatus(user);
//        }

//    }
//}
