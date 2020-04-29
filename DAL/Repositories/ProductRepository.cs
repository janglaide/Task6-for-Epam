using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext context) : base(context) { }

        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }

        public Task<IEnumerable<Product>> GetAllByOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
