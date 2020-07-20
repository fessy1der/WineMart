using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using WineMart.Data;
using WineMart.Services.Inventory;
using WineMart.Services.Product;

namespace WineMart.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<OrderService> _logger;
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;

        public OrderService(ApplicationDbContext db)
        {
            _db = db;
        }

        public ServiceResponse<bool> GenerateOpenOrder(Data.Models.Order order)
        {
            var now = DateTime.UtcNow;

            _logger.LogInformation("Generating new order");

            foreach (var item in order.OrderItems)
            {
                item.Product = _productService
                    .GetProduct(item.Product.Id);
                var inventoryId = _inventoryService
                    .GetByProductId(item.Product.Id).Id;
                _inventoryService
                    .UpdateAvailableQuantity(inventoryId, -item.Quantity);
            }

            try
            {
                _db.Orders.Add(order);
                _db.SaveChanges();

                return new ServiceResponse<bool>
                {
                    IsSuccess = true,
                    Data = true,
                    Message = "Open order created",
                    Time = now
                };
            }

            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    Message = e.StackTrace,
                    Time = now
                };
            }
        }

        public List<Data.Models.Order> GetOrders()
        {
            return _db.Orders
                .Include(o => o.Customer)
                .ThenInclude(c => c.Address)
                .Include(o => o.OrderItems)
                .ThenInclude(i => i.Product).ToList();
        }

        public ServiceResponse<bool> MarkCompleted(int id)
        {
            var now = DateTime.UtcNow;
            var order = _db.Orders.Find(id);
            order.DateUpdated = now;
            order.IsPaid = true;

            try
            {
                _db.Orders.Update(order);
                _db.SaveChanges();

                return new ServiceResponse<bool>
                {
                    IsSuccess = true,
                    Data = true,
                    Message = $"Order {order.Id} closed: Invoice paid in full.",
                    Time = now
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    Message = e.StackTrace,
                    Time = now
                };
            }
        }
    }
}
