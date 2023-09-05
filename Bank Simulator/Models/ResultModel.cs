namespace Bank_Simulator.Models
{
    public class ResultModel
    {
        public string Status { get; set; } 

        public ResultModel(string status)
        {
            Status = status;
        }
    }
}
