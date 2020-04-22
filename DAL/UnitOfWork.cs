using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private MyDbContext _dbContext;
        private bool _disposed;

        private IRepository<Order> _orderRepository;
        private IRepository<OrderDetails> _orderdetailsRepository;
        private IRepository<Product> _productsRepository;
        public UnitOfWork(string connection)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            var options = optionsBuilder
                .UseSqlServer(connection)
                .Options;
            _dbContext = new MyDbContext(options);
            _disposed = false;
        }

        public IRepository<Order> Orders 
        {
            get
            {
                if (_orderRepository == null)
                    _orderRepository = new OrderRepository(_dbContext);
                return _orderRepository;
            }
        }
        public IRepository<OrderDetails> OrderDetails 
        { 
            get
            {
                if (_orderdetailsRepository == null)
                    _orderdetailsRepository = new OrderDetailsRepository(_dbContext);
                return _orderdetailsRepository;
            }
        }
        public IRepository<Product> Products 
        { 
            get
            {
                if (_productsRepository == null)
                    _productsRepository = new ProductRepository(_dbContext);
                return _productsRepository;
            }
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
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
    }
}
