using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WineMart.Data;
using WineMart.Data.Models;

namespace WineMart.Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<InventoryService> _logger;

        public InventoryService(ApplicationDbContext db, ILogger<InventoryService> logger)
        {
            _db = db;
            _logger = logger;
        }

        public Data.Models.Inventory GetByProductId(int productId)
        {
            return _db.ProductInventories
                .Include(pi => pi.Product)
                .FirstOrDefault(pi => pi.Product.Id == productId);
        }

        public List<Data.Models.Inventory> GetCurrentInventory()
        {
            return _db.ProductInventories
                .Include(pi => pi.Product)
                .Where(pi => !pi.Product.IsArchived)
                .ToList();
        }

        public List<InventoryTracking> GetTrackingHistory()
        {
            var earliest = DateTime.UtcNow - TimeSpan.FromHours(2);

            return _db.InventoryTrackings
                .Include(t => t.Product)
                .Where(t
                    => t.TimeTracked > earliest
                       && !t.Product.IsArchived)
                .ToList();
        }

        public ServiceResponse<Data.Models.Inventory> UpdateAvailableQuantity(int id, int adjustment)
        {
            var now = DateTime.UtcNow;

            try
            {
                var inventory = _db.ProductInventories
                    .Include(inv => inv.Product)
                    .First(inv => inv.Product.Id == id);

                inventory.AvailableQuantity += adjustment;

                try
                {
                    CreateSnapshot();
                }

                catch (Exception e)
                {
                    _logger.LogError("Error creating inventory snapshot.");
                    _logger.LogError(e.StackTrace);
                }

                _db.SaveChanges();

                return new ServiceResponse<Data.Models.Inventory>
                {
                    IsSuccess = true,
                    Data = inventory,
                    Message = $"Product {id} inventory adjusted",
                    Time = now
                };
            }

            catch
            {
                return new ServiceResponse<Data.Models.Inventory>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"Error updating ProductInventory QuantityOnHand",
                    Time = now
                };
            }
        }

        private void CreateSnapshot()
        {
            var now = DateTime.UtcNow;

            var inventories = _db.ProductInventories
                .Include(inv => inv.Product)
                .ToList();

            foreach (var inventory in inventories)
            {
                var snapshot = new InventoryTracking
                {
                    TimeTracked = now,
                    Product = inventory.Product,
                    AvailableQuantity = inventory.AvailableQuantity
                };

                _db.Add(snapshot);
            }
        }
    }
}
