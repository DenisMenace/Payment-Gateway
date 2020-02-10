using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Payment_Gateway.DAL;
using Payment_Gateway.Models;
using Payment_Gateway.Service;

namespace Payment_Gateway.Controllers
{
    public class RequestController : ApiController
    {

        IGatewayService _gateWayService;

        public RequestController(IGatewayService gateWayService)
        {
            _gateWayService = gateWayService;
        }

        //FromBody attributes only binds the data from the body of request    
        public IHttpActionResult ProcessPayment([FromBody] ProcessPaymentRequestDTO merchantRequestDTO)
        {
            if (_gateWayService.ifNotExists(merchantRequestDTO.MerchantID)) return Json("No Mechant found");

            BankResponse bankResponse = null;
            //contact bank 
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:64388/");
                var response = client.PostAsJsonAsync("api/BankAPI/BankAPI", merchantRequestDTO);
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BankResponse>();
                    readTask.Wait();
                    bankResponse = readTask.Result;
                }
                else
                {
                    return Json("Error contacting bank");
                }                  


            }

            return Json(_gateWayService.AddNewRequest(merchantRequestDTO, bankResponse.BankResponseID, bankResponse.BankStatus));

        }

        public IHttpActionResult RetrievePayment([FromBody] RetrievePayementRequestDTO retrievePayementRequestDTO)
        {

            if (_gateWayService.findRequest(retrievePayementRequestDTO)==null) return Json( "No Payments found");

            return Json(_gateWayService.findRequest(retrievePayementRequestDTO));
        }
    
    }
}
