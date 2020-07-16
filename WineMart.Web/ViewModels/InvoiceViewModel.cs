using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineMart.Web.ViewModels
{
    public class InvoiceViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItemViewModel> Items { get; set; }
    }
}
