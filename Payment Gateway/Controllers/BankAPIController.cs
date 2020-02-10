using Payment_Gateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Payment_Gateway.Controllers
{
    public class BankAPIController : ApiController
    {

        public IHttpActionResult BankAPI([FromBody]ProcessPaymentRequestDTO merchantRequestDTO)
        {
            var bankResponseID = Guid.NewGuid();
            var bankStatus = Status.Unsuccessfull;

            var bank = new BankResponse()
            {
                BankResponseID = bankResponseID,
                BankStatus = bankStatus
            };

            return Json(bank);

        }

    }
}
