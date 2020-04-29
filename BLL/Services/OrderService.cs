using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

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

        public async Task AddOrder(OrderDTO orderDTO)
        {
            var mapper = new MapperConfiguration(x => x.CreateMap<OrderDTO, Order>()).CreateMapper();
            var order = mapper.Map<OrderDTO, Order>(orderDTO);

            await _uow.Orders.AddAsync(order);
            await _uow.CommitAsync();
        }

        public async Task AddProductToOrder(OrderDetailsDTO orderDetailsDTO)
        {
            var orderDetailsService = new OrderDetailsService(_uow);
            await orderDetailsService.AddProductDetails(orderDetailsDTO);
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(_uow.Orders.GetAll());
        }

        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        {
            var orders = await _uow.Orders.GetAllAsync();
            return _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> GetOrderById(int id)
        {
            var order = await _uow.Orders.GetAsync(id);
            return _mapper.Map<Order, OrderDTO>(order);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByOrderId(int id)
        {
            var products = await _uow.Products.GetAllAsync();
            var orderDetails = await _uow.OrderDetails.GetAllAsync();

            var list = products.Join(orderDetails, p => p.Id, od => od.ProductId,
                (p, od) => new { p.Id, p.Name, p.Price, od.OrderId })
                .Where(x => x.OrderId == id);
            var res = new List<ProductDTO>();
            foreach(var x in list)
            {
                res.Add(new ProductDTO { Id = x.Id, Name = x.Name, Price = x.Price });
            }
            return res;
        }
    }
}
