using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Payment_Gateway.Models;

namespace Payment_Gateway.DAL
{
   public interface IUnitOfWork
    {
        IRepository<Merchant> Merchants { get; }
        IRepository<Request> Requests { get; }
        void SaveAll();

    }
}
