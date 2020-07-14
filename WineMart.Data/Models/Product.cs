using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WineMart.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(64)]
        public string Name { get; set; }

        [MaxLength(128)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsArchived { get; set; }
    }
}
