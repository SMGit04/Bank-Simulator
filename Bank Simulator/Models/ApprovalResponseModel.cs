namespace Bank_Simulator.Models
{
    public class ApprovalResponseModel
    {
        public bool IsApproved { get; set; } 

        public ApprovalResponseModel(bool status)
        {
            IsApproved = status;
        }
    }
}
