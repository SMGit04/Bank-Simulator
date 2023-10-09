namespace Bank_Simulator.Models
{
    public class TransactionRequestResultModel
    {

        // Gets the authorization results from the Client mobile device *
        public bool responseMessage { get; set; }
        public bool biometricAuthenticated { get; set; }
    }
}
