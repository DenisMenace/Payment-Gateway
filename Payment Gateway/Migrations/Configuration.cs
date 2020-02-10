using Payment_Gateway.DAL;
using Payment_Gateway.Models;

namespace Payment_Gateway.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Payment_Gateway.DAL.GatewayContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GatewayContext context)
        {

            context.Merchants.AddOrUpdate(x => x.MerchantID,
                new Merchant() { MerchantID = 1, MerchantName = "NetFlix" });
            context.Merchants.AddOrUpdate(x => x.MerchantID,
                new Merchant() { MerchantID = 2, MerchantName = "AmazonPrime" });

            context.Requests.AddOrUpdate(x => x.RequestID, new Request()
            { 
                RequestID = Guid.NewGuid(),
                MerchantID = 1,
                CardNumber = 2541245875489853,
                ExpiryDate = DateTime.Today,
                Amount = 123,
                Currency = "Yen",
                CVV = 123,
                BankResponseID = Guid.NewGuid(),
                BankStatus = Status.Successfull,
                RequestDate = DateTime.Today
            });

            context.Requests.AddOrUpdate(x => x.RequestID, new Request()
            {
                RequestID = Guid.NewGuid(),
                MerchantID = 2,
                CardNumber = 2541245875489854,
                ExpiryDate = DateTime.Today,
                Amount = 123,
                Currency = "Yen",
                CVV = 123,
                BankResponseID = Guid.NewGuid(),
                BankStatus = Status.Successfull,
                RequestDate = DateTime.Today
            });

            context.Requests.AddOrUpdate(x => x.RequestID, new Request()
            {
                RequestID = Guid.NewGuid(),
                MerchantID = 1,
                CardNumber = 2451745865487541,
                ExpiryDate = DateTime.Today,
                Amount = 123,
                Currency = "Yen",
                CVV = 123,
                BankResponseID = Guid.NewGuid(),
                BankStatus = Status.Successfull,
                RequestDate = DateTime.Today
            });

        }
    }
}
