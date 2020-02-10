using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Payment_Gateway.Models
{
    public class Request
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid RequestID { get; set; }
        public long CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public int CVV { get; set; }
        public Guid? BankResponseID { get; set; }
        public Status? BankStatus { get; set; }
        public DateTime RequestDate { get; set; }
        public int MerchantID { get; set; }
        public virtual Merchant Merchant { get; set; }
    }

}