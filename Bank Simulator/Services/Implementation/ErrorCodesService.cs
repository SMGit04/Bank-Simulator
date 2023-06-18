using Bank_Simulator.Enums;
using Bank_Simulator.Services.Interfaces;
using System.Xml.Schema;

namespace Bank_Simulator.Services.Implementation
{
    public class ErrorCodesService : IErrorCodesServices
    {
        private readonly Dictionary<ErrorCodes, string> storeErrorCode = new Dictionary<ErrorCodes, string>();

        public ErrorCodesService() {
            storeErrorCode.Add(ErrorCodes.InsufficientAmount, "Insufficient Funds in account");
            storeErrorCode.Add(ErrorCodes.InvalidCardNumber, "Card Number is Invalid");
            storeErrorCode.Add(ErrorCodes.UnknowBiometrics, "Authentication Failed, Biometrics did not math");
            storeErrorCode.Add(ErrorCodes.TransacationDeclined, "Transactioon was declined by user");
        }
        public string GetErrorCode(ErrorCodes errorCode)
        {
            return storeErrorCode[errorCode];
        }
    }
}
