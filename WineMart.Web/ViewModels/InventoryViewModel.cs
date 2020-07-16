using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineMart.Web.ViewModels
{
    public class InventoryViewModel
    {
        public int Id { get; set; }
        public int AvailableQuantity { get; set; }
        public int SupposedQuantity { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
