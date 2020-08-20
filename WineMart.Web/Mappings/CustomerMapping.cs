using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineMart.Data.Models;
using WineMart.Web.ViewModels;

namespace WineMart.Web.Serialization
{
    public class CustomerMapping
    {
        public static CustomerViewModel SerializeCustomer(Customer customer)
        {
            return new CustomerViewModel
            {
                Id = customer.Id,
                DateCreated = customer.DateCreated,
                DateUpdated = customer.DateUpdated,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = MapCustomerAddress(customer.Address),
            };
        }
        
        public static Customer SerializeCustomer(CustomerViewModel customer)
        {
            return new Customer
            {
                DateCreated = customer.DateCreated,
                DateUpdated = customer.DateUpdated,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = MapCustomerAddress(customer.Address),
            };
        }

        public static CustomerAddressViewModel MapCustomerAddress(CustomerAddress address)
        {
            return new CustomerAddressViewModel
            {
                Id = address.Id,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                State = address.State,
                PostalCode = address.PostalCode,
                Country = address.Country,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
            };
        }

        public static CustomerAddress MapCustomerAddress(CustomerAddressViewModel address)
        {
            return new CustomerAddress
            {
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                City = address.City,
                State = address.State,
                PostalCode = address.PostalCode,
                Country = address.Country,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
            };
        }
    }
}
