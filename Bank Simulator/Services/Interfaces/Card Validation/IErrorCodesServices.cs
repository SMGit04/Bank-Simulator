using Bank_Simulator.Enums;

namespace Bank_Simulator.Services.Interfaces
{
    public interface IErrorCodesServices
    {
        public string GetErrorCode(ErrorCodes errorCode);
    }
}
