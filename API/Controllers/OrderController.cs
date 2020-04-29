using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
            _mapper = new MapperConfiguration(x => x.CreateMap<OrderDTO, OrderModel>()).CreateMapper();
        }

        [HttpGet]
        public async Task<IEnumerable<OrderModel>> GetAllOrders()
        {
            var orderDTOs = await _orderService.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDTO>, IEnumerable<OrderModel>>(orderDTOs);
        }

        [HttpGet("{id}")]
        public async Task<OrderModel> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            return _mapper.Map<OrderDTO, OrderModel>(order);
        }

        [HttpGet("{id}/products")]
        public async Task<IEnumerable<ProductModel>> GetProductsByOrderId(int id)
        {
            var products = await _orderService.GetProductsByOrderId(id);

            var map = new MapperConfiguration(x => x.CreateMap<ProductDTO, ProductModel>()).CreateMapper();
            var x = map.Map<IEnumerable<ProductDTO>, IEnumerable<ProductModel>>(products);
            return x;
        }
    }
}