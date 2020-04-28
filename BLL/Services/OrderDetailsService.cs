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
        private IMapper _mapper;
        public OrderDetailsService(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _mapper = new MapperConfiguration(x => x.CreateMap<OrderDetails, OrderDetailsDTO>()).CreateMapper();
        }

        public async Task<IEnumerable<OrderDetailsDTO>> GetAll()
        {
            var orderDetails = await _uow.OrderDetails.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDetails>, IEnumerable<OrderDetailsDTO>>(orderDetails);
        }
    }
}
