using System;
using System.Collections.Generic;
using System.Text;

namespace WineMart.Services.Inventory
{
    public interface IInventoryService
    {
        public List<Data.Models.Inventory> GetCurrentInventory();
        public ServiceResponse<Data.Models.Inventory> UpdateAvailableQuantity(int id, int adjustment);
        public Data.Models.Inventory GetByProductId(int productId);
        public List<Data.Models.InventoryTracking> GetTrackingHistory();
    }
}
