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
        Task<IEnumerable<OrderDTO>> GetAll();
        //Task<OrderDTO> GetOrderById(int id);
    }
}
