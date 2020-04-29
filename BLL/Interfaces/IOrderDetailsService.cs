using BLL.DTOs;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IOrderDetailsService 
    {
        Task<IEnumerable<OrderDetailsDTO>> GetAllAsync();
        IEnumerable<OrderDetailsDTO> GetAll();

    }
}
