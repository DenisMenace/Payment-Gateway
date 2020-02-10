using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment_Gateway.Models
{
    public class ProcessPaymentResponseDTO
    {
        public Guid TransactionID { get; set; }
        public string Status { get; set; }
        public string TransactionDate { get; set; }

    }
}