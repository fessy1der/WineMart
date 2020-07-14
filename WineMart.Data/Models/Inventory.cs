using System;
using System.Collections.Generic;
using System.Text;

namespace WineMart.Data.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public int AvailableQuantity { get; set; }
        public int SupposedQuantity { get; set; }
        public Product Product { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
