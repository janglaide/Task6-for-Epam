using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class OrderDetailsService : IService<OrderDetailsDTO>
    {
        private IUnitOfWork _uow;
        public OrderDetailsService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public void Add(OrderDetailsDTO item)
        {
            var newItem = new OrderDetails
            {
                Id = item.Id,
                OrderId = item.OrderId,
                ProductId = item.ProductId
            };
            _uow.OrderDetails.Add(newItem);
            _uow.Save();
        }

        public OrderDetailsDTO Get(int id)
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<OrderDetails, OrderDetailsDTO>()).CreateMapper();
            return mapper.Map<OrderDetails, OrderDetailsDTO>(_uow.OrderDetails.Get(id));
        }

        public IEnumerable<OrderDetailsDTO> GetAll()
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<OrderDetails, OrderDetailsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<OrderDetails>, IEnumerable<OrderDetailsDTO>>(_uow.OrderDetails.GetAll());
        }
    }
}
