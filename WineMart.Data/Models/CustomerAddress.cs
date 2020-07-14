using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WineMart.Data.Models
{
    public class CustomerAddress
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string AddressLine1 { get; set; }

        [MaxLength(100)]
        public string AddressLine2 { get; set; }

        [MaxLength(10)]
        public string PostalCode { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(30)]
        public string State { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
    }
}
