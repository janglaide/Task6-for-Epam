using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private MyDbContext db;
        public OrderRepository(MyDbContext myDbContext)
        {
            db = myDbContext;
        }
        public void Add(Order item)
        {
            db.Orders.Add(item);
            db.SaveChanges();
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }
    }
}
