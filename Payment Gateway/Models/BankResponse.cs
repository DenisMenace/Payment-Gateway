using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment_Gateway.Models
{
    public class BankResponse
    {
        public Guid BankResponseID { get; set; }
        public Status BankStatus { get; set; }
    }
}