﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProductService : IService<Product>
    {
        Task<IEnumerable<Product>> GetAllByOrderAsync(int orderId);
    }
}
