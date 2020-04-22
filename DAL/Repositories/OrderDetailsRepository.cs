using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class OrderDetailsRepository : IRepository<OrderDetails>
    {
        private MyDbContext db;
        public OrderDetailsRepository(MyDbContext myDbContext)
        {
            db = myDbContext;
        }
        public void Add(OrderDetails item)
        {
            db.OrderDetails.Add(item);
            db.SaveChanges();
        }

        public OrderDetails Get(int id)
        {
            return db.OrderDetails.Find(id);
        }

        public IEnumerable<OrderDetails> GetAll()
        {
            return db.OrderDetails;
        }
    }
}
