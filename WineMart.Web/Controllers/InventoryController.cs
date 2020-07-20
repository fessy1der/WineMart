using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WineMart.Services.Inventory;
using WineMart.Web.Mappings;
using WineMart.Web.ViewModels;

namespace WineMart.Web.Controllers
{
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(
            ILogger<InventoryController> logger,
            IInventoryService inventoryService
        )
        {
            _inventoryService = inventoryService;
            _logger = logger;
        }

        [HttpGet("/api/inventory")]
        public ActionResult GetCurrentInventory()
        {
            _logger.LogInformation("Getting all inventory...");

            var inventory = _inventoryService.GetCurrentInventory()
                .Select(pi => new InventoryViewModel
                {
                    Id = pi.Id,
                    Product = ProductMapping.SerializeProductModel(pi.Product),
                    SupposedQuantity = pi.SupposedQuantity,
                    AvailableQuantity = pi.AvailableQuantity
                })
                .OrderBy(inv => inv.Product.Name)
                .ToList();

            return Ok(inventory);
        }

        [HttpPatch("/api/inventory")]
        public ActionResult UpdateInventory([FromBody] ShipmentViewModel shipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = shipment.ProductId;
            var adjustment = shipment.Adjustment;
            var inventory = _inventoryService.UpdateAvailableQuantity(id, adjustment);
            return Ok(inventory);
        }

        [HttpGet("/api/inventory/snapshot")]
        public ActionResult GetSnapshotHistory()
        {
            _logger.LogInformation("Getting snapshot history");

            try
            {
                var snapshotHistory = _inventoryService.GetTrackingHistory();

                var timelineMarkers = snapshotHistory
                    .Select(t => t.TimeTracked)
                    .Distinct()
                    .ToList();

                // Get quantities grouped by id.
                var snapshots = snapshotHistory
                    .GroupBy(hist => hist.Product, hist => hist.AvailableQuantity,
                        (key, g) => new InventoryTrackingViewModel
                        {
                            ProductId = key.Id,
                            QuantityOnHand = g.ToList()
                        })
                    .OrderBy(hist => hist.ProductId)
                    .ToList();

                var viewModel = new TrackingResponse
                {
                    Timeline = timelineMarkers,
                    InventoryTrackings = snapshots
                };

                return Ok(viewModel);
            }
            catch (Exception e)
            {
                _logger.LogError("Error getting snapshot history.");
                _logger.LogError(e.StackTrace);
                return BadRequest("Error retrieving history");
            }
        }
    }
}
