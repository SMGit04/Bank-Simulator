namespace Bank_Simulator.Models
{
    public class CardResult
    {
        public bool IsValid { get; set; }
        public string? ResponseMessage { get; set; }

        public CardResult(bool isValid, string responseMessage = "")
        {
            
            IsValid = isValid;
            ResponseMessage = responseMessage;
        }
    }
}
