using System.ComponentModel.DataAnnotations;

namespace Bank_Simulator.Models
{

    public class TransactionDetailsModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IDNumber { get; set; }
        public string CardNumber { get; set; }
        public string AccountNumber { get; set; }
        public string ExpiryDate { get; set; }
        public int Amount { get; set; }
        public string CVV { get; set; }
        public string PIN { get; set; }
    }
}
