using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment_Gateway.Models;

namespace Payment_Gateway.Service
{
    public interface IGatewayService
    {
        RetrievePayementResponseDTO findRequest(RetrievePayementRequestDTO r);
        ProcessPaymentResponseDTO AddNewRequest(ProcessPaymentRequestDTO m, Guid bankResponse, Status status);
        bool ifNotExists(int ID);
    }
}
