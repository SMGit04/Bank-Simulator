namespace Bank_Simulator.Models
{
    public class CardResultModel
    {
        public bool IsValid { get; set; }
        public string? ResponseMessage { get; set; }

        public CardResultModel(bool isValid, string responseMessage = "")
        {
            
            IsValid = isValid;
            ResponseMessage = responseMessage;
        }
    }
}
