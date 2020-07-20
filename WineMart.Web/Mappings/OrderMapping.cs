using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WineMart.Data.Models;
using WineMart.Web.Serialization;
using WineMart.Web.ViewModels;

namespace WineMart.Web.Mappings
{
    public class OrderMapping
    {
        public static Order SerializeInvoiceToOrder(InvoiceViewModel invoice)
        {
            var orderItems = invoice.Items
                .Select(item => new OrderItem
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Product = ProductMapping.SerializeProductModel(item.Product)
                }).ToList();

            return new Order
            {
                OrderItems = orderItems,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };
        }

        public static List<OrderViewModel> SerializeOrdersToViewModels(IEnumerable<Order> orders)
        {
            return orders.Select(order => new OrderViewModel
            {
                Id = order.Id,
                CreatedOn = order.DateCreated,
                UpdatedOn = order.DateUpdated,
                OrderItems = SerializeSalesOrderItems(order.OrderItems),
                Customer = CustomerMapping.SerializeCustomer(order.Customer),
                IsPaid = order.IsPaid
            }).ToList();
        }

        private static List<OrderItemViewModel> SerializeSalesOrderItems(IEnumerable<OrderItem> orderItems)
        {
            return orderItems.Select(item => new OrderItemViewModel
            {
                Id = item.Id,
                Quantity = item.Quantity,
                Product = ProductMapping.SerializeProductModel(item.Product)
            }).ToList();
        }
    }
}
