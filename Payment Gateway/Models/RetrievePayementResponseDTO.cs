using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment_Gateway.Models
{
    public class RetrievePayementResponseDTO
    {
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }

        public string TransactionStatus { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}