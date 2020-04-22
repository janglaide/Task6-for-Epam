using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
