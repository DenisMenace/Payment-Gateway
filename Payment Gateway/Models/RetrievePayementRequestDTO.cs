using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment_Gateway.Models
{
    public class RetrievePayementRequestDTO
    {
        public int MerchantID { get; set; }
        public Guid TransactionID { get; set; }
    }
}