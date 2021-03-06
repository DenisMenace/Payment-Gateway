﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_Gateway.DAL
{
    public interface IDbContext: IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
    }
}
