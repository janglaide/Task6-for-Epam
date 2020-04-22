using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private MyDbContext db;
        public ProductRepository(MyDbContext myDbContext)
        {
            db = myDbContext;
        }
        public void Add(Product item)
        {
            db.Products.Add(item);
            db.SaveChanges();
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }
    }
}
