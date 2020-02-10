using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment_Gateway.Models
{
    public class ProcessPaymentRequestDTO
    {
        public int MerchantID { get; set; }
        public long CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public int CVV { get; set; }
    }
}