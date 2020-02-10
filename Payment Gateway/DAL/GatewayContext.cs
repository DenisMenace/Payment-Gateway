using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Payment_Gateway.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Payment_Gateway.DAL
{
    public class GatewayContext : DbContext, IDbContext
    {
        public GatewayContext() : base("name=Payment_GatewayContext")
        {
        }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}