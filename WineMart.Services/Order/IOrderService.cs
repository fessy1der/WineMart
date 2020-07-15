using System;
using System.Collections.Generic;
using System.Text;

namespace WineMart.Services.Order
{
    public interface IOrderService
    {
        List<Data.Models.Order> GetOrders();
        ServiceResponse<bool> GenerateOpenOrder(Data.Models.Order order);
        ServiceResponse<bool> MarkCompleted(int id);
    }
}
