namespace Bank_Simulator.Models
{
    public class TransactionResultModel
    {
        public string Status { get; set; } 

        public TransactionResultModel(string status)
        {
            Status = status;
        }
    }
}
