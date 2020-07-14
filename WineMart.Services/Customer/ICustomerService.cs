using System;
using System.Collections.Generic;
using System.Text;

namespace WineMart.Services.Customer
{
    public interface ICustomerService
    {
        List<Data.Models.Customer> GetCustomers();
        Data.Models.Customer GetCustomer(int id);
        ServiceResponse<Data.Models.Customer> CreateCustomer(Data.Models.Customer customer);
        ServiceResponse<bool> DeleteCustomer(int id);
    }
}
