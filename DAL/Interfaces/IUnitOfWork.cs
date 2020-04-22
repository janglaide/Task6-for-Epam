using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        IOrderDetailsRepository OrderDetails { get; }
        IProductRepository Products { get;}
        Task<int> CommitAsync();
        void Dispose(bool disposing);
    }
}
