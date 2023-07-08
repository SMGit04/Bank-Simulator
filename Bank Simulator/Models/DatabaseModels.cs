﻿using System.ComponentModel.DataAnnotations;

namespace Bank_Simulator.Models
{
    public class DatabaseModels
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        [Key]
        public string IDNumber { get; set; } 
        public string CardNumber { get; set; }
        public string AccountNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string AccountBalance { get; set; }
        public string CVV { get; set; }
        public string PIN { get; set; }


    }
}
