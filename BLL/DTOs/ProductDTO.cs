﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<OrderDetailsDTO> OrderDetails { get; set; }
    }
}
