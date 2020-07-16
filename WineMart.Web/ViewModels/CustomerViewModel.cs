using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WineMart.Web.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        [MaxLength(32)] 
        public string FirstName { get; set; }

        [MaxLength(32)] 
        public string LastName { get; set; }

        public CustomerAddressViewModel Address { get; set; }
    }
}
