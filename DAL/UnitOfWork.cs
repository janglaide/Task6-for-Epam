using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private MyDbContext _dbContext;
        private bool _disposed;

        private IOrderRepository _orderRepository;
        private IOrderDetailsRepository _orderdetailsRepository;
        private IProductRepository _productsRepository;
        public UnitOfWork(MyDbContext context)
        {
            _dbContext = context;
            _disposed = false;
        }

        public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_dbContext);
        public IOrderDetailsRepository OrderDetails => _orderdetailsRepository ??= new OrderDetailsRepository(_dbContext);
        public IProductRepository Products => _productsRepository ??= new ProductRepository(_dbContext); 

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _dbContext.Dispose();
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
