using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class OrderDetailsDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public OrderDTO Order { get; set; }
        public ProductDTO Product { get; set; }
    }
}
