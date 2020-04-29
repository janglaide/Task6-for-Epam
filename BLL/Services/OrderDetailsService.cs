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

        public async Task AddProductDetails(OrderDetailsDTO orderDetailsDTO)
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<OrderDetailsDTO, OrderDetails>()).CreateMapper();
            var orderDetails = mapper.Map<OrderDetailsDTO, OrderDetails>(orderDetailsDTO);

            await _uow.OrderDetails.AddAsync(orderDetails);
            await _uow.CommitAsync();
        }

        public IEnumerable<OrderDetailsDTO> GetAll()
        {
            var orderDetails = _uow.OrderDetails.GetAll();
            var m = new MapperConfiguration(x => x.CreateMap<OrderDetails, OrderDetailsDTO>()).CreateMapper();
            var x = m.Map<IEnumerable<OrderDetails>, IEnumerable<OrderDetailsDTO>>(orderDetails);
            return x;
        }

        public async Task<IEnumerable<OrderDetailsDTO>> GetAllAsync()
        {
            var orderDetails = await _uow.OrderDetails.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDetails>, IEnumerable<OrderDetailsDTO>>(orderDetails);
        }
    }
}
