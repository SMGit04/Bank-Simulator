﻿namespace Bank_Simulator.Models
{
    public class TransactionResultModel
    {
        public string Status { get; set; } 
        public string? Response { get; set; }

        public TransactionResultModel(string status, string response = "")
        {
            Status = status;
            Response = response;
        }
    }
}
