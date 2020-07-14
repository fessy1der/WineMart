using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WineMart.Data;

namespace WineMart.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _db;

        public CustomerService(ApplicationDbContext db)
        {
            _db = db;
        }

        public ServiceResponse<Data.Models.Customer> CreateCustomer(Data.Models.Customer customer)
        {
            var now = DateTime.UtcNow;

            try
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();

                return new ServiceResponse<Data.Models.Customer>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Customer created successfully!",
                    Data = customer
                };
            }

            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.Customer>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Data = customer
                };
            }
        }

        public ServiceResponse<bool> DeleteCustomer(int id)
        {
            var customer = GetCustomer(id);
            var now = DateTime.UtcNow;

            if (customer == null)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Customer not found!",
                    Data = false
                };
            }

            try
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();

                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Customer deleted successfully!",
                    Data = true
                };
            }

            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Data = false
                };
            }
        }

        public Data.Models.Customer GetCustomer(int id)
        {
            return _db.Customers.Find(id);
        }

        public List<Data.Models.Customer> GetCustomers()
        {
            return _db.Customers.Include(c => c.Address)
                                .OrderBy(c => c.FirstName).ToList();
        }
    }
}
