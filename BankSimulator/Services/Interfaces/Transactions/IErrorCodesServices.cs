using Bank_Simulator.Enums;

namespace Bank_Simulator.Services.Interfaces.Transactions
{
    public interface IErrorCodesServices
    {
        public string GetErrorCode(ErrorCodes errorCode);
    }
}
