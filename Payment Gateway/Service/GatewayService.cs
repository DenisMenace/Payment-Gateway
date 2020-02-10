using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Payment_Gateway.DAL;
using Payment_Gateway.Models;

namespace Payment_Gateway.Service
{
    public class GatewayService : IGatewayService
    {
        IUnitOfWork _unitOfWork;

        public GatewayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public RetrievePayementResponseDTO findRequest(RetrievePayementRequestDTO r)
        {
            // Lazy loading has circular references from using navigation properties. Serializer has to read all the properties on the model. 
            //Need to use Data Transfer Objects DTOs 

            var request = _unitOfWork.Requests.Find(x => x.RequestID == r.TransactionID && x.MerchantID == r.MerchantID).Select(m => m).FirstOrDefault();

            if (request == null) return null;

            var response = new RetrievePayementResponseDTO()
            {
                CardNumber = request.CardNumber.ToString(),
                TransactionStatus = request.BankStatus.ToString(),
                ExpiryDate = request.ExpiryDate.ToString("dd/MM/yyy"),
                Currency = request.Currency,
                Amount = request.Amount,
                TransactionDate = request.RequestDate
            };

            var str = response.CardNumber;

            response.CardNumber =  string.Concat("".PadLeft(12, '*'), str.Substring(str.Length - 4));

            return response;
        }

        public ProcessPaymentResponseDTO AddNewRequest(ProcessPaymentRequestDTO m, Guid bankResponse, Status status)
        {
            var transactionID = Guid.NewGuid();
            var requestDate = DateTime.Today;


            _unitOfWork.Requests.Add(new Request()
            {
                RequestID = transactionID,
                CardNumber = m.CardNumber,
                ExpiryDate = m.ExpiryDate,
                Amount = m.Amount,
                Currency = m.Currency,
                CVV = m.CVV,
                RequestDate = requestDate,
                MerchantID = m.MerchantID,
                BankResponseID = bankResponse,
                BankStatus = status

            });

            _unitOfWork.SaveAll();

            return new ProcessPaymentResponseDTO()
            {
                TransactionID = transactionID,
                Status = status.ToString(),
                TransactionDate = requestDate.ToString("dd/MM/yyyy hh:mm:ss")
            };

        }
        public bool ifNotExists(int ID)
        {
            var query = _unitOfWork.Merchants.Find(x => x.MerchantID == ID).Select(x => x).FirstOrDefault();

            if (query == null) return true;

            return false;
        }
    }
}