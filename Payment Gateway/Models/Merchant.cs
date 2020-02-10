using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Payment_Gateway.Models
{
    public class Merchant
    {
        public int MerchantID { get; set; }
        public string MerchantName { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        //public string Password { get; set; }

    }
}