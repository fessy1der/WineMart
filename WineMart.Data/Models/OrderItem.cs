﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WineMart.Data.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
