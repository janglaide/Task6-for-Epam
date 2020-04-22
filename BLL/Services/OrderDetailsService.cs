using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private IUnitOfWork _uow;
        public OrderDetailsService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<OrderDetails> Add(OrderDetails item)
        {
            await _uow.OrderDetails.AddAsync(item);
            await _uow.CommitAsync();
            return item;
        }

        public async Task<OrderDetails> Get(int id)
        {
            return await _uow.OrderDetails.GetAsync(id);
        }

        public async Task<IEnumerable<OrderDetails>> GetAll()
        {
            return await _uow.OrderDetails.GetAllAsync();
        }
    }
}
