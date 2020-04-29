using BLL.DTOs;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderService 
    {
        Task<IEnumerable<OrderDTO>> GetAllAsync();
        Task<OrderDTO> GetOrderById(int id);
        Task<IEnumerable<ProductDTO>> GetProductsByOrderId(int id);
        Task AddOrder(OrderDTO orderDTO);
        Task AddProductToOrder(OrderDetailsDTO orderDetailsDTO);
    }
}
