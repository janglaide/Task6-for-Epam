using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class OrderService : IService<OrderDTO>
    {
        private IUnitOfWork _uow;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public void Add(OrderDTO item)
        {
            var newItem = new Order
            {
                Id = item.Id,
                OrderDate = item.OrderDate
            };
            _uow.Orders.Add(newItem);
            _uow.Save();
        }

        public OrderDTO Get(int id)
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<Order, OrderDTO>(_uow.Orders.Get(id));
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<Order, OrderDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(_uow.Orders.GetAll());
        }
    }
}
