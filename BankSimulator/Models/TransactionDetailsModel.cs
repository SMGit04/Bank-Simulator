using System.ComponentModel.DataAnnotations;

namespace Bank_Simulator.Models
{

    public class TransactionDetailsModel
    {
        public string IDNumber { get; set; }
        public string CardNumber { get; set; }
        public string AccountNumber { get; set; }
        public string ExpiryDate { get; set; }
        public double TransactionAmount { get; set; }
        public string MerchantName { get; set; }
        public string CVV { get; set; }
    }
}