using AutoMapper;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BLL.Interfaces;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWork _uow;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<Product> Add(Product item)
        {
            await _uow.Products.AddAsync(item);
            await _uow.CommitAsync();
            return item;
        }

        public async Task<Product> Get(int id)
        {
            return await _uow.Products.GetAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _uow.Products.GetAllAsync();
        }

        public async Task<IEnumerable<Product>> GetAllByOrderAsync(int orderId)
        {
            return await _uow.Products.GetAllByOrderAsync(orderId);
        }
    }
}
