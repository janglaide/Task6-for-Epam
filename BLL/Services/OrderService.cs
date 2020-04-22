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
    public class OrderService : IOrderService
    {
        private IUnitOfWork _uow;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<Order> Add(Order item)
        {
            await _uow.Orders.AddAsync(item);
            await _uow.CommitAsync();
            return item;
        }

        public async Task<Order> Get(int id)
        {
            return await _uow.Orders.GetAsync(id);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _uow.Orders.GetAllAsync();
        }
    }
}
