using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Order> Orders { get; }
        IRepository<OrderDetails> OrderDetails { get; }
        IRepository<Product> Products { get;}
        void Dispose(bool disposing);
        void Save();
    }
}
