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
        private IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _mapper = new MapperConfiguration(x => x.CreateMap<Order, OrderDTO>()).CreateMapper();
        }

        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            var orders = await _uow.Orders.GetAllAsync();
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(orders);
        }

        /*public Task<OrderDTO> GetOrderById(int id)
        {
            var orders = await _uow.Orders.
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(orders);
        }*/
    }
}
