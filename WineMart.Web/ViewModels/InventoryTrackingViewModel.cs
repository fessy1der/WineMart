using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineMart.Web.ViewModels
{
    public class InventoryTrackingViewModel
    {
        public List<int> QuantityOnHand { get; set; }
        public int ProductId { get; set; }
    }
}
