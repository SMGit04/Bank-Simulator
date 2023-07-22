using Bank_Simulator.Enums;
using Bank_Simulator.Models;
using Bank_Simulator.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Bank_Simulator.Services.Implementation
{
    public class CardValidatorService : ICardValidatorService
    {

        private readonly IErrorCodesServices ErrorCodesServices;
        public CardValidatorService(IErrorCodesServices errorCodesServices)
        {
            ErrorCodesServices = errorCodesServices;
        }
        bool isValidNum = false;

        public readonly bool CardResults = new bool();
        private readonly Dictionary<string, bool> CardDatabase = new Dictionary<string, bool>();

        public CardResultModel CardNumberIsValid(string cardNumber)
        {
            if (LuhnAlgorithm(cardNumber))
            {
                return new CardResultModel(true);

            }
            else {
                
                return new CardResultModel(false, ErrorCodesServices.GetErrorCode(ErrorCodes.InvalidCardNumber));
                 }
        }

        private bool LuhnAlgorithm(string cardNumber)
        {
            int Total = 0; 
            bool isSecondDigit = false;

                for (int i = cardNumber.Length - 1; i >= 0; i--)
                {
                    if (!int.TryParse(cardNumber[i].ToString(), out int Digit))
                    {
 
                        return false; 
                    }

                    if (isSecondDigit)
                    {
                        Digit = DoubleNumber(Digit);
                    }

                    Total += Digit;

                    isSecondDigit = !isSecondDigit;
                }

                if (Total % 10 == 0)
                {
                    isValidNum = true;
                }
           
            return isValidNum;
        }
        private static int DoubleNumber(int num)
        {
            int doubleNum = num * 2;
            int sum = doubleNum > 9 ? doubleNum - 9 : doubleNum;
            return sum;
        }
    }
}
