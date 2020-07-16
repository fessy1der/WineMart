using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WineMart.Web.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsArchived { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
