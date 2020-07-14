using System;
using System.Collections.Generic;
using System.Text;

namespace WineMart.Data.Models
{
    public class InventoryTracking
    {
        public int Id { get; set; }
        public DateTime TimeTracked { get; set; }
        public int AvailableQuantity { get; set; }
        public Product Product { get; set; }
    }
}
