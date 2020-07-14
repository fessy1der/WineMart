using System;
using System.Collections.Generic;
using System.Text;

namespace WineMart.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public bool IsPaid { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
