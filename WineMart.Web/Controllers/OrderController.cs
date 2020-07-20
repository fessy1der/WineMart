using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WineMart.Services.Customer;
using WineMart.Services.Order;
using WineMart.Web.Mappings;
using WineMart.Web.ViewModels;

namespace WineMart.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        public OrderController(
            ILogger<OrderController> logger,
            IOrderService orderService,
            ICustomerService customerService)
        {
            _logger = logger;
            _orderService = orderService;
            _customerService = customerService;
        }

        [HttpPost("/api/invoice")]
        public ActionResult GenerateNewOrder([FromBody] InvoiceViewModel invoice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("Generating invoice");
            var order = OrderMapping.SerializeInvoiceToOrder(invoice);
            order.Customer = _customerService.GetCustomer(invoice.CustomerId);
            _orderService.GenerateOpenOrder(order);
            return Ok();
        }

        [HttpGet("/api/order")]
        public ActionResult GetOrders()
        {
            var orders = _orderService.GetOrders();
            var orderModels = OrderMapping.SerializeOrdersToViewModels(orders);
            return Ok(orderModels);
        }

        [HttpPatch("/api/order/complete/{id}")]
        public ActionResult MarkOrderComplete(int id)
        {
            _logger.LogInformation($"Marking order {id} complete...");
            _orderService.MarkCompleted(id);
            return Ok();
        }
    }
}
