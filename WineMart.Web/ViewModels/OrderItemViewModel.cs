﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineMart.Web.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
