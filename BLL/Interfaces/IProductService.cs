using BLL.DTOs;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductService 
    {
        Task<IEnumerable<ProductDTO>> GetAll();
        //Task<ProductDTO> GetProductById(int id);
        //Task<IEnumerable<Product>> GetAllByOrderAsync(int orderId);
    }
}
