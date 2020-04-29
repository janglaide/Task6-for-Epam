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

        private IOrderRepository _orderRepository;
        private IOrderDetailsRepository _orderdetailsRepository;
        private IProductRepository _productsRepository;
        public UnitOfWork(MyDbContext context)
        {
            _dbContext = context;
            _orderdetailsRepository = new OrderDetailsRepository(context);
            _orderRepository = new OrderRepository(context);
            _productsRepository = new ProductRepository(context);
        }

        public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_dbContext);
        public IOrderDetailsRepository OrderDetails => _orderdetailsRepository ??= new OrderDetailsRepository(_dbContext);
        public IProductRepository Products => _productsRepository ??= new ProductRepository(_dbContext); 

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
